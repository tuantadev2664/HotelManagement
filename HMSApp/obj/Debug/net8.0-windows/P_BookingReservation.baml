   M S B A M L   `   `   `  ����A  =HMSApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:HMSAppHMSApp  5      !    HMSApp.P_BookingReservation   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:HMSApp     5      _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5   	   $��Regular"�5	   	   $��13(�5
   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont N� 
FontFamily# �  5   	    N� 
Background
 ����� N� Title$ P_BookingReservation��5      .��5      � $��Stretch=�6   $��Stretch=�6)    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   .+�5   
   ��  $  MaterialDesignSubtitle1TextBlock#��[ 6   $��2��6N   $-��'Booking Reservation                    ��6b   $��0��5       $��0��6#   $��10q�63   $��20(�6?   $
��Bold"�6M   $��Center=�6_   � 5#   
   $��1��6   $��Center=�6   $��10q�69    5$      �� 5%      $	��125 �6#   �� 5&      $	��125 �6#   �� 5'      $	��125 �6#   �� 5(      $	��125 �6#   �� 5)      $	��125 �6#   .+�5,      (  "System.Windows.Controls.DatePicker  -   5        $��0��5,      $��5,5,0,5q�5-      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Start Date��5.      .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton$
 True��5/       ( $MaterialDesignFloatingHintDatePicker#��[ 50      $
��Left=�51   G   $	��120��6b     54      -   5        $��1��54      $��5,5,0,5q�55      $ End Date��56      $
 True��57      #��[ 58      59      �� 5<      -   5        $��2��5<      $��5q�5=      $��Center=�5>      $ Number of Pepole��5?       % !MaterialDesignFloatingHintTextBox#��[ 5@      5A      �� 5E      -   5        $��3��5E      $��5q�5F      $	��128��5G      .  (MaterialDesignThemes.Wpf.ColorZoneAssist	   Mode$	 SecondaryLight=�5H      $ PricePerDate��5I      $
 True��5J      
   
SuffixText$
 $��5K        SecondaryHueMidBrush   UnderlineBrush# �  5L       & "MaterialDesignFloatingHintComboBox#��[ 5M      .@�5O      �� $��0-100��5P      �� 5Q      $��100-200��5R      �� 5S      $��200-300��5T      �� 5U      $��300-400��5V      5W      �� 5Y      -   5        $��Search��5Y      $��5q�6'   $��4��62   6B   5Z      �� 5\   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��10q�6X   .+�5]      �� -   5        $��Booking��5]      $��5q�6;   5^      &   System.Windows.Controls.DataGrid  5`   
   -   5          Name$ dataGrid��5`      $��3��5a      $��2��6      AutoGenerateColumns$ False��5b         CanUserAddRows$ False��5c         HeadersVisibility$	 All=�5d         SelectionUnit$ FullRow=�5f         AlternatingRowBackground
 �����   
IsReadOnly$
 True��5h      $��10q�5i      ��5e      �� *RoomInformation+   Columns 5j      0  *System.Windows.Controls.DataGridTextColumn  5k      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6@   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6%   �� *RoomID+6@     5l      $ Room Number��6D    6%   �� *
RoomNumber+6D     5m      $ Description��6I    6%   �� *RoomDescription+6I     5n      $ Max Capacity��6K    6%   �� *RoomMaxCapacity+6K     5o      $ Prcie Per Date��6J    6%   �� *RoomPricePerDate+6J     5p      $ 
RoomStatus��6D    6%   �� *
RoomStatus+6D     5q      $ 	Room Type��6O    6%   �� *RoomType.RoomTypeName+6O   5s      5u      5v      