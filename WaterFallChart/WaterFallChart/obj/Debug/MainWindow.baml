   M S B A M L   `   `   `  ����D  @瀑布图, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WaterFallChartWaterFallChart  5   	       WaterFallChart.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WaterFallChart     5   	     � Icon$  Icon.ico��64    � WindowState$ Normal=�5   	    � WindowStyle$
 None=�6    � AllowsTransparency .  � Title$ 
MainWindow��5   	   $	��480��6   $	��800��6)   
������  � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      �� 
�������$��1q�6     �� CornerRadius$ 6��64   
���   � J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         Opacity$	 0.6Q�6   	   ShadowDepth$	 0Q�6-   
   
BlurRadius$
 4Q�6=   ._�5   
   � -   5         �Name$ GdRoot��5       � RowDefinitions 5      �� 5      $��36 �6    �� 5      �� 5      $��30 �6    .+�5      � -   5        $ GdHeader��5      .+�5      �� -   5         ��Name$ 	BdrHeader��5   C   
���   �$ 5,5,0,0��6,   
�������$��0,0,0,1q�5   -    J� Opacity$	 0.5Q�6G   �� 5      $��	瀑布图��6   $
��Left=�6'   $��Center=�6B   
�������$��20(�5      $��10,0,0,0q�6*   d� 5      -   5         d�Name$ BtnClose��5   #   $��36��5         Btn.Wnd.CloseStyle#��[  6*   $��Right=�6V   .��5      �� $��12��6    $��12��6+     WndIcon.Close.12px#��[ 67   5      5      � 5      $��1��6   
���   �$��0,18,0,0q�63    � ColumnDefinitions 5       �� 5!      �� 5"      �� 5#      �� 5$      �� 5%      .+�5'      �� -   5        $ 	BdrChart1��5(      
������ $��Center=�5'   2   $��Center=�6O   $��1��6j   ._�5)      �� .+�5*         WaterFallChart.IconMenu     	IconBrush
 �����   
FocusBrush �	#FFF56F61   IconSize$ 80Q�5+   !   ���	#26FFFFFF$	��120��6F   $	��120��6R      IconData$� �M17.45,15.18L22,7.31V19L22,21H2V3H4V15.54L9.5,6L16,9.78L20.24,2.45L21.97,3.45L16.74,12.5L10.23,8.75L4.31,19H6.57L10.96,11.44L17.45,15.18Z��5,   !   �� 5.      $��Center=�6$   $��0,20,0,0q�6A   $��
瀑布图1��6S   $��20(�5/   $   
�������62   50      51      �� 52      -   5        $ 	BdrChart2��53      
������ $��Center=�52   2   $��Center=�6O   $��3��6j   ._�54      �� .+�55        
 ����� �	#FFF56F61$ 80Q�56   !   ���	#26FFFFFF$	��120��6F   $	��120��6R   $� �M2,2H4V20H22V22H2V2M14,14.5L12,18H7.94L5.92,14.5L7.94,11H12L14,14.5M14.08,6.5L12.06,10H8L6,6.5L8,3H12.06L14.08,6.5M21.25,10.5L19.23,14H15.19L13.17,10.5L15.19,7H19.23L21.25,10.5Z��57   !   �� 58      $��Center=�6$   $��0,20,0,0q�6A   $��
瀑布图2��6S   $��20(�59   $   
�������62   5:      5;      5=      �� 5>      $
��Left=�6   $��Center=�63   $��2��6N   
�������$-��'让WPF火起来、活起来 - CrazyDuel��5?   +   $��	10,0,10,0q�5@      5A      5B      5C      