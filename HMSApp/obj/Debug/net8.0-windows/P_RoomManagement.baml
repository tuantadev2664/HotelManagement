   M S B A M L   `   `   `  ����A  =HMSApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:HMSAppHMSApp  5          HMSApp.P_RoomManagement   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:HMSApp     5      _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� 
Background
  �����   MaterialDesignBody#���   5	      $��Regular"�5
      $��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignFont N� 
FontFamily# �  5       N� Title$ P_RoomManagement��5      .��5      � $��Stretch=�6   $��Stretch=�6)    � RowDefinitions 5   
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
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5!   
   �� 5"      $
��Auto �6   �� 5#      $��* �6   .+�5&   
   ��  $  MaterialDesignSubtitle1TextBlock#��[ 6   $��2��6N   $��Room Managememt��6b   $��0��6y   $��0��6�   $��10q�6�   $��20(�6�   $
��Bold"�6�   $��Center=�6�   �� 5)   
   #��[ 6   $��Id��6N   $��1��6X   $��0��6e   $��10q�6u   �� 5*   
   -   5         ��Name$
 tbId��5*      $	��200��6    ${�False��6/   $��1��6A   $��1��6N   $��10q�6^   �� 5,   
   #��[ 6   $��Room Number��6N   $��2��6a   $��0��6n   $��10q�6~   �� 5-   
   -   5        $ tbRoomNumber��5-      $	��200��6(   ${�False��68   $��2��6J   $��1��6W   $��10q�6g   �� 5/   
   #��[ 6   $��Description��6N   $��3��6a   $��0��6n   $��10q�6~   �� 50   
   -   5        $ tbDescription��50      $	��200��6)   ${�False��68   $��3��6J   $��1��6W   $��10q�6g   �� 52   
   #��[ 6   $��Max Capacity��6N   $��4��6b   $��0��6o   $��10q�6   �� 53   
   -   5        $ tbMaxCapacity��53      $	��200��6)   ${�False��68   $��4��6J   $��1��6W   $��10q�6g   �� 55   
   #��[ 6   $��Status��6N   $��5��6\   $��0��6i   $��10q�6y   �� 56   
   -   5        $ tbStatus��56      $	��200��6$   ${�False��63   $��5��6E   $��1��6R   $��10q�6b   �� 58   
   #��[ 6   $��Price Per Date��6N   $��6��6d   $��0��6q   $��10q�6�   �� 59   
   -   5        $ tbPricePerDate��59      $	��200��6*   ${�False��6:   $��6��6L   $��1��6Y   $��10q�6i   �� 5;   
   #��[ 6   $��	Room Type��6N   $��7��6_   $��0��6l   $��10q�6|   �� 5<   
   -   5        $ 
tbRoomType��5<      $	��200��6&   ${�False��65   $��7��6G   $��1��6T   $��10q�6d   �� 5?   
   $��8��6   $��2��6"    �� Orientation$ 
Horizontal=�66   $��Center=�6O   $��10q�6l   .+�5@      �� -   5        $��
Create new��5@      $��30��6*   $��5q�6I   �� 5A      -	   5        $��Update��5A      $��30��6&   $��5q�6E   �� 5B      -
   5        $��Delete��5B      $��30��6&   $��5q�6E   5C      �� 5E   
   $��9��6   $��2��6"   $ 
Horizontal=�66   $��Center=�6O   $��10q�6l   .+�5F      �� -   5        $ tbSearchbyText��5F      $	��300��6.   )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Search��6=   $
{�True��6e   $��4��6v   $��1��6�   $��5q�6�   $	��500��6�   �� 5G      -   5        $��Search by ID��5G      $��30��6,   $��5q�6O   5H      &   System.Windows.Controls.DataGrid  5J   
   -   5        
  Name$
 dataGrid��5J      $��10��5K      $��2��6      AutoGenerateColumns$ False��5L         CanUserAddRows$ False��5M         HeadersVisibility$	 All=�5N         SelectionUnit$ FullRow=�5P         AlternatingRowBackground
 �����   
IsReadOnly$
 True��5R      $��10q�5S      ��5O      �� *	Members+   Columns 5T      0  *System.Windows.Controls.DataGridTextColumn  5U      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6@   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *RoomId+6@     5V      $ Room Number��6D    6%   �� *
RoomNumber+6D     5W      $ Description��6I    6%   �� *RoomDescription+6I     5X      $ Max Capacity��6I    6%   �� *RoomMaxCapacity+6I     5Y      $ 
RoomStatus��6D    6%   �� *
RoomStatus+6D     5Z      $ 	Room Type��6O    6%   �� *RoomType.RoomTypeName+6O   5\      5]      5^      