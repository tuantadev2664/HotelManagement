   M S B A M L   `   `   `  ����A  =HMSApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:HMSAppHMSApp  5   	       HMSApp.WindowUpdateRoom   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:HMSApp     5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	    � Title$ WindowUpdateRoom��5   	   $	��500��6"   $	��500��6/   .��5      � $��Stretch=�6   $��Stretch=�6)    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ tb_RoomNumber��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Room Number��6)   $��0��6V   $	��300��6d   $��20q�6s   �� 5!   
   -   5        $ tb_RoomDescription��5!      $ 
Desciption��6.   $��1��6Z   $	��300��6h   $��20q�6w   �� 5#   
   -   5        $ tb_RoomMaxCapacity��5#      $ Max Capacity��6.   $��2��6\   $	��300��6j   $��20q�6y   �� 5%   
   -   5        $ tb_PricePerDate��5%      $ 
Price/Date��6+   $��3��6W   $	��300��6e   $��20q�6t   �� 5'   
   -   5         ��Name$ 	cb_Status��5'      $ Status��6&   $��4��6N   $��20q�6[   $	��300��6g   �� 5)   
   -   5        $ cb_RoomType��5)      $ 	Room Type��6(   $��5��6S   $	��300��6`   $��20q�6o    �� DisplayMemberPath$ RoomTypeName��6{    �� SelectedValuePath$ 
RoomTypeId��6�   �� 5+   
   $��6��6   	 �� Orientation$	 
Horizontal=�6"   $��Center=�6;   $��0,10,0,0q�6X   .+�5,      �� -   5        $��Submit��5,      $	��100��6&   $��30��62   $��5q�6>   6I   �� 5-      -   5        $��Cancel��5-      $	��100��6&   $��30��62   $��5q�6>   6I   5.      5/      50      