   M S B A M L   `   `   `  ����A  =HMSApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:HMSAppHMSApp  5      !    HMSApp.P_ReservationHistory   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:HMSApp     5      _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         MaterialDesignBody#���   5      $��Regular"�5	      $��13(�5
      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignFont N� 
FontFamily# �  5       N� 
Background
 ����� N� Title$ P_ReservationHistory��5       � 	Resources 5a        BookingCardStyle �� 
TargetType �� Property �� Value3  -System.Windows.Media.Effects.DropShadowEffect	   
BlurRadius
   ShadowDepth   Opacity   Color  StatusChipStyle �� Triggers �� Binding �� Value��%�  &	       &	 R    �� 5b   
   " ��6)   .�5c      ��  � ��
 �����6+   �� 5d       �@��CornerRadius$ 8��6-   �� 5e       � ��$ 0,0,0,16q�6'   �� 5f       �@��Padding$ 16q�6(   �� 5g       �@J�Effect 5h        5i      $	 10Q�6'   $
 1Q�67   $	 0.2Q�5j   %   $ #000000��63   5l      5m      �� 5o   
   " ��6(   .�5p      ��  �@��CornerRadius$ 16��6-   �� 5q       �@��Padding$
 12,4q�6(    5r      �� 5s       6   �� *BookingStatus+ Pending6@   .a�5t      ��  � �� �#FFF3E063   �� 5u       � �� �#E651006=   5v      �� 5w       6   �� *BookingStatus+ 	Confirmed6@   .a�5x      ��  � �� �#E8F5E963   �� 5y       � �� �#1B5E206=   5z      �� 5{       6   �� *BookingStatus+ 	Cancelled6@   .a�5|      ��  � �� �#FFEBEE63   �� 5}       � �� �#B71C1C6=   5~      5�      5�      .��5�      �   MaterialDesignBackground#���  6    � RowDefinitions 5�   
   �� 5�      $
��Auto �6   �� 5�      $
��Auto �6   �� 5�      $��* �6   .+�5�   
   #  MaterialDesignThemes.Wpf.Card  $��0��6   $��
16,16,16,8q�6+   .��5�      �  � ColumnDefinitions 5�      �� 5�      $��* �6'   �� 5�      $
��Auto �6'   .+�5�      �� $!��Booking Reservation History��6    $  MaterialDesignHeadline5TextBlock#��[ 5�      $��Center=�5�      $��Center=�5�      $��16q�5�      �� 5�      -   5        $��1��5�        MaterialDesignIconButton#��[ 5�       � ToolTip$ Refresh��5�      $��8q�5�      .��5�      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Refresh=�6.   $��Center=�6=   5�      5�      5�      �� 5�   
   $��1��6   $��1��6"    �� Orientation$ 
Horizontal=�66   $��Center=�6O   $��5q�6l   .+�5�      �� -   5        $��Search by BookingID��5�      $��30��6F   $��10q�6R   �� 5�      -   5         ��Name$ tbSearchbyText��5�      $	��100��6.   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Search��6=   $
{�True��6e   $��4��6v   $��1��6�   $��5q�6�   5�      �� 5�   
   $��2��6   $��
16,8,16,16q�6$   $
��Auto=�5�      .��5�      �� ��6   �� *bookingReservationList+��5�      �� 5�      .R�5�        $��0,0,0,16q�6.      UniformCornerRadius$ 8Q�6@   .��5�      9�  9� 
IsExpanded$
 True��5�   &   ��5�   '   �� *BookingReservationID+ �� StringFormat$ Booking #{0}��.��5�   "   �� $��16q�6-   .+�5�   &   � $��0,0,0,16q�6+    5�   *   �� 5�   .   $��* �6?   �� 5�   .   $
��Auto �6?   �� 5�   .   $
��Auto �6?   .+�5�   *   �� $��0��65   $ 
Horizontal=�5�   3   .+�5�   .     $ Calendar=�6F   $��Center=�5�   D   $��0,0,8,0q�5�   D   �� 5�   .   $��Center=�5�   6   ��5�   8   �� *BookingDate+$ Booking Date: {0}��5�   6   5�   +   �� 5�   *   $��3��61   #��[ 5�   1   ._�5�   .   �� $��Medium"�5�   6   ��5�   8   �� *BookingStatus+5�   6   5�   +   �� 5�   *   -   5        $��1��5�   1     MaterialDesignFlatButton#��[ 5�   &   ��5�   &   �� * DataContext.EditBookingCommand+ �� RelativeSource ��  �� AncestorType ItemsControl��5�   &   �� *BookingReservationID+.��5�   .   �� $ 
Horizontal=�69   .+�5�   2     $ Remove=�6J   $��0,0,8,0q�6X   �� 5�   2   $��Remove��6<   5�   /   5�   +   5�   '   �� 5�   &   $ 
Horizontal=�61   $��0,0,0,16q�5�   /   .+�5�   *     $ CurrencyUsd=�6B   $��Center=�5�   @   $��0,0,8,0q�5�   @   �� 5�   *   $��Medium"�5�   2   $��16(�5�   2   ��5�   4   �� *
TotalPrice+$ Total: ${0:N2}��5�   2   5�   '     5�   &   $ 4Q�6:   ���#F5F5F5.��5�   *   �� $��0q�5�   1   
������ $	��300��5�   1   ��5�   3   �� *BookingDetails+ �� View 5�   .   �� 5�   2   .P�5�   6   �� $
��Room��6E    �� Width$	 100��5�   C    �� CellTemplate 5�   :   �� 5�   >   .R�5�   B   �� $ 
Horizontal=�6M   .+�5�   F     $
 Home=�5�   I   $��0,0,8,0q�5�   I   �� 5�   F   ��5�   I   �� *RoomID+5�   C   5�   ?   5�   7   �� 5  6   $��Check In��6E   $	 150��5  C    5  :   �� 5  >   .R�5  B   �� $ 
Horizontal=�6M   .+�5  F     $ CalendarCheck=�5  I   $��0,0,8,0q�5  I   �� 5	  F   ��5
  I   �� *	StartDate+$ d��5  C   5  ?   5  7   �� 5  6   $��	Check Out��6E   $	 150��5  C    5  :   �� 5  >   .R�5  B   �� $ 
Horizontal=�6M   .+�5  F     $ CalendarRemove=�5  I   $��0,0,8,0q�5  I   �� 5  F   ��5  I   �� *	EndDate+$ d��5  C   5  ?   5  7   �� 5!  6   $��Price��6E   $	 120��5"  C    5#  :   �� 5$  >   .R�5%  B   �� $ 
Horizontal=�6M   $��Right=�5&  K   .+�5'  F     $ CurrencyUsd=�5(  I   $��0,0,4,0q�5)  I   �� 5*  F   ��5+  I   �� *ActualPrice+$ {0:N2}��5-  C   5.  ?   50  7   51  3   53  +   54  '   55  #   56     57     58     5:     5;     5<     5?     