   M S B A M L   `   `   `  ����M  IMarketing Agencija, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Marketing_Agencija.FormeMarketing_Agencija.Forme  5   	   )    #Marketing_Agencija.Forme.frmAnaliza   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Marketing_Agencija.Forme     5   	     � Title$  Dodaj/Izmeni Analizu��5   	   $	��400��6&   $	��400��63   .��5	      � .+�5
   
   �� $��Kampanja��6   $
��Left=�6#   $��	30,33,0,0q�6>   $	��Top=�6Q   �� 5   
   $��Tip analize��6   $
��Left=�6&   $��	30,68,0,0q�6A   $	��Top=�6T   �� 5   
   $��Datum izrade��6   $
��Left=�6'   $��
30,112,0,0q�6B   $	��Top=�6V   �� 5   
   $
��Opis��6   $
��Left=�6   $��
36,174,0,0q�6:   $	��Top=�6N   �� 5   
   $��	Rezultati��6   $
��Left=�6$   $��
35,143,0,0q�6?   $	��Top=�6S    J� RenderTransformOrigin$ 0.531,2.324&�6k   �� 5   
   -   5         ��Name$ txtTipAnalize��5      $
��Left=�6*   $��
116,72,0,0q�6E    �� TextWrapping$
 Wrap=�6Y   $	��Top=�6n   $	��120��6�   �� 5   
   -   5        $ txtRezultatiAnalize��5      $
��Left=�6/   $��113,147,0,0q�6J   $
 Wrap=�6_   $	��Top=�6t   $	��120��6�   �� 5   
   -   5        $ txtOpisAnalize��5      $
��Left=�6*   $��113,176,0,0q�6E   $
 Wrap=�6Z   $	��Top=�6o   $	��120��6�   �� 5   
   -   5         ��Name$ 
btnSacuvaj��5      $��Sacuvaj��6&   $
��Left=�68   $��
50,330,0,0q�6S   $	��Top=�6g   $��40��6   $��85��6�   6�   �� 5   
   -   5        $ 	btnOtkazi��5      $��Otkazi��6$   $
��Left=�65   $��253,330,0,0q�6P   $	��Top=�6e   $��40��6}   $��85��6�   $ 3.793,0.599&�6�   6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ DatumIzradeAnalize��5      $
��Left=�62   $��116,112,0,0q�6M   $	��Top=�6b   �� 5   
   -   5         ��Name$ 
cbxAnaliza��5      $
��Left=�6(   $��
116,37,0,0q�6C   $	��Top=�6W   $	��120��6o    �� DisplayMemberPath$ Naziv_kampanje��6{    �� SelectedValuePath$ [ID kampanje]��6�   5      5      