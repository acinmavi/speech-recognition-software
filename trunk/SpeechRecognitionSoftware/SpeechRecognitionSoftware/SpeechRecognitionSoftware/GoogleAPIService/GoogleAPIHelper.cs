using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using CUETools.Codecs.FLAKE;
using CUETools.Codecs;
using System.Text.RegularExpressions;
using Service;

namespace Services
{
	public class Constants
	{
		public static string GoogleRequestString =
			Configuration.GetConfiguration().getGoogleRqString();

	}
	
	public class SoundRecognition
	{
		
		/// <summary>
		/// Send request to google speech recognition service and return recognized string
		/// </summary>
		/// <param name="flacName">path to .flac file</param>
		/// <param name="sampleRate">Rate</param>
		/// <returns>recognized string</returns>
		public static string GoogleRequest(string flacName, int sampleRate)
		{
			var bytes = File.ReadAllBytes(flacName);
			return GoogleRequest(bytes, sampleRate);
		}

		/// <summary>
		/// Send request to google speech recognition service and return recognized string
		/// </summary>
		/// <param name="bytes">byte array wich is a sound in .flac</param>
		/// <param name="sampleRate">Rate</param>
		/// <returns>recognized string</returns>
		public static string GoogleRequest(byte[] bytes, int sampleRate,WebProxy proxy=null)
		{
			Stream stream = null;
			StreamReader sr = null;
			WebResponse response = null;
			JSon.RecognizedItem result;
			try
			{
				WebRequest request = WebRequest.Create(Constants.GoogleRequestString);
				if(proxy !=null){
					request.Proxy = proxy;
				}
				request.Method = "POST";
				request.ContentType = "audio/x-flac; rate=" + sampleRate;
				request.ContentLength = bytes.Length;
				 request.Timeout = Configuration.GetConfiguration().getTimeout()*1000;
				stream = request.GetRequestStream();
               
				stream.Write(bytes, 0, bytes.Length);
				stream.Close();

				response = request.GetResponse();

				stream = response.GetResponseStream();
				if (stream == null)
				{
					throw new Exception("Can't get a response from server. Response stream is null.");
				}
				sr = new StreamReader(stream);

				//Get response in JSON format
				string respFromServer = sr.ReadToEnd();

				var parsedResult = JSon.Parse(respFromServer);
				result =
					parsedResult.hypotheses.Where(d => d.confidence == parsedResult.hypotheses.Max(p => p.confidence)).FirstOrDefault();
			}
			finally
			{
				if (stream != null)
					stream.Close();

				if (sr != null)
					sr.Close();

				if (response != null)
					response.Close();
			}

			return result == null ? "" : result.utterance;
		}

		/// <summary>
		/// Send request to google speech recognition service and return recognized string
		/// </summary>
		/// <param name="flacStream">stream of sound in flac format</param>
		/// <param name="sampleRate">Rate</param>
		/// <returns>recognized string</returns>
		public static string GoogleRequest(MemoryStream flacStream, int sampleRate,WebProxy proxy=null)
		{
			flacStream.Position = 0;
			var bytes = new byte[flacStream.Length];
			flacStream.Read(bytes, 0, (int)flacStream.Length);
			return GoogleRequest(bytes, sampleRate,proxy);
		}

		/// <summary>
		/// Convert .wav file to .flac file with the same name
		/// </summary>
		/// <param name="WavName">path to .wav file</param>
		/// <returns>Sample Rate of converted .flac</returns>
		public static int Wav2Flac(string WavName)
		{
			int sampleRate;
			var flacName = Path.ChangeExtension(WavName, "flac");

			FlakeWriter audioDest = null;
			IAudioSource audioSource = null;
			try
			{
				audioSource = new WAVReader(WavName, null);

				AudioBuffer buff = new AudioBuffer(audioSource, 0x10000);

				audioDest = new FlakeWriter(flacName, audioSource.PCM);

				sampleRate = audioSource.PCM.SampleRate;

				while (audioSource.Read(buff, -1) != 0)
				{
					audioDest.Write(buff);
				}
			}
			finally
			{
				if (audioDest != null) audioDest.Close();
				if (audioSource != null) audioSource.Close();
			}
			return sampleRate;
		}

		/// <summary>
		/// Convert stream of wav to flac format and send it to google speech recognition service.
		/// </summary>
		/// <param name="stream">wav stream</param>
		/// <returns>recognized result</returns>
		public static string WavStreamToGoogle(Stream stream)
		{
			Utilities.WriteLine("Convert to flac....");
			FlakeWriter audioDest = null;
			IAudioSource audioSource = null;
			WebProxy proxy = null;
			proxy = Configuration.GetConfiguration().getNextWebProxy();
			if(proxy!=null){
			Utilities.WriteLine("Proxy use : "+proxy.Address.Host+":"+proxy.Address.Port,true);
			}else{
				Utilities.WriteLine("No use proxy",true);
			}
			string answer;
			try
			{
				var outStream = new MemoryStream();

				stream.Position = 0;

				audioSource = new WAVReader("", stream);

				var buff = new AudioBuffer(audioSource, 0x10000);

				audioDest = new FlakeWriter("", outStream, audioSource.PCM);

				var sampleRate = audioSource.PCM.SampleRate;

				while (audioSource.Read(buff, -1) != 0)
				{
					audioDest.Write(buff);
				}
				Utilities.WriteLine("Send to Google API....");
				answer = GoogleRequest(outStream, sampleRate,proxy);
				
			}
			finally
			{
				if (audioDest != null) audioDest.Close();
				if (audioSource != null) audioSource.Close();
			}
			return answer;
		}
		
		/// <summary>
		/// Convert stream of wav to flac format and send it to google speech recognition service.
		/// </summary>
		/// <param name="stream">wav stream</param>
		/// <returns>recognized result</returns>
		public static string WavStreamToGoogle(byte[] byteStream)
		{
			Stream stream = new MemoryStream(byteStream);
			return WavStreamToGoogle(stream);
		}
	}

	public class JSon
	{
		public class RecognizedItem
		{
			public string utterance;
			public float confidence;
		}

		public class RecognitionResult
		{
			public string status;
			public string id;
			public List<RecognizedItem> hypotheses;
		}

		public static RecognitionResult Parse(String toParse)
		{
			//Шапка
			Regex regexCommonInfo = new Regex(@"""status"":(?<status>\d),""id"":""(?<id>[\w-]+)""");
			RecognitionResult result = new RecognitionResult();
			var match = regexCommonInfo.Match(toParse);
			result.id = match.Groups["id"].Value;
			result.status = match.Groups["status"].Value;

			//Гипотезы
			Regex regexUtter = new Regex(@"""utterance"":""(?<utter>[а-яА-Я\s\w.,]+)"",""confidence"":(?<conf>[\d.]+)");

			float confidence;
			var matches = regexUtter.Matches(toParse);
			List<RecognizedItem> hypos = new List<RecognizedItem>();
			foreach (Match m in matches)
			{
				var g = m.Groups;
				confidence = float.Parse(g["conf"].Value.Replace(".", ","));
				hypos.Add(new RecognizedItem { confidence = confidence, utterance = g["utter"].Value });
			}
			result.hypotheses = hypos;


			return result;
		}
	}
}
