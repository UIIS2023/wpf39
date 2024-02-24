using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Marketing_Agencija.Forme;

namespace Marketing_Agencija
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Select upiti
        string kampanjeSelect = @"Select  [ID kampanje] as ID, Naziv_kampanje as 'Naziv kampanje' ,Datum_pocetka as 'Datum pocetka',Datum_zavrsetka as 'Datum zavrsetka', Opis from Marketinska_Kampanja";
        string analizaSelect = @"Select [ID Analize] as ID, Tip_analize as 'Tim analize',Datum_izrade as 'Datum izrade',Rezultati,Opis from Analiza_Trzista";
        string izvestajiSelect = @"Select [ID izvestaj] as ID, Naslov_izvestaja as 'Naslov izvestaja', Datum_izrade as 'Datum izrade', Sadrzaj from Izvestaj";
        string rezultatiSelect = @"Select [ID rezultati] as ID, Datum_zavrsetka_kampanje as 'Datum zavrsetka kampanje', Broj_konverzija as 'Broj konverzija', ROI from Rezultati_kampanje";
        string timoviSelect = @"Select [ID TIm] as ID, Ime,Pozicija,Kontakt_informacije as 'Kontakt informacije' from Marketinski_Tim";
        string ugovoriSelect = @"Select [ID ugovora] as ID,Datum_izrade as 'Datum izrade',Trajanje,Cena from Ugovor";
        string zaposleniSelect = @"Select [ID zaposleni] as ID, Ime,Prezime,Kontakt_informacije as 'Kontakt informacije',Plata from Zaposleni";
        string klijentiSelect = @"Select [ID klijent] as ID,Ime,Prezime,Kontakt_informacije as 'Kontakt informacije' from Klijent";
        #endregion

        #region Delete upiti
        string kampanjaDelete = @"DELETE FROM Marketinska_Kampanja WHERE [ID kampanje] =";
        string analizaDelete = @"DELETE FROM Analiza_Trzista WHERE [ID Analize]= ";
        string izvestajiDelete = @"DELETE FROM Izvestaj WHERE [ID izvestaj]= ";
        string rezultatiDelete = @"DELETE FROM Rezultati_kampanje WHERE [ID rezultati]= ";
        string timoviDelete = @"DELETE FROM Marketinski_Tim WHERE [ID TIm]= ";
        string ugovoriDelete = @"DELETE FROM Ugovor WHERE [ID ugovora]= @id";
        string zaposleniDelete = @"DELETE FROM Zaposleni WHERE [ID zaposleni]=";
        string klijentiDelete = @"DELETE FROM Klijent WHERE [ID klijent]=";
        #endregion

        #region

        string kampanjaUpdate = @"SELECT * FROM Marketinska_Kampanja WHERE [ID kampanje] = ";
        string analizaUpdate = @"SELECT * FROM Analiza_Trzista WHERE [ID Analize] = ";
        string izvestajiUpdate = @"SELECT * FROM Izvestaj WHERE [ID izvestaj] = ";
        string rezultatiUpdate = @"SELECT * FROM Rezultati_kampanje WHERE [ID rezultati] = ";
        string timoviUpdate = @"SELECT * FROM Marketinski_Tim WHERE [ID TIm] = ";
        string ugovoriUpdate = @"SELECT * FROM Ugovor WHERE [ID ugovora] = ";
        string zaposleniUpdate = @"SELECT * FROM Zaposleni WHERE [ID zaposleni] = ";
        string klijentiUpdate = @"SELECT * FROM Klijent WHERE [ID klijent] = ";

        #endregion

        SqlConnection konekcija = new SqlConnection();
        Konekcija kon = new Konekcija();
        string ucitanaTabela;
        private bool azuriraj;
        private DataRowView red;

        public MainWindow()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            UcitajPodatke(dataGridCentralni, kampanjeSelect);
            
        }

        void UcitajPodatke(DataGrid grid,string selectUpit)
        {
            try
            {
                konekcija.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectUpit,konekcija);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                ucitanaTabela = selectUpit;

                if(grid != null)
                {
                    grid.ItemsSource = dataTable.DefaultView;
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Neuspesno ucitani podaci","Greska",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            finally
            {
                if( konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }
        private void btnKampanje_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni,kampanjeSelect );
        }

        private void btnAnaliza_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, analizaSelect);
        }

        private void btnIzvestaji_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, izvestajiSelect);
        }

        private void btnRezultati_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, rezultatiSelect);
        }

        private void btnTim_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, timoviSelect);
        }

        private void btnZaposleni_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, zaposleniSelect);
        }

        private void btnKlijenti_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, klijentiSelect);
        }

        private void btnUgovori_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, ugovoriSelect);
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Window prozor;
            if (ucitanaTabela.Equals(kampanjeSelect))
            {
                prozor = new frmKampanja();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni,kampanjeSelect);
            } else if (ucitanaTabela.Equals(analizaSelect))
            {
                prozor = new frmAnaliza();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, analizaSelect);
            }
            else if (ucitanaTabela.Equals(izvestajiSelect))
            {
                prozor = new frmIzvestaji();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, izvestajiSelect);
            }
            else if (ucitanaTabela.Equals(klijentiSelect))
            {
                prozor = new frmKlijenti();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, klijentiSelect);
            }
            else if (ucitanaTabela.Equals(rezultatiSelect))
            {
                prozor = new frmRezultati();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, rezultatiSelect);
            }
            else if (ucitanaTabela.Equals(timoviSelect))
            {
                prozor = new frmTimovi();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, timoviSelect);
            }
            else if (ucitanaTabela.Equals(ugovoriSelect))
            {
                prozor = new frmUgovori();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, ugovoriSelect);
            }
            else if (ucitanaTabela.Equals(zaposleniSelect))
            {
                prozor = new frmZaposleni();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, zaposleniSelect);
            }
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (ucitanaTabela.Equals(kampanjeSelect))
            {
                obrisiZapis(dataGridCentralni, kampanjaDelete);
                UcitajPodatke(dataGridCentralni, kampanjeSelect);
            }
            else if (ucitanaTabela.Equals(analizaSelect))
            {
                obrisiZapis(dataGridCentralni, analizaDelete);
                UcitajPodatke(dataGridCentralni, analizaSelect);
            }
            else if (ucitanaTabela.Equals(izvestajiSelect))
            {
                obrisiZapis(dataGridCentralni, izvestajiDelete);
                UcitajPodatke(dataGridCentralni, izvestajiSelect);
            }
            else if (ucitanaTabela.Equals(rezultatiSelect))
            {
                obrisiZapis(dataGridCentralni, rezultatiDelete);
                UcitajPodatke(dataGridCentralni, rezultatiSelect);
            }
            else if (ucitanaTabela.Equals(timoviSelect))
            {
                obrisiZapis(dataGridCentralni, timoviDelete);
                UcitajPodatke(dataGridCentralni, timoviSelect);
            }
            else if (ucitanaTabela.Equals(ugovoriSelect))
            {
                obrisiZapis(dataGridCentralni, ugovoriDelete);
                UcitajPodatke(dataGridCentralni, ugovoriSelect);
            }
            else if (ucitanaTabela.Equals(zaposleniSelect))
            {
                obrisiZapis(dataGridCentralni, zaposleniDelete);
                UcitajPodatke(dataGridCentralni, zaposleniSelect);
            }
            else if (ucitanaTabela.Equals(klijentiSelect))
            {
                obrisiZapis(dataGridCentralni, klijentiDelete);
                UcitajPodatke(dataGridCentralni, klijentiSelect);
            }
        }

        private void obrisiZapis(DataGrid dataGridCentralni, string deleteUpit)
        {
            try
            {
                konekcija.Open();
                DataRowView red =(DataRowView) dataGridCentralni.SelectedItems[0];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni?","Pitanje", MessageBoxButton.YesNo, MessageBoxImage.Question);  
                if(rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = konekcija,
                       
                    };
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = deleteUpit + "@id";
                    cmd.ExecuteNonQuery();
                }


            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("NIste selektovali red", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                
            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u grugim tabelama", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if(konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            
            if (ucitanaTabela.Equals(kampanjeSelect))
            {

                promeniZapis(kampanjaUpdate);
                UcitajPodatke(dataGridCentralni, kampanjeSelect);
            }
            else if (ucitanaTabela.Equals(analizaSelect))
            {
                promeniZapis(analizaUpdate);
                UcitajPodatke(dataGridCentralni, analizaSelect);
            }
            else if (ucitanaTabela.Equals(izvestajiSelect))
            {
                promeniZapis( izvestajiUpdate);
                UcitajPodatke(dataGridCentralni, izvestajiSelect);
            }
            else if (ucitanaTabela.Equals(rezultatiSelect))
            {
                promeniZapis( rezultatiUpdate);
                UcitajPodatke(dataGridCentralni, rezultatiSelect);
            }
            else if (ucitanaTabela.Equals(timoviSelect))
            {
                promeniZapis( timoviUpdate);
                UcitajPodatke(dataGridCentralni, timoviSelect);
            }
            else if (ucitanaTabela.Equals(ugovoriSelect))
            {
                promeniZapis( ugovoriUpdate);
                UcitajPodatke(dataGridCentralni, ugovoriSelect);
            }
            else if (ucitanaTabela.Equals(zaposleniSelect))
            {
                promeniZapis(zaposleniUpdate);
                UcitajPodatke(dataGridCentralni, zaposleniSelect);
            }
            else if (ucitanaTabela.Equals(klijentiSelect))
            {
                promeniZapis( klijentiUpdate);
                UcitajPodatke(dataGridCentralni, klijentiSelect);
            }
        }
        private void promeniZapis( object izmeni)
        {
            try
            {
                konekcija.Open();
                azuriraj = true;
                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];
                
                  SqlCommand cmd = new SqlCommand
                    {
                        Connection = konekcija,

                    };
                  cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                  cmd.CommandText = izmeni + "@id";
                SqlDataReader citac = cmd.ExecuteReader();
                  
                cmd.Dispose();

                if (citac.Read())
                    
                {
                   
                    if (ucitanaTabela.Equals(analizaSelect))
                    {

                        frmAnaliza prozorAnaliza = new frmAnaliza(azuriraj, red);
                        prozorAnaliza.txtTipAnalize.Text = citac["Tip_analize"].ToString();
                        prozorAnaliza.txtOpisAnalize.Text = citac["Opis"].ToString();
                        prozorAnaliza.txtRezultatiAnalize.Text = citac["Rezultati"].ToString();
                        prozorAnaliza.DatumIzradeAnalize.SelectedDate = (DateTime)citac["Datum_izrade"];
                        

                        prozorAnaliza.ShowDialog();


                    }
                    else if (ucitanaTabela.Equals(kampanjeSelect))
                    {
                        frmKampanja prozorKampanja = new frmKampanja(azuriraj, red);
                        prozorKampanja.txtNazivKampanje.Text = citac["Naziv_kampanje"].ToString();
                        prozorKampanja.dpDatumPocetka.SelectedDate = (DateTime)citac["Datum_pocetka"];
                        prozorKampanja.dpDatumZavrsetka.SelectedDate = (DateTime)citac["Datum_zavrsetka"];
                        prozorKampanja.txtOpis.Text = citac["Opis"].ToString();
                        prozorKampanja.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(izvestajiSelect))
                    {
                        frmIzvestaji prozorIzvestaji = new frmIzvestaji(azuriraj, red);
                        prozorIzvestaji.txtNaslovIzvestaj.Text = citac["Naslov_izvestaja"].ToString();
                        prozorIzvestaji.dpDatumIzrade.SelectedDate = (DateTime)citac["Datum_izrade"];
                        prozorIzvestaji.txtSadrzaj.Text = citac["Sadrzaj"].ToString();
                        prozorIzvestaji.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(rezultatiSelect))
                    {
                        frmRezultati prozorRezultati = new frmRezultati(azuriraj, red);
                        prozorRezultati.dpDatumZavrsetka.SelectedDate = (DateTime)citac["Datum_zavrsetka_kampanje"];
                        prozorRezultati.txtBrojKonverzija.Text = citac["Broj_konverzija"].ToString();
                        prozorRezultati.txtROI.Text = citac["ROI"].ToString();
                        prozorRezultati.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(timoviSelect))
                    {
                        frmTimovi prozorTimovi = new frmTimovi(azuriraj, red);
                        prozorTimovi.txtNazivTima.Text = citac["Ime"].ToString();
                        prozorTimovi.txtPozicija.Text = citac["Pozicija"].ToString();
                        prozorTimovi.txtKontakt.Text = citac["Kontakt_informacije"].ToString();
                        prozorTimovi.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(ugovoriSelect))
                    {
                        frmUgovori prozorUgovori = new frmUgovori(azuriraj, red);
                        prozorUgovori.dpDatumIzrade.SelectedDate = (DateTime)citac["Datum_izrade"];
                        prozorUgovori.txtTrajanje.Text = citac["Trajanje"].ToString();
                        prozorUgovori.txtCena.Text = citac["Cena"].ToString();
                        prozorUgovori.cbxKlijent.SelectedValue = citac["[ID klijent]"].ToString();

                        prozorUgovori.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(zaposleniSelect))
                    {
                        frmZaposleni prozorZaposleni = new frmZaposleni(azuriraj, red);
                        prozorZaposleni.txtIme.Text = citac["Ime"].ToString();
                        prozorZaposleni.txtPrezime.Text = citac["Prezime"].ToString();
                        prozorZaposleni.txtKontakt.Text = citac["Kontakt_informacije"].ToString();
                        prozorZaposleni.txtPlata.Text = citac["Plata"].ToString();
                        prozorZaposleni.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(klijentiSelect))
                    {
                        frmKlijenti prozorKlijenti = new frmKlijenti(azuriraj, red);
                        prozorKlijenti.txtIme.Text = citac["Ime"].ToString();
                        prozorKlijenti.txtPrezime.Text = citac["Prezime"].ToString();
                        prozorKlijenti.txtKontakt.Text = citac["Kontakt_informacije"].ToString();
                        prozorKlijenti.ShowDialog();
                    }

                }

            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("NIste selektovali red", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);

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
