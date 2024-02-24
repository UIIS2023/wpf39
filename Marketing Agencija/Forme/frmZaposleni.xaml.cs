using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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
    /// Interaction logic for frmZaposleni.xaml
    /// </summary>
    public partial class frmZaposleni : Window
    {

        SqlConnection konekcija = new SqlConnection();
        Konekcija kon = new Konekcija();
        private bool azuriraj;
        private DataRowView red;
        public frmZaposleni()
        {
            InitializeComponent();

            konekcija = kon.KreirajKonekciju();
            PopuniListe();
        }
        public frmZaposleni(bool azururaj, DataRowView red)
        {
            InitializeComponent();

            konekcija = kon.KreirajKonekciju();
            this.azuriraj = azuriraj;
            this.red = red;
            PopuniListe();
        }
        public void PopuniListe()
        {
            InitializeComponent();
           
            try
            {
                konekcija = kon.KreirajKonekciju();
                konekcija.Open();
                string vratiTim = @"Select [ID TIm],Ime + ' ' + Pozicija + ' ' + Kontakt_informacije as Zaposleni from Marketinski_Tim";
                SqlDataAdapter daTim = new SqlDataAdapter(vratiTim, konekcija);
                DataTable dtTim = new DataTable();
                daTim.Fill(dtTim);
                cbxTim.ItemsSource = dtTim.DefaultView;
                daTim.Dispose();



            }
            catch (SqlException)
            {
                MessageBox.Show("Padajuca lista nije popunjena", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija = kon.KreirajKonekciju();
                konekcija.Open();
               
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@ime", SqlDbType.NVarChar).Value = txtIme.Text;
                cmd.Parameters.Add("@prezime", SqlDbType.NVarChar).Value = txtPrezime.Text;
                cmd.Parameters.Add("@plata", SqlDbType.Int).Value = txtPlata.Text;
                cmd.Parameters.Add("@kontakt", SqlDbType.NVarChar).Value = txtKontakt.Text;
                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"UPDATE Zaposleni 
                         SET Ime = @ime, 
                             Prezime = @prezime, 
                             Kontakt_informacije = @kontakt, 
                             Plata = @plata 
                         WHERE [ID zaposleni] = @id";
                    red = null;
                }
                else
                {
                    cmd.CommandText = @"insert into Zaposleni(Ime,Prezime,Kontakt_informacije,Plata)
                                                               values(@ime,@prezime,@kontakt,@plata);";
                }

               
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Unos odredjenih vrednosti nije validan", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }
    }
}
