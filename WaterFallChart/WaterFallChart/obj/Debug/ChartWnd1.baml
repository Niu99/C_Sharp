   M S B A M L   `   `   `  ����D  @瀑布图, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WaterFallChartWaterFallChart  5   	       WaterFallChart.ChartWnd1   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WaterFallChart     5   	     � WindowState$  Normal=�5   	    � WindowStyle$
 None=�6    � AllowsTransparency .  � Title$ 
MainWindow��5   	   $	��480��6   $	��800��6)   
������  � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      �� 
�������$��1q�6     �� CornerRadius$ 6��64   
���   � J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         Opacity$	 0.6Q�6      ShadowDepth$ 0Q�6-   	   
BlurRadius$	 4Q�6=   ._�5   
   � -   5        
 �Name$
 GdRoot��5       � RowDefinitions 5      �� 5      $��36 �6    �� 5      �� 5      $��30 �6    .+�5      � -   5        $
 GdHeader��5      .+�5      �� -   5         ��Name$ 	BdrHeader��5   C   
���   �$ 5,5,0,0��6,   
�������$��0,0,0,1q�5   -    J� Opacity$	 0.5Q�6G   �� 5      $��
瀑布图1��6   $
��Left=�6(   $��Center=�6C   
�������$��20(�5      $��10,0,0,0q�6*   d� 5      -   5         d�Name$ BtnClose��5   #   $��36��5         Btn.Wnd.CloseStyle#��[  6*   $��Right=�6V   .��5      �� $��12��6    $��12��6+     WndIcon.Close.12px#��[ 67   5      5      � 5      $��1��6   
���   �$��0,18,0,0q�63   .+�5       � -   5        $
 GdMain��5       .+�5!      � -   5        $
 GdAxis��5!      � 5"      -   5        $
 	GdContent��5"      $��40,10,10,20q�6.   .+�5#      �� -   5         ��Name$ ImgColorAreaLeft��5#   E   $
��Left=�6    $��8��6;    J� RenderTransformOrigin$ 0.5 0.5&�5$   $   $
��Fill=�6D   z�5%      �� 5&   "    �� Angle$	 180Q�62   5(      �� 5)      $��8��6$   $��Right=�6.   ��5*      !� 5+   "    !� Visual 6.   ��  �� ElementName$ ImgColorAreaLeft��5-      (� 5.      -	   5         (�Name$ VbxContainer��5.   "    (� Stretch$
 Fill=�68   $	��8,0q�6G   .��5/      � -
   5        $
 GdContainer��5/   =   $
��1000��6#   $	��500��60   .+�50   "   �� -   5        $ ImgMain��50   (   51      52      53      54      55      56      57      58      