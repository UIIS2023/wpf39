   M S B A M L   `   `   `  ����M  IMarketing Agencija, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Marketing_Agencija.FormeMarketing_Agencija.Forme  5   	   *    $Marketing_Agencija.Forme.frmKampanja   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Marketing_Agencija.Forme     5   	     � Title$  Dodaj/Izmeni Kampanju��5	   	   $	��400��6'   $	��400��64   .��5
      � .+�5   
   �� $	��Tim��6   $
��Left=�6   $��	30,33,0,0q�69   $	��Top=�6L   �� 5   
   $��Klijent��6   $
��Left=�6"   $��	30,72,0,0q�6=   $	��Top=�6P   �� 5   
   $��Naziv kampanje��6   $
��Left=�6)   $��
30,112,0,0q�6D   $	��Top=�6X   �� 5   
   $��Datum početka��6   $
��Left=�6(   $��
30,152,0,0q�6C   $	��Top=�6W   �� 5   
   $��Datum završetka��6   $
��Left=�6*   $��
30,192,0,0q�6E   $	��Top=�6Y   �� 5   
   $
��Opis��6   $
��Left=�6   $��
30,232,0,0q�6:   $	��Top=�6N   �� 5   
   -   5         ��Name$ cbxTim��5      $
��Left=�6#   $��
150,37,0,0q�6>   $	��Top=�6R   $	��120��6j    �� DisplayMemberPath$ 	Zaposleni��6v    �� SelectedValuePath$ [ID TIm]��6�   �� 5   
   -   5        $ 
cbxKlijent��5      $
��Left=�6'   $��
150,76,0,0q�6B   $	��Top=�6V   $	��120��6n   $ Klijent��6z   $  [ID klijent]��6�   �� 5   
   -   5         ��Name$ txtNazivKampanje��5      $
��Left=�6,   $��150,116,0,0q�6G    �� TextWrapping$
 Wrap=�6\   $	��Top=�6q   $	��120��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dpDatumPocetka��5      $
��Left=�6-   $��150,156,0,0q�6H   $	��Top=�6]     5   
   -   5        $ dpDatumZavrsetka��5      $
��Left=�6/   $��150,196,0,0q�6J   $	��Top=�6_   �� 5   
   -   5        $ txtOpis��5      $
��Left=�6#   $��150,236,0,0q�6>   $
 Wrap=�6S   $	��Top=�6h   $	��120��6�   �� 5   
   -   5         ��Name$ 
btnSacuvaj��5      $��Sačuvaj��6%   $
��Left=�67   $��
50,330,0,0q�6R   $	��Top=�6f   $��40��6~   $��85��6�   6�   �� 5   
   -   5        $ 	btnOtkazi��5      $��Otkaži��6$   $
��Left=�65   $��253,330,0,0q�6P   $	��Top=�6e   $��40��6}   $��85��6�   6�   5      5      