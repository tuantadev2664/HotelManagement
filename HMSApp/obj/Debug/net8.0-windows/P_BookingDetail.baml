   M S B A M L   `   `   `  ����A  =HMSApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:HMSAppHMSApp  5          HMSApp.P_BookingDetail   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:HMSApp     5      _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         MaterialDesignBody#���   5   	   $��Regular"�5	   	   $��13(�5
   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont N� 
FontFamily# �  5   	    N� 
Background
 ����� N� Title$ P_BookingDetail��5      .��5      � $��Stretch=�6   $��Stretch=�6)    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5"   
   �� 5#      $
��Auto �6   $��80��6,   �� 5$      $
��Auto �6   $	��100��6,   �� 5%      $
��Auto �6   $��80��6,   �� 5&      $��* �6   .+�5)   
   ��  $  MaterialDesignSubtitle1TextBlock#��[ 6   $��Booking Detail��6N   $��0��6d   $��4��6q   $��	0,10,0,10q�6�   $��20(�6�   $
��Bold"�6�   $��Center=�6�   $	��130��6�   �� 5,   
   #��[ 6   $��Booking Reservation Id��6N   $��1��6l   $��0��6y   $��5q�6�   �� 5-   
   -   5         ��Name$ tbBookingReservationId��5-      $	��200��62   ${�False��6A   $��1��6S   $��1��6`   $��5q�6p   �� 5/   
   #��[ 6   $��Room Number��6N   $��2��6a   $��0��6n   $��5q�6~   �� 50   
   -   5        $ tbRoomNumber��50      $	��200��6(   ${�False��68   $��2��6J   $��1��6W   $��5q�6g   �� 52   
   #��[ 6   $��Description��6N   $��3��6a   $��0��6n   $��5q�6~   �� 53   
   -   5        $ tbDescription��53      $	��200��6)   ${�False��68   $��3��6J   $��1��6W   $��5q�6g   �� 55   
   #��[ 6   $��Max Capacity��6N   $��4��6b   $��0��6o   $��5q�6   �� 56   
   -   5        $ tbMaxCapacity��56      $	��200��6)   ${�False��68   $��4��6J   $��1��6W   $��5q�6g   �� 58   
   #��[ 6   $��Status��6N   $��5��6\   $��0��6i   $��5q�6y   �� 59   
   -   5        $ tbStatus��59      $	��200��6$   ${�False��63   $��5��6E   $��1��6R   $��5q�6b   �� 5=   
   #��[ 6   $��	Room Type��6N   $��7��6_   $��0��6l   $��5q�6|   �� 5>   
   -   5        $ 
tbRoomType��5>      $	��200��6&   ${�False��65   $��7��6G   $��1��6T   $��5q�6d   �� 5A   
   #��[ 6   $��
Start Date��6N   $��1��6`   $��2��6m   $��5q�6}   �� 5B   
   -   5        $ tbStartDate��5B      $	��200��6'   ${�False��66   $��1��6H   $��3��6U   $��5q�6e   �� 5D   
   #��[ 6   $��End Date��6N   $��2��6^   $��2��6k   $��5q�6{   �� 5E   
   -   5        $ 	tbEndDate��5E      $	��200��6%   ${�False��65   $��2��6G   $��3��6T   $��5q�6d   �� 5G   
   #��[ 6   $��Number of Date��6N   $��3��6d   $��2��6q   $��5q�6�   �� 5H   
   -	   5        $ tbNumOfDate��5H      $	��200��6'   ${�False��66   $��3��6H   $��3��6U   $��5q�6e   �� 5J   
   #��[ 6   $��Actual Price��6N   $��4��6b   $��2��6o   $��5q�6   �� 5K   
   -
   5        $ tbActualPrice��5K      $	��200��6)   ${�False��68   $��4��6J   $��3��6W   $��5q�6g   �� 5M   
   #��[ 6   $��Price Per Date��6N   $��5��6d   $��2��6q   $��5q�6�   �� 5N   
   -   5        $ tbPricePerDate��5N      $	��200��6*   ${�False��6:   $��5��6L   $��3��6Y   $��5q�6i   �� 5S   
   $��8��6   $��4��6"    �� Orientation$ 
Horizontal=�66   $��Center=�6O   $��5q�6l   $	��320��6w   .+�5T      �� -   5        $��Continue booking��5T      $��30��6L   $��5q�6Y   �� 5U      -   5        $��Update��5U      $��30��6&   $��5q�6E   �� 5V      -   5        $��Delete��5V      $��30��6&   $��5q�6E   5W      �� 5Y   
   $��9��6   $��4��6"   $ 
Horizontal=�66   $��Center=�6O   $��5q�6l   $	��700��6w   .+�5Z      �� -   5        $��Search by RoomNumber��5Z      $��30��6S   $��10q�6_   �� 5[      -   5        $ tbSearchbyText��5[      $	��100��6.   )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Search��6=   $
{�True��6e   $��4��6v   $��1��6�   $��5q�6�   �� 5]      -   5        $��Complete/Save Booking��5]      $��30��6R   $��10q�6^   $	��200��6j   �� 5^      -   5        $ tb_TotalPrice��5^      $	��100��6.   $	 Total Price��6>   ${�False��6k   $��4��6}   $��1��6�   $��5q�6�   5_      &   System.Windows.Controls.DataGrid  5a   
   -   5        
  Name$
 dataGrid��5a      $��10��5b      $��4��6      AutoGenerateColumns$ False��5c         CanUserAddRows$ False��5d         HeadersVisibility$	 All=�5e         SelectionUnit$ FullRow=�5g         AlternatingRowBackground
 �����   
IsReadOnly$
 True��5i      $��10,10,10,10q�5j      ��5f      �� *BookingDetailVMs+ �� UpdateSourceTrigger$ PropertyChanged=�   Columns 5k      0  *System.Windows.Controls.DataGridTextColumn  5l      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Start Date��6C   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *	StartDate+6C     5m      $ End Date��6A    6%   �� *	EndDate+6A     5n      $
 Room��6T    6%   �� *RoomInformation.RoomNumber+6T     5o      $ Price Per Date��6Z    6%   �� *" RoomInformation.RoomPricePerDate+6Z     5p      $ Number Of Day��6E    6%   �� *NumberOfDay+6E     5q      $ Actual Price��6E    6%   �� *ActualPrice+6E   5s      5�      5�      