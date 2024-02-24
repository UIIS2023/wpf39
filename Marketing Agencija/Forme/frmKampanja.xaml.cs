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
    /// Interaction logic for frmKampanja.xaml
    /// </summary>
    public partial class frmKampanja : Window
    {
         SqlConnection konekcija = new SqlConnection();
        Konekcija kon = new Konekcija();
        private bool azuriraj;
        private DataRowView red;

        public frmKampanja()
        {
            InitializeComponent();

            konekcija = kon.KreirajKonekciju();
            PopuniListe();
        }
        public frmKampanja(bool azururaj, DataRowView red)
        {

            InitializeComponent();

            konekcija = kon.KreirajKonekciju();
            this.azuriraj = azuriraj;
            this.red = red;
            PopuniListe();
        }
        public void PopuniListe()
        {
           

            
            try
            {
                konekcija = kon.KreirajKonekciju();
                konekcija.Open();
                string vratiKlijenta = @"select [ID klijent],Ime + ' ' + Prezime as Klijent from Klijent";
                SqlDataAdapter daKlijenta = new SqlDataAdapter(vratiKlijenta, konekcija);
                DataTable dtKlijenta = new DataTable();
                daKlijenta.Fill(dtKlijenta);
                cbxKlijent.ItemsSource = dtKlijenta.DefaultView;
                daKlijenta.Dispose();
                dtKlijenta.Dispose();

                string vratiTim = @"Select [ID TIm],Ime + ' ' + Pozicija + ' ' + Kontakt_informacije as Zaposleni from Marketinski_Tim";
                SqlDataAdapter daTim = new SqlDataAdapter(vratiTim, konekcija);
                DataTable dtTim = new DataTable();
                daTim.Fill(dtTim);
                cbxTim.ItemsSource = dtTim.DefaultView;
                daTim.Dispose();
                dtTim.Dispose();



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
                DateTime date = (DateTime)dpDatumZavrsetka.SelectedDate;
                string datum = date.ToString("yyyy-MM-dd", CultureInfo.CurrentCulture);
                DateTime date2 = (DateTime)dpDatumPocetka.SelectedDate;
                string datum2 = date.ToString("yyyy-MM-dd", CultureInfo.CurrentCulture);
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@naziv", SqlDbType.NVarChar).Value = txtNazivKampanje.Text;
                cmd.Parameters.Add("@opis", SqlDbType.NVarChar).Value = txtOpis.Text;
                
                cmd.Parameters.Add("@datum", SqlDbType.DateTime).Value = datum;
                cmd.Parameters.Add("@datum2", SqlDbType.DateTime).Value = datum2;
                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"UPDATE Marketinska_Kampanja 
                          SET Naziv_kampanje = @naziv, 
                              Datum_pocetka = @datum2, 
                              Datum_zavrsetka = @datum, 
                              Opis = @opis 
                          WHERE [ID kampanje] = @id";
                    red = null;
                }
                else
                {

                    cmd.CommandText = @"insert into Marketinska_Kampanja(Naziv_kampanje,Datum_pocetka,Datum_zavrsetka,Opis)
                                                               values(@naziv,@datum2,@datum,@opis);";
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
