   M S B A M L   `   `   `  ����M  IVoiceRecorder.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS<clr-namespace:VoiceRecorder.Core;assembly=VoiceRecorder.CoreVoiceRecorder.Core  5   �    SpeechRecognitionSoftware   VoiceRecorder.SaveView   6   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    6#   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6e   Kmy<clr-namespace:VoiceRecorder.Core;assembly=VoiceRecorder.Core     6�   
�������.��5      �� .+�5      �� $��5q�5      $��Center=�5      $
��Bold"�5	      $��20(�5
      $��Speech Recognition��5      6#   �� 5      $��5q�5      .��6   " View recored audio before close:61   /   )VoiceRecorder.Core.WaveFileTrimmerControl  5      $��5q�5          SampleAggregator  5      �� *SampleAggregator+   TotalWaveFormSamples 5      �� *TotalWaveFormSamples+   LeftSelection 5      �� *LeftPosition+ �� Mode$ TwoWay=�   RightSelection 5      �� *RightPosition+$ TwoWay=��� 5       �� Orientation$ 
Horizontal=�5      .+�5      �� $��5q�5      $
��10,0q�5       � ToolTip$
 Play��5      ��5      �� *PlayCommand+.��5      F� 
��� d �"����        � z  z �     $� 	5      5      �� 5      $��5q�5       $
��10,0q�5!      $
 Stop��5#      ��5"      �� *StopCommand+.��5$      F� 
����  �+����        ����     ���� ��� �    ��� 	5&      5'      �� 5(      $��5q�5)      $	��100��5*      $y�Hidden=�5+      ��5,      �� *SelectAllCommand+.��6*   
Select All66   5-      �� 5.      $ 
Horizontal=�5/      .+�50      �� $y�Hidden=�51      $��5q�52      $	��100��53      ��54      �� *SaveCommand+.��6%   	Save...6.   �� 55      $y�Hidden=�56      $��5q�57      $	��100��58      ��59      �� *AutoTuneCommand+.��6)   
AutoTune63   5:      5;      5<      