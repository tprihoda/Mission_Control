   M S B A M L   `   `   `  ���� >  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GUIGUI      GUI.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     #localclr-namespace:GUI     $
��1080��$
��1920��  � WindowStartupLocation$  CenterScreen=� � WindowState$ 	Maximized=� � 	Resources    NoHighlight �� 
TargetType �� Property �� Value J� SnapsToDevicePixels �� StrokeDashArray �� 
TargetType	 ��Name
 ��Name �� ContentStringFormat �� ContentStringFormat �� Triggers P� Property P� Value �� 
TargetName��%�  &	        �� " ��.���  �@�FocusVisualStyle �� .���  � �� �� .R��� $��2q� . #��� ��$��1��$	 1 2R���  � �� �	#FFDDDDDD��  � �� �	#FF707070��  � ��# � ����  � ��$ 1q���  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R��� $	 border��#��z��#��z��#��z�� . ._��� $
 contentPresenter��#��z��#��z��# z |�.  #��z��#��z����. # z #��z�� P�  �@��IsDefaulted . . ��� $ border��# � �� � ��P�  � �� . . ��� $ border�� � �� �	#FFC4E5F6�� $ border�� � �� �	#FF2C628BP�  �@d�	IsChecked$
 TrueY�. ��� $ border�� � �� �	#FFBCDDEE�� $ border�� � �� �	#FF245A83P�  � {� .  . ��� $ border�� � �� �	#FFF4F4F4�� $ border�� � �� �	#FFADB2B5��  � �� �	#FF838383.���  � ColumnDefinitions �� $��20 ��� $��* ��� $��277.5 ��� $��277.5 ��� $	��750 ��� $��277.5 ��� $��277.5 ��� $��* ��� $��20 � � RowDefinitions �� $��1 ��� $��* ��� $	��148 ��� $	��148 ��� $	��148 ��� $	��148 ��� $	��148 ��� $	��148 ��� $	��148 ��� $��* ��� $��20 �.+��� -    ��Name$ Caution_Button��#��[  $��Caution��$��2��$��Center=�$��2��$��Center=�$	��176��$��62���� -   $ Warning_Button��#��[  $��0,0,10,0q�$��Warning��$��3��$��Center=�$��2��$��Center=�$	��176��$��64���� $��0��$��4��$��3��$	��Top=�$��Stretch=�
���   �$��2���� -   $ Approach_Button��#��[  $��Approach Config��$��2��$��Center=�$��3��$��Center=�$	��176��$��62���� -   $ Break_Button��#��[  $��0,0,10,0q�$��Break��$��3��$��Center=�$��3��$��Center=�$	��176��$��64���� $��0��$��4��$��4��$	��Top=�$��Stretch=�
���   �$��2���� $��State:��$��Center=�$��Center=�$��2��$��4��$��40(��� $��Center=�$��Center=�$��3��$��4��
���   �$��1q�$��0,0,10,0q� �� Padding$ 10q�._�(�  (� StretchDirection$ DownOnly=� (� Stretch$ Uniform=�.���� -    ��Name$ State_Display��$��PlaceHolder��$��40(��� $��0��$��4��$��5��$	��Top=�$��Stretch=�
���   �$��2���� -   $ Fill_Button��#��[  $
��Fill��$��2��$��Center=�$��5��$��Center=�$	��176��$��62���� -   $ Fill_Disconnect_Button��#��[  $��Fill Arm Disconnect��$��2��$��Center=�$��6��$��Center=�$	��176��$��64���� -   $ Door_Button��#��[  $��Fill Door Close��$��2��$��Center=�$��7��$��Center=�$	��176��$��62���� -	   $ Launch_Button��#��[  $��Launch��$��2��$��Center=�$��8��$��Center=�$	��176��$��64���� -
    ��Name$ Sequence_Stack��$��0,0,10,0q�$��3��
�������$	��500��$	��300��$��Center=�$��5��$��4��$��Center=��� -   $ Pad_Connect_Button��$��Pad Connect��$��5��$��Center=�$��2��$��Center=�$	��176��$��62���� -   $ Radio_Connect_Button��$��Raido Connect��$��6��$��Center=�$��2��$��Center=�$	��176��$��62���� $��5��$��4��$��3��$	��Top=�$��Stretch=�
���   �$��2��� $��5��$��2��$��3�� �� $��1* ��� $��1* ��� $��1* � �� $��1* ��� $��2* �.+��� $��0��$��3��$��0��$��Gyroscope Data��$��Center=�$��Center=�$��25(��� $��0��$��1��$��Center=�$��Center=�.+��� $��X��$��Center=�$��25(��� $	��N/A��$��Center=�$��25(��� $��1��$��1��$��Center=�$��Center=�.+��� $��Y��$��Center=�$��25(��� $	��N/A��$��Center=�$��25(��� $��2��$��1��$��Center=�$��Center=�.+��� $��Z��$��Center=�$��25(��� $	��N/A��$��Center=�$��25(��� $��5��$��4��$��4��$	��Top=�$��Stretch=�
���   �$��2���� $��5��$��4��$��Center=�$��Center=�.+��� $��Velocity��$��Center=�$��30(��� $	��N/A��$��Center=�$��30(��� $��6��$��4��$��Center=�$��Center=�.+��� $��Acceleration��$��Center=�$��30(��� $	��N/A��$��Center=�$��30(��� $��5��$��4��$��5��$	��Top=�$��Stretch=�
���   �$��2���� $��5��$��5��$��Center=�$��Center=�.+��� $��Latitude��$��Center=�$��30(��� $	��N/A��$��Center=�$��30(��� $��6��$��5��$��Center=�$��Center=�.+��� $��	Longitude��$��Center=�$��30(��� $	��N/A��$��Center=�$��30(��� $��5��$��4��$��6��$	��Top=�$��Stretch=�
���   �$��2��   GUI.WpfGraphControl  -     Name$ Graph��$��10q�$��5��$��4��$��6��$��3��   
Controller �� *
Controller+�� $��5��$��4��$��4��$	��Top=�$��Stretch=�
���   �$��2���� $��3��$��2��$��8��$��Stretch=�$��Right=�
���   �$��2���� -    ��Name$ Rocket_Image��$��Center=�$��Center=�$
��1080��$��4��$��2��$��7��$	��640���� -   $ 
Fill_Valve��$��Center=�$��Center=�$��60��$��60��$��205,-31,0,0q�$��4��$��2��$��7���� -   $ 	Glow_Plug��$��Center=�$��Center=�$��30��$��30��$��-95,105,0,0q�$��4��$��2��$��7���� -   $ 	Tank_Vent��$��Center=�$��Center=�$��27��$��26��$��-224,-720,0,0q�$��4��$��2��$��7�� J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~��� �� ��  �� Angle$	 -90Q�T� �� -   $ Propane_Valve��$��Center=�$
��Left=�$��47��$��47��$��101,100,0,0q�$��4��$��2��$��7��$ 0.5,0.5&�z�V� .~��� �� �� $	 -90Q�T� �� -   $ Fill_Vent_Valve��$��Center=�$��Center=�$��27��$��26��$��305,-135,0,0q�$��4��$��2��$��7��$ 0.5,0.5&�z�V� .~��� �� �� $	 -90Q�T� �� -   $ Servo_element��$��37��$��37��$��-163,15,0,0q�$��4��$��2��$��7���� -   $ Contact��$��35��$��35��$��
90,-31,0,0q�$��4��$��2��$��7���� -   $ Tank_Level_Image��$	��147��$	��400��$��-170,-270,0,0q�$��4��$��2��$��7���� $��4��$��5��$��650,60,20,60q�
���   �$��1q�$ 2q�._��� $��15,0,0,0q�$
��Left=�$��Center=�.+��� -   $ 
T1_Display��$��T1: N/A���� $��4��$��6��$��400,0,270,100q�
���   �$��1q�$ 2q�._��� $��15,0,0,0q�$
��Left=�$��Center=�.+��� -   $ 
P4_Display��$��P4: N/A���� -   $ 
T5_Display��$��T5: N/A���� $��4��$��7��$��400,110,270,10q�
���   �$��1q�$ 2q�._��� $��15,0,0,0q�$
��Left=�$��Center=�.+��� -   $ 
T6_Display��$��T6: N/A���� $��4��$��5��$��110,0,560,100q�
���   �$��1q�$ 2q�._��� $��15,0,0,0q�$
��Left=�$��Center=�.+��� -   $ 
P3_Display��$��P3: N/A���� -   $ 
T4_Display��$��T4: N/A���� $��4��$��2��$��4��$��570,120,100,130q�
���   �$��1q�$ 2q�._��� $��15,0,0,0q�$
��Left=�$��Center=�.+��� -   $ 
P1_Display��$��T1: N/A��$
��Left=��� -   $ 
T2_Display��$��T2: N/A���� $��4��$��3��$��400,0,270,100q�
���   �$��1q�$ 2q�._��� $��15,0,0,0q�$
��Left=�$��Center=�.+��� -   $ 
P2_Display��$��P2: N/A���� -    $ 
T3_Display��$��T3: N/A���� $��0,0,0,0q�$��4��$��2��$��8��$��Stretch=�$��Right=�
���   �$��2������  �� Color$
 Gray��