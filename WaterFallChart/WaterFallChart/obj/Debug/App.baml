   M S B A M L   `   `   `  ����D  @瀑布图, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WaterFallChartWaterFallChart  5          WaterFallChart.App   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      .localclr-namespace:WaterFallChart     5        �� 	Resources  5         Btn.Wnd.NormalStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name J� SnapsToDevicePixels ��Name �� Triggers	 P� Property
 P� Value �� 
TargetName  Btn.Wnd.CloseStyle �� BasedOn  WndIcon.Close.12px L� Drawing � Geometry �� 
StartPoint �� EndPoint
 � Pen >� Brush >� 	Thickness��%v  &	        &	     7   &	 c    �� 5   
   " d�6,   .�5	      ��  �@�FocusVisualStyle 61   Z� �� 5
       � �� �	#4CFFFFFF6+   �� 5       � �� 5      �� 5      " d�6&   .R�5      �� $ bdrContainer��6!    . #��z��5      ._�5      �� $ contentPresenter��6/   |�.  $��Center=�5   +   $��Center=�6F   ��.  . 5   F   5       5      P� 5      	 �@J�IsMouseOver
 .  . �5   "   �� $ bdrContainer��6?    � ��
 ���� 6Y   5      5      5      5      �� 5   
   " d�6+   8   .�5       ��  � �� �	#FFC946466+   5!      L� 5#   
    5$      � 5%       5&      � 5'      .��5(      �� $	 0,0&�6+   $ 12,12&�6<   �� 5)      $
 0,12&�6+   $
 12,0&�6=   5*       5,      >� 5-      
 �����$ 2Q�6,   5/      51      52      53      