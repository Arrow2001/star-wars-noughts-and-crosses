   M S B A M L   `   `   `  ����C  ?StarWars, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:StarWarsStarWars  5   	       StarWars.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:StarWars     5   	     � Title$%  Noughts and Crosses (Star Wars)��5   	   $	��320��61   $	��350��6>    � 
ResizeMode$ NoResize=�5	   	    � WindowStyle$ SingleBorderWindow=�5
   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   (� $��0��6    (� Stretch$ Uniform=�6"   .��5      � -   5         �Name$ GameGrid��5      $	��300��6%   $	��300��61   5      �� 5   
   $��1��6   $��10q�6%   $��Center=�61   .+�5      	� -   5         	�Name$ SPRadioButton��5       	� 	GroupName$ GameMode��61   ��5      �� 5      
���   � �� Padding$ 5q�60   ._�5      �� $��Single Player��6$   
�������$��Center=�6L   $��15(�6i   5      5      	� 5      -   5        $ TwoPlayerRadioButton��5      $ GameMode��68   ��5      �� 5       
���   �$ 5q�60   ._�5!      �� $��2 Player��6$   
�������$��Center=�6G   $��15(�6d   5"      5$      5%      5&      ��5)      �� 5*   
   	 �� ImageSource$	 /Images/stars.png��6   
 j� Stretch$
 UniformToFill=�65   5,      