   M S B A M L   `   `   `  ����G  CGroupProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:GroupProject.MainGroupProject.Main  5   	       GroupProject.Main.wndMain   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:GroupProject.Main     5   	     � Title$  wndMain��5   	   $	��450��6   $	��800��6&   .��5	      � .+�5
   
   o� $
��Left=�6   $��20��6*   $	��Top=�66   $	��794��6N   .@�5      m� -   5        $��_Search For Invoice��5      6O   m� 5      -   5        $��_Update Item��5      6B   5      &   System.Windows.Controls.DataGrid  5   
   $
��Left=�6   $	��323��6.   $��	10,25,0,0q�6;   $	��Top=�6N   $	��201��6f   �� 5   
   -   5         ��Name$ 
newInvoice��5      $��New Invoice��6%   $
��Left=�6;   $��230,225,0,0q�6V   $	��Top=�6k   $	��100��6�   6�   �� 5   
   -   5        $ deleteInvoice��5      $��Delete Invoice��6(   $
��Left=�6A   $��230,123,0,0q�6\   $	��Top=�6q   $	��100��6�   6�   �� 5   
   -   5         ��Name$ comboInvoice��5      $
��Left=�6)   $��
229,70,0,0q�6D   $	��Top=�6X   $	��120��6p   �� 5   
   -   5        $ comboAddItems��5      $
��Left=�6*   $��229,300,0,0q�6E   $	��Top=�6Z   $	��120��6r   �� 5   
   -   5        $ addItem��5      $��Add Item��6"   $
��Left=�65   $��229,327,0,0q�6P   $	��Top=�6e   $��75��6}   6�   �� 5   
   -   5         ��Name$ 	itemPrice��5      $
��Left=�6%   $��22��6@   $��373,300,0,0q�6L    �� TextWrapping$
 Wrap=�6a   $��TextBox��6u   $	��Top=�6�   $	��120��6�   {�.  6�   �� 5   
   -	   5        $ comboInvoiceItems��5      $
��Left=�6.   $��
373,70,0,0q�6I   $	��Top=�6]   $	��120��6u   �� 5   
   -
   5        $ 
deleteItem��5      $��Delete Item��6%   $
��Left=�6;   $��
373,97,0,0q�6V   $	��Top=�6j   $��75��6�   6�   �� 5   
   -   5        $ saveInvoice��5      $��Save Invoice��6&   $
��Left=�6=   $��
229,97,0,0q�6X   $	��Top=�6l   $	��100��6�   6�   �� 5   
   $��Add Items to Invoice��6   $
��Left=�6/   $��230,269,0,0q�6J   $	��Top=�6_   �� 5   
   $��Select Invoice��6   $
��Left=�6)   $��
230,39,0,0q�6D   $	��Top=�6X   �� 5   
   $��Select Item��6   $
��Left=�6&   $��
373,39,0,0q�6A   $	��Top=�6U   �� 5   
   $��Create New Invoice��6   $
��Left=�6-   $��229,168,0,0q�6H   $	��Top=�6]   �� 5   
   $��Date:��6   $
��Left=�6    $��455,188,0,0q�6;   $	��Top=�6P   �� 5   
   -   5        $ totalCostInput��5      $
��Left=�6*   $��20��6E   $��299,194,0,0q�6Q   $
 Wrap=�6f   $	��Top=�6z   $	��120��6�   �� 5   
   $��Total Cost:��6   $
��Left=�6&   $��229,192,0,0q�6A   $	��Top=�6V   &   System.Windows.Controls.Calendar  5   
   $
��Left=�6   $��514,184,0,0q�6.   $	��Top=�6C   5!      5"      