   M S B A M L   `   `   `  ����   MiniBrowser    MiniBrowser.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  MiniBrowser v1.8��$	��350��$	��525�� � Icon$ sylveon.ico�� � 	Resources    
ButtonSize  BUG �� 
TargetType �� Property �� Value �� 
StartPoint �� EndPoint � Color	 � Offset  GBG  BOG  TBG��%�  &	        &	      &	 �     &	 O    &	     �40 ��� " ��.���  � ��$ Stretch=���  � ��$ Stretch=���  � �� �� $	 0,1&�$	 0,0&�.��� $
 Pink��$	 1Q�� $
 Pink��$	 -0Q�� $ 	LightBlue��$	 .5Q��� " ��.���  � ��$ 1q���  � �� �� $	 1,1&�$	 0,0&�.��� $ DarkGray��$	 0Q�� $ Black��$	 1Q��� " ��.���  � ��
 �������  � �� �� $	 1,1&�$	 0,0&�.��� $ LightSteelBlue��$		 1.5Q�� $ White��$	 .5Q�� $ LightSteelBlue��$
	 -0.5Q��� " ��.���  � �� �� $	 1,1&�$	 0,0&�.��� $ LightSteelBlue��$		 1.5Q�� $ White��$	 .5Q�� $ LightSteelBlue��$
	 -0.5Q�.��� .+�� $��Stretch=�$��Stretch=�
 � RowDefinitions
 �� -    ��Name$ ButtonSizes��#���   �� $��* �.+�� $��Stretch=�$��Stretch=� � ColumnDefinitions �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� -    ��Name$ btnUndo��#��[ $��0��$��0��$
��Undo���� -   $ btnRedo��#��[ $��1��$��0��$
��Redo���� -   $ 
btnRefresh��#��[ $��2��$��0��$��Refresh���� -   $ btnKissCartoon��#��[ $��3��$��0��$��Cartoon���� -   $ btnKissAnime��#��[ $��4��$��0��$��Anime���� -   $ 
btnYoutube��#��[ $��5��$��0��$��Youtube���� -   $ 	btnSearch��#��[ $��6��$��0��$��Custom��(  "System.Windows.Controls.WebBrowser  -	     Name$ Video��$��0��$��1��$��Stretch=�$��Stretch=�   Source$ http://google.com?�