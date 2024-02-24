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
    /// Interaction logic for frmUgovori.xaml
    /// </summary>
    public partial class frmUgovori : Window
    {
        SqlConnection konekcija = new SqlConnection();
        Konekcija kon = new Konekcija();
        private bool azuriraj;
        private DataRowView red;
        public frmUgovori()
        {
            InitializeComponent();

            konekcija = kon.KreirajKonekciju();
            PopuniListe();
        }
        public frmUgovori(bool azururaj, DataRowView red)
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
                string vratiKlijenta = @"select [ID klijent], Ime+ ' ' + Prezime as Klijent from Klijent";
                SqlDataAdapter daKlijenta = new SqlDataAdapter(vratiKlijenta,konekcija);
                DataTable dtKlijenta = new DataTable();
                daKlijenta.Fill(dtKlijenta);
                cbxKlijent.ItemsSource = dtKlijenta.DefaultView;
                daKlijenta.Dispose();



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
                DateTime date = (DateTime)dpDatumIzrade.SelectedDate;
                string datum = date.ToString("yyyy-MM-dd", CultureInfo.CurrentCulture);
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@trajanje", SqlDbType.NVarChar).Value = txtTrajanje.Text;
                cmd.Parameters.Add("@cena", SqlDbType.Int).Value = txtCena.Text;
                cmd.Parameters.Add("@datum", SqlDbType.DateTime).Value = datum;
                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"UPDATE Ugovor 
                       SET Datum_izrade = @datum, 
                           Trajanje = @trajanje, 
                           Cena = @cena 
                       WHERE [ID ugovora] = @id";
                    red = null;
                }
                else
                {
                    cmd.CommandText = @"insert into Ugovor(Datum_izrade,Trajanje,Cena)
                                                               values(@datum,@trajanje,@cena);";
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
