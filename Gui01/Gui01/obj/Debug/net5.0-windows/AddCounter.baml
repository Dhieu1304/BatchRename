   M S B A M L   `   `   `  ����@  <Gui01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Gui01Gui01  5   	       Gui01.AddCounter   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Gui01     5   	     � Title$  
AddCounter��5   	   $	��350��6   $	��735��6)   .��5	      �� .+�5
   
   �� $��Add Counter��6   $��30(�6'   $��
ExtraBlack"�65   ���	#FF26B7C0 �� Left$	 251��6d   
 �� Top$ 31��6v   �� 5   
    �� Orientation$ 
Horizontal=�6   $ 84��6.   $	 117��6?   .+�5      �� $�� Start Value : ��6   $��20(�6/   �� 5      -   5         ��Name$ startVal��5      $��60��6(   $��25��63   $��0 0 30 0q�6?   5      �� 5      $��Step : ��6   $��20(�6'   �� 5      -   5        $ stepVal��5      $��60��6'   $��25��62   $��0 0 30 0q�6>   5      �� 5      $��NumofDigit : ��6   $��20(�6-   �� 5      -   5        $��numDigit��5      $��50��6'   $	�� 25��62   5      �� 5   
   $	 157��6   $	 149��6'   .+�5      �� -   5         ��Name$ errVal1��5      
���  ����6)   �� *
_status1+6C   5      �� 5   
   $	 319��6   $	 154��6'   .+�5      �� -   5        $ errVal2��5      
���  ����6)   �� *
_status2+6C   5      �� 5   
   $	 251��6   $	 278��6'   .+�5      �� -   5        $ errVal3��5      
���  ����6)   �� *
_status3+6C   5      �� 5   
   $ 
Horizontal=�6   $	 228��6.   $	 188��6@   .+�5      �� -   5        $��OKBtn��5      $��50��6"   $	��100��6.   $	��Top=�6:   ���	#FFBFC794$��20q�6}    �� 	IsDefault$
 True��6�   $
��Bold"�6�   ��5       �� 5!       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5"      � 	 � Color$	 Black��6'   � 5#      $	 	#FFBD1C1C��6'   
 � Offset$
 1Q�69   5$      .��5&      �� $��OK��6   $��20(�6&   66   5'      �� 5(      -   5        $��	CancelBtn��5(      $��50��6&   $	��100��62   $	��Top=�6>   ���	#FFBFC794$��20q�6�   $
 True��6�   $
��Bold"�6�   ��5)      �� 5*      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5+      � $	 Black��6'   � 5,      $	 	#FFBD1C1C��6'   $
 1Q�69   5-      .��5/      �� $��Cancel��6   $��20(�6*   6:   50      51      52      53      