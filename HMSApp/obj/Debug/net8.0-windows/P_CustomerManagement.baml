   M S B A M L   `   `   `  ����A  =HMSApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:HMSAppHMSApp  5      !    HMSApp.P_CustomerManagement   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:HMSApp     5      _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5   	   $��Regular"�5	   	   $��13(�5
   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont N� 
FontFamily# �  5   	    N� 
Background
 ����� N� Title$ P_CustomerManagement��5      .��5      � $��Stretch=�6   $��Stretch=�6)    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5    
   �� 5!      $
��Auto �6   �� 5"      $��* �6   .+�5%   
   ��  $  MaterialDesignSubtitle1TextBlock#��[ 6   $��2��6N   $��Customer Managememt��6b   $��0��6}   $��0��6�   $��10q�6�   $��20(�6�   $
��Bold"�6�   $��Center=�6�   �� 5(   
   #��[ 6   $��Id��6N   $��1��6X   $��0��6e   $��10q�6u   �� 5)   
   -   5         ��Name$
 tbId��5)      $	��200��6    ${�False��6/   $��1��6A   $��1��6N   $��10q�6^   �� 5+   
   #��[ 6   $��	Full Name��6N   $��2��6_   $��0��6l   $��10q�6|   �� 5,   
   -   5        $ 
tbFullName��5,      $	��200��6&   ${�False��66   $��2��6H   $��1��6U   $��10q�6e   �� 5.   
   #��[ 6   $��	Telephone��6N   $��3��6_   $��0��6l   $��10q�6|   �� 5/   
   -   5        $ tbTelephone��5/      $	��200��6'   ${�False��66   $��3��6H   $��1��6U   $��10q�6e   �� 51   
   #��[ 6   $��Email Address��6N   $��4��6c   $��0��6p   $��10q�6�   �� 52   
   -   5        $ tbEmail��52      $	��200��6#   ${�False��62   $��4��6D   $��1��6Q   $��10q�6a   �� 54   
   #��[ 6   $��Birthday��6N   $��5��6^   $��0��6k   $��10q�6{   �� 55   
   -   5        $ 
tbBirthday��55      $	��200��6&   ${�False��66   $��5��6H   $��1��6U   $��10q�6e   �� 57   
   #��[ 6   $��Status��6N   $��6��6\   $��0��6i   $��10q�6y   �� 58   
   -   5        $ tbStatus��58      $	��200��6$   ${�False��63   $��6��6E   $��1��6R   $��10q�6b   �� 5:   
   $��7��6   $��2��6"    �� Orientation$ 
Horizontal=�66   $��Center=�6O   $��10q�6l   .+�5;      �� -   5        $��btn_SwitchStatus��5;      $��Deleted��6-   $��30��6?   $��5q�6^   5<      �� 5>   
   $��8��6   $��2��6"   $ 
Horizontal=�66   $��Center=�6O   $��10q�6l   .+�5?      �� -   5        $ tbSearchbyText��5?      $	��300��6.   )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Search��6=   $
{�True��6e   $��4��6v   $��1��6�   $��5q�6�   $	��500��6�   �� 5@      -	   5        $��Search by Name��5@      $��30��6.   $��5q�6S   5A      &   System.Windows.Controls.DataGrid  5C   
   -
   5        
  Name$
 dataGrid��5C      $��9��5D      $��2��6      AutoGenerateColumns$ False��5E         CanUserAddRows$ False��5F         HeadersVisibility$	 All=�5G         SelectionUnit$ FullRow=�5I         AlternatingRowBackground
 �����   
IsReadOnly$
 True��5K      $��10q�5L   8   ��5H      �� *	Members+   Columns 5M      0  *System.Windows.Controls.DataGridTextColumn  5N      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6D   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *
CustomerId+6D     5O      $ 	Full Name��6J    6%   �� *CustomerFullName+6J     5P      $ 	Telephone��6C    6%   �� *	Telephone+6C     5Q      $ Email Address��6F    6%   �� *EmailAddress+6F     5R      $ Birthday��6J    6%   �� *CustomerBirthday+6J     5S      $ Status��6H    6%   �� *CustomerStatus+6H   5U      5V      5W      