   M S B A M L   `   `   `  ����  SpeechRecognitionSoftware     VoiceRecorder.AutoTuneView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      
�������.��5	      � .+�5
      �� {�6   �� *	IsEnabled+.+�5   
   �� $��5q�6   $��Center=�6   $
��Bold"�68   $��20(�6J   .��6X   AutoTune Settings6k   �� 5   
     �� Orientation$  
Horizontal=�6   .+�5      �� $��5q�6?    d� 	IsChecked 6   �� *IsAutoTuneEnabled+.��6J   Enable Autotune6[   5      �� 5   
   $  
Horizontal=�6   .+�5      �� $��5q�6   .��6   Attack6'   �� 5      $��5q�6    �� Orientation$ 
Horizontal=�6O    � Minimum$ 0Q�6h    � Maximum$	 200Q�6t    � SmallChange$ 10Q�6�    � LargeChange$ 25Q�6�   $	��180��6�    � Value 6    ��  �� Path$ 
AttackTime�	 �� Mode$	 TwoWay=�6�   �� 5      $��5q�6   ��6   �� *AttackMessage+5      �� 5      $  
Horizontal=�6   .+�5      �� $	��5,0q�6   .��6%   Scale:6-   �� 5      $	��5,0q�6   $	��150��6n   ��6(   �� *Scales+
 �� SelectedItem
 6G   �� *SelectedScale+6n   5      �� 5      $	��5,0q�6   $��Snap Pitches:��6!   �� 5   
   $��5q�6   $	��100��6"   ��6/   �� *	Pitches+��5      �� 5      .R�5      � 5      ��5      �� 5       .R�5!      �� $��16(�6^   $��60��6l    6   �� *
Selected+��6>   �� *DisplayName+6l   5"      5$      �� 5%   
   $  
Horizontal=�6   .+�5&      �� $��5q�6   $	��100��6    ��6,   �� *ApplyCommand+.��6M   Apply6T   �� 5'      $��5q�6   $	��100��6    ��6,   �� *CancelCommand+.��6N   Cancel6V   5(      5)      �� 5*   
   
���   �$��4q�6%    �� CornerRadius$ 10��5+      $��Center=�6#   $��Center=�5,       �� Padding$ 20q�6,   
�������y�5-      �� *ProcessingMessageVisibility+._�5.      �� .+�5/      �� $��Processing...��6   $��20(�61   �� 50      $��Please Wait��6   $��Center=�6/   51      52      53      54      