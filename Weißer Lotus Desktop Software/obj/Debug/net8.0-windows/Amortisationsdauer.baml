   M S B A M L   `   `   `  ����Y  UWeißer Lotus Desktop Software, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Weißer_Lotus_Desktop_SoftwareWeißer_Lotus_Desktop_Software  5   	   7    1Weißer_Lotus_Desktop_Software.Amortisationsdauer   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:Weißer_Lotus_Desktop_Software     5   	     � Title$  Amortisationsdauer��5   	   $	��450��6$   $	��800��61    � Icon$# Images/Weißer_Lotus_Logo.ico��5	   	   
���   �
������� � WindowStyle$
 None=�5   	    � AllowsTransparency$
 True��6   .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      .+�5   
   �� -   5        
���   �
�������$��1q�5   i   ._�5      ]� $��False��6   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $#��Images/Weißer_Lotus_Logo.ico��6   $��45��6B   $��34��6M    J� RenderTransformOrigin$ 0.472,1.115&�6Y   �� 5      $��Weißer Lotus��6    
������� �� Padding$ 7q�6G   $	��108��6S   �� 5      -   5        $��
Startseite��5      
���   �
�������
�������$��1q�6�   �� 5      -   5        $��Stock Price List��5      
���   �
�������
�������$��1q�6�   �� 5      -   5        $��Amortisationsdauer��5      
���   �
�������
�������$��1q�6�   5      �� 5      $ 
Horizontal=�6   $��Right=�66   .+�5      �� -   5        $��_��5      $��30��6)   
���   �
�������6d   �� 5      -   5        $	��□��5      $��30��6)   
���   �
�������6d   �� 5      -   5        $��X��5      $��30��6)   
���   �
�������6a   5      5       5!      � 5"   
   $��1��6   $��Center=�6   $��Center=�67   .+�5#      �� $��
0,-24,0,24q�6   .+�5%      �� $#��Images/Weißer_Lotus_Logo.ico��6   $	��100��6>   $	��100��6J   �� 5'      $$��Geben Sie den Aktienpreis ein:��6   
�������6A   �� 5(      -   5         ��Name$ StockPriceTextBox��5(      �� 5*      $(��"Geben Sie die Jahresdividende ein:��6   
�������6E   �� 5+      -	   5        $ AnnualDividendTextBox��5+      �� 5-      $<��6Geben Sie das Dividendenwachstum ein (in Cent / Euro):��6   
�������6Y   �� 5.      -
   5        $ DividendGrowthTextBox��5.      �� 50      -   5        $��	Berechnen��50      
���   �
�������
�������$��1q�6�   �� 52      -   5        	 ��Name$	 ResultLabel��52      
�������6-   53      54      55      56      