   M S B A M L   `   `   `  ����M  IVoiceRecorder.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS<clr-namespace:VoiceRecorder.Core;assembly=VoiceRecorder.CoreVoiceRecorder.Core  5   �    SpeechRecognitionSoftware    VoiceRecorder.RecorderView   6   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    6'   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6i   Kmy<clr-namespace:VoiceRecorder.Core;assembly=VoiceRecorder.Core     6�     � 	Resources  5       �� 
TargetType �� Property �� Value �� 
TargetType �� 
StartPoint �� EndPoint � Offset � Color��%�  '�       �� 5      " �5      .�5      ��  � �� 5
      �� 5      " �5      .R�5      � $��14��5      $	��200��5      .+�5   	   �� $��
PART_Track��5   	   ��5   
   �� 5      $	 0,0&�5      $	 1,0&�5      .��5      � $ 0Q�5      $ 	#FF00FF00��5      � 5      $	 0.9Q�5      $ 	#FFFFFF00��5      � 5      $ 1Q�5      $ 	#FFFF0000��5      5      5!   
   ]� 5"   	   .+�5#   
   �� $��PART_Indicator��5%   
   $
��Left=�5$   
   5%   
   �� 5&   
   $
��Mask��5'   
   ���#C0C0C05(   
   5)   
   �� 5*   	   $��1q�5+   	   ���#8888885,   	   5-   	   5.      50      51      52      .��53      �� 
�������.+�55      �� $��5q�56      $��Center=�57      $
��Bold"�58      $��20(�59      $��Voice Recognition Service��5:      6*   �� 5;      $��5q�5<      .��6   -+Check the levels before starting recording:6<   � 5=      $��5q�5>      	 � Orientation$	 
Horizontal=�5?      $��20��5A      
 � Value
 5@      �� *CurrentInputLevel+ �� Mode$ OneWay=�5A      �� 5B      $��5q�5C      .��6   Microphone Level:6"   �� 5D      $��5q�5E       �� Orientation$ 
Horizontal=�5F       � Maximum$	 100Q�5H      
 5G      �� *MicrophoneLevel+$ TwoWay=�5H      �� 5I       �� Orientation$ 
Horizontal=�5J      .+�5K      ��    CircleButton#��[  5L      $��5q�5N       � ToolTip$ Start Recording��5O      ��5M      �� *BeginRecordingCommand+5O      �� 5P        
StopButton#��[ 5Q      $��5q�5S      $ Stop Recording��5T      ��5R      �� *StopCommand+5T      �� 5U      
���   �$��2q�5W       �� CornerRadius$ 3��5X      $��2q�5Y      ._�5Z      �� $	��3,1q�5[      $
��Bold"�5]      $��16(�5^      ��5\      �� *RecordedTime+5^      5_      5`      /   )VoiceRecorder.Core.PolygonWaveFormControl  5a      $��5q�5b      $��40��5c         SampleAggregator 5d      �� *SampleAggregator+{�5e      �� *ShowWaveForm+5f      5g      