   M S B A M L   `   `   `  ����I  EMGRMikolajczuk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:MGRMikolajczuk.ViewMGRMikolajczuk.View  5   	   (    "MGRMikolajczuk.View.EndOrderWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:MGRMikolajczuk.View     5   	     � Title$  Zakończ zamówienie��5   	   $	��450��6$   $	��450��61   $	��450��6=   $	��460��6M    � Icon$ ../Image/Icon.png��5	   	   ��5
      �� 5   
    �� ImageSource$ ../Image/back.jpg��6   .��5      �  � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $
��1.5* �6   �� 5      $��1* �6   .+�5   
   �� .+�5      �� -   5         ��Name$ TextBlockName��5      $��Nazwa��6/   $��30(�6<    �� TextAlignment$ Center=�6J      tbstyle#��[  6a   �� 5      -   5        $ TextBlockSum��5      $
��Suma��6.   $��25(�6:   $
��Bold"�6H   $ Center=�6Z   
���  ��6q   5      �� 5   
   $��1��6   ��5      �� 5      $��Rodzaj płatności��6   $��20(�64   #��[  6B   .��5      A�  A� Rows$ 2��6    A� Columns$ 2��6#   .+�5       	� -   5         	�Name$ CartRadioButton��5       $��Karta��67     myWhite#��[ 6G   	� 5!      -   5        $ CashRadioButton��5!      $��Gotówka��67   	 d� 	IsChecked$
	 TrueY�6I   #��[ 6Z   	� 5"      -   5        $ NoneRadioButton��5"      $��Koszt firmy��67   #��[ 6M   5#      5$      �� 5&   
   $��2��6   ��5'      �� 5(      $��Rabat��6   $��20(�6)   #��[  67   .��5*      A� $ 2��6   .+�5+      	� -   5        $ _0RabatRadioButton��5+      $��Brak rabatu��6:   $
	 TrueY�6P   #��[ 6w   	� 5,      -   5        $ _10RabatRadioButton��5,      $	��10%��6;   #��[ 6_   	� 5-      -   5        $ _20RabatRadioButton��5-      $	��20%��6;   #��[ 6_   	� 5.      -	   5        $ _30RabatRadioButton��5.      $	��30%��6;   #��[ 6_   	� 5/      -
   5        $ _50RabatRadioButton��5/      $��50%(Pracowniczy)��6;   #��[ 6l   50      51      A� 52   
   $��4��6   $ 2��6#   .+�53      �� -   5        
 ��Name$
 
BackButton��53      $��Wstecz��6)   $��20,20q�6L     ButtonShadow#��[ 6[   �� 54      -   5        $��Zakończ zamówienie��54      $��20,20q�6H   #��[ 6W   55      56      57      