   M S B A M L   `   `   `  ����Y  UWeißer Lotus Desktop Software, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Weißer_Lotus_Desktop_SoftwareWeißer_Lotus_Desktop_Software  5   	   .    (Weißer_Lotus_Desktop_Software.StockForm   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:Weißer_Lotus_Desktop_Software     5   	   ] YXceed.Wpf.Toolkit.NET5, Version=4.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  Weißer Lotus��5	   	   $	��450��6   $	��800��6+    � Icon$# Images/Weißer_Lotus_Logo.ico��5
   	   
���   �
������� � WindowStyle$
 None=�5   	    � AllowsTransparency$
 True��6   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   �� -   5        $��0��5      
���   �._�5      ]� $��False��6   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $#��Images/Weißer_Lotus_Logo.ico��6   $��45��6B   $��34��6M    J� RenderTransformOrigin$ 0.472,1.115&�6Y   �� 5      $��Weißer Lotus��6    
������� �� Padding$ 7q�6G   $	��108��6S   �� 5      -   5        $��
Startseite��5      
���   �
�������
�������$��1q�6�   �� 5      -   5        $��Stock Price List��5      
���   �
�������
�������$��1q�6�   �� 5      -   5        $��Amortisationsdauer��5      
���   �
�������
�������$��1q�6�   5      �� 5      $ 
Horizontal=�6   $��Right=�66   .+�5      �� -   5        $��_��5      $��30��6)   
���   �
�������6d   �� 5      -   5        $	��□��5      $��30��6)   
���   �
�������6d   �� 5      -   5        $��X��5      $��30��6)   
���   �
�������6a   5       5!      5"      � 5$   
   $��1��6   $��10q�6    5%      �� 5&      $
��Auto �6    �� 5'      $
��Auto �6    �� 5(      $
��Auto �6    �� 5)      $
��Auto �6    �� 5*      $
��Auto �6     � ColumnDefinitions 5,      �� 5-      $
��Auto �6#   �� 5.      $��* �6#   .+�51      �� $��0��6   $��2��6!   $#��Images/Weißer_Lotus_Logo.ico��65   $	��100��6[   $	��100��6g   $��Center=�6t   (  "Xceed.Wpf.Toolkit.WatermarkTextBox  53      -   5        	  Name$	 stockNameTextBox��53   A   $��1��6$   $��1��61   
   	Watermark$
 Enter stock name��6[     54      -	   5        $	 tickerSymbolTextBox��54   A   $��2��6$   $��1��61   $
 Enter the ticker symbol��6^     55      -
   5        $	 targetPriceTextBox��55   A   $��3��6$   $��1��61   $
 Enter the target price��6]   �� 57      -   5        $��4��57      $��1��6"   $��Submit��62   6C   58      5:      5;      