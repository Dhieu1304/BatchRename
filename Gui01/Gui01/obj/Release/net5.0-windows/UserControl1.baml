   M S B A M L   `   `   `  ���� @  <Gui01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Gui01Gui01      Gui01.UserControl1   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     %localclr-namespace:Gui01     .���� 
�������$��Center=�$	��600��.+��� .+��� ���	#FFACACAC$��0 0 0 3q�._�]� $��20�����	#FFDDDDDD.+�o� $	��Top=�.@�m� $
��File��.@�m� -   $��Save Project��m� -   $��Load Project��m� -   $��Load Lasted Preset...��m� -   $��Load Lasted State...��m� -   $
��Exit��m� -   $��About���� $��Stretch=�  �� Orientation$  
Horizontal=�$
��Auto��$��Stretch=�.+��� $	��300��$  Vertical=�.+��� $  
Horizontal=�$��0 5 0 5q�.+��� -   $��comboBoxToChooseRule�� �� Text$ 	Operation��$	��211��$��25��$��5 0 0 0q� �� Left$ 10��
 �� Top$ 36������ .R��� ���� �� -   $	��Add��$��64��$��37��$��5 0 0 0q�.���� $��images/add.jpg�� �� BitmapScalingMode$ HighQuality=� J� OpacityMask �	#FFB31111�� $  
Horizontal=�.+��� -	    ��Name$ Up��$��30��$��30��$��5q�.���� $��images/up_arrow.png��$ HighQuality=��� -
   $
 Down��$��30��$��30��$��5q�.���� $��images/down_arrow.png��$ HighQuality=��� -   $ UpMax��$��30��$��30��$��5q�.���� $��images/m_up_arrow.png��$ HighQuality=��� -   $ DownMax��$��30��$��30��$��5q�.���� $��images/m_down_arrow.png��$ HighQuality=��� -   $ 
SavePreset��$��30��$��30��$��5q�.���� $��images/save_file_icon.png���� -   $ 
LoadPreset��$��30��$��30��$��5q�.���� $��images/open_file_icon.png���� -   $ RemovePreset��$��30��$��30��$��5q�.���� $��images/RemoveAll.jpg��$ HighQuality=��� -    ��Name$ 	listRules��$	��413��$��1q�$��Hidden=�$��Hidden=�$��	10 0 0 10q�$��5 0 0 0q� � 	Resources    taskContextMenu��%>   &	        �� .@�m� -   $��Delete��m� -   $
��Edit������ 	 �� 
TargetType"	 ��.��� 
 �� Property
 �@�ContextMenu �� Value# [  ���� .R��� ���� �� -   $ 
startBatch��
���   �$��5q�$��Stretch=�$��Stretch=����	#FF424374$��3,3,3,3q� ��%:   '��       �� "	 ��.��� 
 �@��CornerRadius$ 10������  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ Black�� � Offset$ 0Q�� $ 	#FF39B1B9��$ 0.471Q�.��� $��0 5 0 5q�.+��� $
��Wrap=�$��Start Batch��$��SemiBold"�$��25(�$��0,3,0,0q��� $��images/Icon.png��$ HighQuality=�$��3,2,0,0q�$��71��$��42���� $	��690��.+��� $  
Horizontal=�$��36��$��20 0 0 0q�.+��� -   $ LoadFile��$��	Load File��$��80��$��25��$��5,0,5,0q��� -   $ LoadAllFile��$��Load File +��$��80��$��25��$��5,0,5,0q��� -   $ 
LoadFolder��$��Load Folder��$��80��$��25��$��5,0,5,0q��� -   $ LoadAllFolder��$��Load Folder +��$��80��$��25��$��5,0,5,0q��� -   $ Preview��$��Preview��$��80��$��25��$��5,0,5,0q��� -   $ 	RemoveAll��$��
Remove All��$��80��$��25��$��5,0,5,0q��� -   $��listviewOfFiles��$	��526��$��4,0,-4,0q�$	��680�� �� View �� .P��� $	��No.�� �� Width$ 25�� �� DisplayMemberBinding �� *id+�� $��CurrentName��$	 190�� �� *	oldName+�� $��NewName��$	 190�� �� *	newName+�� $
��Path��$	 200�� �� *
filePath+�� $��Error��$ 80�� �� *err+ ��%)   &	        �� .@�m� -   $��Delete������ "	 ��.��� 
 �@�ContextMenu# [  ���� .R��� ���� 