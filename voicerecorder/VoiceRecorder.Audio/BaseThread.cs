/*
 * Created by SharpDevelop.
 * User: Admin15
 * Date: 27/08/2013
 * Time: 3:23 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Threading;

namespace Services
{
	/// <summary>
	/// Description of BaseThread.
	/// </summary>
	public abstract class  BaseThread
	{
		public Thread _thread;

		public BaseThread() { _thread = new Thread(new ThreadStart(this.RunThread)); }

		// Thread methods / properties
		public void Start() { _thread.Start(); }
		public void Join() { _thread.Join(); }
		public bool IsAlive { get { return _thread.IsAlive; } }

		// Override in base class
		public abstract void RunThread();
		public abstract void Stop();
		
	}

}
