   M S B A M L   `   `   `  ����A  =HMSApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:HMSAppHMSApp  5      &     HMSApp.P_ReservationHistoryAdmin   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:HMSApp     5      _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         MaterialDesignBody#���   5      $��Regular"�5	      $��13(�5
      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignFont N� 
FontFamily# �  5       N� 
Background
 ����� N� Title$ P_ReservationHistoryAdmin��5       � 	Resources 5        BookingCardStyle �� 
TargetType �� Property �� Value3  -System.Windows.Media.Effects.DropShadowEffect	   
BlurRadius
   ShadowDepth   Opacity   Color  StatusChipStyle �� Triggers �� Binding �� Value��%�  &	       &	 R    �� 5   
   " ��6)   .�5      ��  � ��
 �����6+   �� 5       �@��CornerRadius$ 8��6-   �� 5       � ��$ 0,0,0,16q�6'   �� 5       �@��Padding$ 16q�6(   �� 5       �@J�Effect 5        5      $	 10Q�6'   $
 1Q�67   $	 0.2Q�5   "   $ #000000��60   5      5      �� 5!   
   " ��6(   .�5"      ��  �@��CornerRadius$ 16��6-   �� 5#       �@��Padding$
 12,4q�6(    5$      �� 5%       6   �� *BookingStatus+ Pending6@   .a�5&      ��  � �� �#FFF3E063   �� 5'       � �� �#E651006=   5(      �� 5)       6   �� *BookingStatus+ 	Confirmed6@   .a�5*      ��  � �� �#E8F5E963   �� 5+       � �� �#1B5E206=   5,      �� 5-       6   �� *BookingStatus+ 	Cancelled6@   .a�5.      ��  � �� �#FFEBEE63   �� 5/       � �� �#B71C1C6=   50      52      53      .��55      �   MaterialDesignBackground#���  6    � RowDefinitions 56   
   �� 57      $
��Auto �6   �� 58      $
��Auto �6   �� 59      $��* �6   .+�5=   
   #  MaterialDesignThemes.Wpf.Card  $��0��6   $��
16,16,16,8q�6+   .��5>      �  � ColumnDefinitions 5?      �� 5@      $��* �6'   �� 5A      $
��Auto �6'   .+�5D      �� $!��Booking Reservation History��6    $  MaterialDesignHeadline5TextBlock#��[ 5E      $��Center=�5F      $��Center=�5G      $��16q�5H      �� 5K      -   5        $��1��5K        MaterialDesignIconButton#��[ 5L       � ToolTip$ Refresh��5M      $��8q�5N      .��5P      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Refresh=�6.   $��Center=�6=   5Q      5R      5S      �� 5U   
   $��1��6   $��1��6"    �� Orientation$ 
Horizontal=�66   $��Center=�6O   $��5q�6l   .+�5V      �� -   5        $��Search by BookingID��5V      $��30��6R   $��10q�6^   �� 5W      -   5         ��Name$ tbSearchbyText��5W      $	��100��6.   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Search��6=   $
{�True��6e   $��4��6v   $��1��6�   $��5q�6�   5X      �� 5[   
   $��2��6   $��
16,8,16,16q�6$   $
��Auto=�5\      .��5]      �� ��6   �� *bookingReservationList+��5^      �� 5_      .R�5`        $��0,0,0,16q�6.      UniformCornerRadius$ 8Q�6@   .��5a      9�  9� 
IsExpanded$
 True��5c   #   ��5a   '   �� *BookingReservationID+ �� StringFormat$ Booking #{0}��.��5d   "   �� $��16q�6-   .+�5g   &   �� $ 
Horizontal=�61   $��0,0,0,16q�5h   )   .+�5i   *     $ Person=�6B   $��Center=�5j   -   $��0,0,8,0q�5k   -   �� 5l   *   $��Medium"�5n   -   $��16(�5o   -   ��5l   4   �� *Customer.CustomerFullName+$ Customer: {0:N2}��5o   -   5p   '   � 5s   &   $��0,0,0,16q�6+    5t   *   �� 5u   .   $��* �6?   �� 5v   .   $
��Auto �6?   �� 5w   .   $
��Auto �6?   �� 5x   .   $
��Auto �6?   �� 5y   .   $
��Auto �6?   �� 5z   .   $
��Auto �6?   .+�5}   *   �� $��0��65   $ 
Horizontal=�5~   0   .+�5   .     $ Calendar=�6F   $��Center=�5�   A   $��0,0,8,0q�5�   A   �� 5�   .   $��Center=�5�   3   ��5�   8   �� *BookingDate+$ Booking Date: {0}��5�   3   5�   +   �� 5�   *   $��4��61   #��[ 5�   .   ._�5�   .   �� $��Medium"�5�   3   ��5�   8   �� *BookingStatus+5�   3   5�   +   �� 5�   *   -   5        $��1��5�   1     MaterialDesignFlatButton#��[ 5�   -   ��5�   -   �� * DataContext.EditBookingCommand+ �� RelativeSource ��  �� AncestorType ItemsControl��5�   -   �� *BookingReservationID+.��5�   .   �� $ 
Horizontal=�69   .+�5�   2     $
 Edit=�6J   $��0,0,8,0q�6V   �� 5�   2   $
��Edit��6<   5�   /   5�   +   �� 5�   *   -   5        $��2��5�   1   #��[ 5�   &   ��5�   &   �� * DataContext.EditBookingCommand+ ��  ItemsControl��5�   &   �� *BookingReservationID+.��5�   .   �� $ 
Horizontal=�69   .+�5�   2     $ Check=�6J   $��0,0,8,0q�6W   �� 5�   2   $��Confirm��6<   5�   /   5�   +   �� 5�   *   -   5        $��3��5�   1   #��[ 5�   )   ��5�   )   �� * DataContext.EditBookingCommand+ ��  ItemsControl��5�   )   �� *BookingReservationID+.��5�   .   �� $ 
Horizontal=�69   .+�5�   2     $ Remove=�6J   $��0,0,8,0q�6X   �� 5�   2   $��Remove��6<   5�   /   5�   +   5�   '   �� 5�   &   $ 
Horizontal=�61   $��0,0,0,16q�5�   ,   .+�5�   *     $ CurrencyUsd=�6B   $��Center=�5�   =   $��0,0,8,0q�5�   =   �� 5�   *   $��Medium"�5�   /   $��16(�5�   /   ��5�   4   �� *
TotalPrice+$ Total: ${0:N2}��5�   /   5�   '     5�   &   $ 4Q�6:   ���#F5F5F5.��5�   *   �� $��0q�5�   .   
������ $	��300��5�   .   ��5�   3   �� *BookingDetails+ �� View 5�   .   �� 5�   2   .P�5�   6   �� $
��Room��6E    �� Width$	 100��5�   @    �� CellTemplate 5�   :   �� 5�   >   .R�5�   B   �� $ 
Horizontal=�6M   .+�5�   F     $
 Home=�5�   F   $��0,0,8,0q�5�   F   �� 5�   F   ��5�   F   �� *RoomID+5�   C   5�   ?   5�   7   �� 5�   6   $��Check In��6E   $	 150��5�   @    5�   :   �� 5�   >   .R�5�   B   �� $ 
Horizontal=�6M   .+�5�   F     $ CalendarCheck=�5�   F   $��0,0,8,0q�5�   F   �� 5�   F   ��5�   F   �� *	StartDate+$ d��5�   C   5�   ?   5�   7   �� 5�   6   $��	Check Out��6E   $	 150��5�   @    5�   :   �� 5�   >   .R�5�   B   �� $ 
Horizontal=�6M   .+�5�   F     $ CalendarRemove=�5�   F   $��0,0,8,0q�5�   F   �� 5�   F   ��5�   F   �� *	EndDate+$ d��5�   C   5�   ?   5�   7   �� 5�   6   $��Price��6E   $	 120��5�   @    5�   :   �� 5�   >   .R�5   B   �� $ 
Horizontal=�6M   $��Right=�5  H   .+�5  F     $ CurrencyUsd=�5  F   $��0,0,4,0q�5  F   �� 5  F   ��5  F   �� *ActualPrice+$ {0:N2}��5  C   5	  ?   5  7   5  3   5  +   5  '   5  #   5     5     5     5     5     5     5     