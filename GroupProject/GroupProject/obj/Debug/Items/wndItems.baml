   M S B A M L   `   `   `  ����G  CGroupProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:GroupProject.ItemsGroupProject.Items  5   	   !    GroupProject.Items.wndItems   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:GroupProject.Items     5   	   -   5          � Title$  wndItems��5   	   $	��450��6   $	��800��6'   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgItems��5
      $
��Left=�6$   $	��399��6?   $��	10,10,0,0q�6L   $	��Top=�6_   $
��Auto��6w      CanUserAddRows .     SelectionMode$ Single=�6�   6�   �� 5   
   -   5         ��Name$ 
btnAddItem��5      $��Add Item��6%   $
��Left=�68   $��
403,46,0,0q�6S   $	��Top=�6g   $��75��6   6�   �� 5   
   -   5        $ btnEditItem��5      $��	Edit Item��6&   $
��Left=�6:   $��
403,85,0,0q�6U   $	��Top=�6i   $��75��6�   6�   �� 5   
   -   5        $ btnDeleteItem��5      $��Delete Item��6(   $
��Left=�6>   $��403,124,0,0q�6Y   $	��Top=�6n   $��75��6�   6�   �� 5   
   -   5         ��Name$ tbxItemCode��5      $
��Left=�6'   $��23��6B   $��
535,46,0,0q�6N    �� TextWrapping$
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��120��6�   $y�Hidden=�6�   �� 5   
   -   5        $ tbxItemDesc��5      $
��Left=�6'   $
��Auto��6B   $��
535,85,0,0q�6P   $
 Wrap=�6d   $�� ��6x   $	��Top=�6�   $	��120��6�   $y�Hidden=�6�   �� 5   
   -   5        $ tbxItemCost��5      $
��Left=�6'   $��23��6B   $��535,124,0,0q�6N   $
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��120��6�   $y�Hidden=�6�   �� 5   
   -	   5        $ btnConfirmAdd��5      $	��Add��6(   $
��Left=�66   $��559,152,0,0q�6Q   $	��Top=�6f   $
��Auto��6~   $y�Hidden=�6�   �� 5   
   -
   5        $ btnConfirmEdit��5      $
��Edit��6)   $
��Left=�68   $��559,152,0,0q�6S   $	��Top=�6h   $
��Auto��6�   $y�Hidden=�6�   �� 5   
   -   5        $ btnConfirmDelete��5      $��Delete��6+   $
��Left=�6<   $��559,152,0,0q�6W   $	��Top=�6l   $
��Auto��6�   $y�Hidden=�6�   5      5      