using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Marketing_Agencija.Forme
{
  
    public partial class frmKlijenti : Window
    {
        SqlConnection konekcija = new SqlConnection();
        Konekcija kon = new Konekcija();
        private bool azuriraj;
        private DataRowView red;
       
        public frmKlijenti(bool azururaj, DataRowView red)
        {
            InitializeComponent();

            konekcija = kon.KreirajKonekciju();
            this.azuriraj = azuriraj;
            this.red = red;
        }
        public frmKlijenti()
        {
            InitializeComponent();
            konekcija=kon.KreirajKonekciju();
        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@ime", System.Data.SqlDbType.NVarChar).Value = txtIme.Text;
                cmd.Parameters.Add("@prezime", System.Data.SqlDbType.NVarChar).Value = txtPrezime.Text;
                cmd.Parameters.Add("@kontakt", System.Data.SqlDbType.NVarChar).Value = txtKontakt.Text;
                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"UPDATE Klijent 
                        SET Ime = @ime, 
                            Prezime = @prezime, 
                            Kontakt_informacije = @kontakt 
                        WHERE [ID klijent] = @id";
                    red = null;
                }
                else
                {
                    cmd.CommandText = @"Insert into Klijent(Ime,Prezime,Kontakt_Informacije)
                                                       values(@ime,@prezime,@kontakt);";
                }
                
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();


            }
            catch (SqlException)
            {
                MessageBox.Show("Unos odredjenih vrednosti nije validan", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                if(konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }
    }
}
