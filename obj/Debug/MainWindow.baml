   M S B A M L   `   `   `  ����  	Edit_Info    Edit_Info.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   >d2http://schemas.microsoft.com/expression/blend/2008    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  
MainWindow��5   	    � WindowState$ 	Maximized=�6   .��5      �  � RowDefinitions 5
   
   �� 5      $��20 �6   6*   �� 5      $��60 �6   6,   �� 5      $��40 �6   6*   �� 5      $��90 �6   6,    � ColumnDefinitions 5   
   �� 5      $��* �6   .+�5   
   �� 
�������$��0��6+   $��Center=�68   $��Thông tin trang trại��6S   6q   &   System.Windows.Controls.DataGrid  5   
   $��2q�5         CanUserAddRows .  $��1��5!         AutoGenerateColumns .     GridLinesVisibility$
 None=�5#      $��Center=�6   
������  �� AlternationCount$ 2��5$         AlternatingRowBackground
 �����$��3��6W   $��0,0,20,0q�6k   ��5      �� *entitylistmenu+	 �� UpdateSourceTrigger$	 PropertyChanged=�
 �� SelectedItem
 5      �� *menuSelected+$	 PropertyChanged=�   Columns 5&      4  .System.Windows.Controls.DataGridCheckBoxColumn  5'      ,  &System.Windows.Controls.DataGridColumn   CanUserSort .  1  +System.Windows.Controls.DataGridBoundColumn   Binding 6*   �� *	ischeck+$	 PropertyChanged=�   Header 5(      �� 5)       �� Orientation$ 
Horizontal=�6%   $��Center=�5*   %   $��Center=�5+   %   .+�5,      �� $��Center=�6'    d� 	IsChecked 5-   '   ��  �� RelativeSource ��  �� AncestorType"   �� Path$ DataContext.SetallSouth�6�   5.      50      0  *System.Windows.Controls.DataGridTextColumn  51      $ Menu ID��6e      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6w      
IsReadOnly .  6%   �� *menuid+$	 PropertyChanged=�6�     52      $ 	Menu Name��6h    . $
 auto 6�    6%   �� *
locationID+$	 PropertyChanged=�6�     53      $ Location Name��6j    . $
 auto 6�    6%   �� *locationName+$	 PropertyChanged=�6�     54      $ 	Name EINV��6f    . $
 auto 6�    6%   �� *
nameEINV+$	 PropertyChanged=�6�     55      $ Address EINV��6i    . $
 auto 6�    6%   �� *addressEINV+$	 PropertyChanged=�6�     56      $	 Tax��6a    . $
 auto 6�    6%   �� *tax+$	 PropertyChanged=�6�   58      �� 59   
   -   5         ��Name$	 abc��59      $��Select Data��6   $	��200��64   $��30��6@   $��2��6L   $��10, 0, 20, 0q�6Y   6q   �� 5;   
   $��3��6   $ 
Horizontal=�6"   $��10q�6;   .+�5<      �� $	��ID:��6   $��Center=�6#   $��0,0,10,0q�6>   �� 5=      $	��100��6\   $��0,0,10,0q�6h    �� 
IsReadOnly . ��6   �� *SelectedItem.Id+$	 PropertyChanged=�6z   �� 5>      $��Name:��6   $��Center=�6%   $��0,0,10,0q�6@   �� 5?      $	��200��6^   $��0,0,10,0q�6j   ��6   �� *SelectedItem.Name+$	 PropertyChanged=�6j   �� 5@      $��Description:��6   $��Center=�6,   $��0,0,10,0q�6G   �� 5A      $	��300��6e   ��6   �� *SelectedItem.Description+$	 PropertyChanged=�6e   5B      5C      5D      