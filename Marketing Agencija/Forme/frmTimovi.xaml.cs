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
    /// <summary>
    /// Interaction logic for frmTimovi.xaml
    /// </summary>
    public partial class frmTimovi : Window
    {
        SqlConnection konekcija = new SqlConnection();
        Konekcija kon = new Konekcija();
        private bool azuriraj;
        private DataRowView red;
        public frmTimovi(bool azururaj, DataRowView red)
        {
            InitializeComponent();

            konekcija = kon.KreirajKonekciju();
            this.azuriraj = azuriraj;
            this.red = red;
        }
        public frmTimovi()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
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
                cmd.Parameters.Add("@nazivTima", System.Data.SqlDbType.NVarChar).Value = txtNazivTima.Text;
                cmd.Parameters.Add("@pozicija", System.Data.SqlDbType.NVarChar).Value = txtNazivTima.Text;
                cmd.Parameters.Add("@kontakt", System.Data.SqlDbType.NVarChar).Value = txtKontakt.Text;
                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"UPDATE Marketinski_Tim 
                      SET Ime = @nazivTima, 
                          Pozicija = @pozicija, 
                          Kontakt_informacije = @kontakt 
                      WHERE [ID TIm] = @id";
                    red = null;
                }
                else
                {
                    cmd.CommandText = @"Insert into Marketinski_Tim(Ime,Pozicija,Kontakt_informacije)
                                                                values(@nazivTima,@pozicija,@kontakt);";
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
