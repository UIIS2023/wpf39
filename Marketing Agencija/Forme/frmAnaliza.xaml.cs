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
    /// Interaction logic for frmAnaliza.xaml
    /// </summary>
    public partial class frmAnaliza : Window
    {
        SqlConnection konekcija = new SqlConnection();
        Konekcija kon = new Konekcija();
        private bool azuriraj;
        private DataRowView red;
        public void PopuniListe()
        {
            InitializeComponent();

           
            try
            {
                konekcija = kon.KreirajKonekciju();
                konekcija.Open();
                string vratiKampanju = @"Select [ID kampanje],Naziv_kampanje from Marketinska_Kampanja";
                SqlDataAdapter daKampanje = new SqlDataAdapter(vratiKampanju,konekcija);
                DataTable dtKampanje = new DataTable();
                daKampanje.Fill(dtKampanje);
                cbxAnaliza.ItemsSource = dtKampanje.DefaultView;
                daKampanje.Dispose();



            }
            catch (SqlException)
            {
                MessageBox.Show("Padajuca lista nije popunjena","Greska",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            finally
            {
                if(konekcija != null)
                {
                    konekcija.Close();

                }
            }
            
        }
        public frmAnaliza()
        {
            InitializeComponent();

            konekcija = kon.KreirajKonekciju();
            PopuniListe();
        }
        public frmAnaliza(bool azururaj, DataRowView red)
        {
            InitializeComponent();

            konekcija = kon.KreirajKonekciju();
            this.azuriraj = azuriraj;
            this.red = red;
            PopuniListe();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija = kon.KreirajKonekciju();
                konekcija.Open();
                DateTime date = (DateTime)DatumIzradeAnalize.SelectedDate;
                string datum = date.ToString("yyyy-MM-dd", CultureInfo.CurrentCulture);
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@tipAnalize",SqlDbType.NVarChar).Value = txtTipAnalize.Text;
                cmd.Parameters.Add("@opis", SqlDbType.NVarChar).Value = txtOpisAnalize.Text;
                cmd.Parameters.Add("@rezultati", SqlDbType.NVarChar).Value = txtRezultatiAnalize.Text;
                cmd.Parameters.Add("@datum", SqlDbType.DateTime).Value = datum;
                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"UPDATE Analiza_Trzista 
                        SET Tip_analize = @tipAnalize, 
                            Datum_izrade = @datum, 
                            Rezultati = @rezultati, 
                            Opis = @opis 
                        WHERE [ID Analize] = @id";
                    red = null;
                }
                else
                {
                    cmd.CommandText = @"insert into Analiza_Trzista(Tip_analize,Datum_izrade,Rezultati,Opis)
                                                               values(@tipAnalize,@datum,@rezultati,@opis);";
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
                if( konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
