﻿using System;
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
    /// Interaction logic for frmRezultati.xaml
    /// </summary>
    public partial class frmRezultati : Window
    {
        SqlConnection konekcija = new SqlConnection();
        Konekcija kon = new Konekcija();
        private bool azuriraj;
        private DataRowView red;

        public frmRezultati(bool azururaj, DataRowView red) 
        {
            InitializeComponent();

            konekcija = kon.KreirajKonekciju();
            this.azuriraj = azuriraj;
            this.red = red;
            PopuniListe();
        }
        public frmRezultati()
        {
            InitializeComponent();

            konekcija = kon.KreirajKonekciju();
            PopuniListe();
        }
        public void PopuniListe()
        {
            InitializeComponent();
           
            try
            {
                konekcija = kon.KreirajKonekciju();
                konekcija.Open();
                string vratiKampanju = @"select [ID kampanje],Naziv_kampanje from Marketinska_Kampanja";
                SqlDataAdapter daKampanje = new SqlDataAdapter(vratiKampanju,konekcija);
                DataTable dtKampanje = new DataTable();
                daKampanje.Fill(dtKampanje);
                cbxKampanja.ItemsSource = dtKampanje.DefaultView;
                daKampanje.Dispose();



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
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@brKonverzija", SqlDbType.NVarChar).Value = txtBrojKonverzija.Text;
                cmd.Parameters.Add("@roi", SqlDbType.NVarChar).Value = txtROI.Text;
               
                cmd.Parameters.Add("@datum", SqlDbType.DateTime).Value = datum;
                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"UPDATE Rezultati_kampanje 
                          SET Datum_zavrsetka_kampanje = @datum, 
                              Broj_konverzija = @brKonverzija, 
                              ROI = @roi 
                          WHERE [ID rezultati] = @id";
                    red = null;
                }
                else
                {
                    cmd.CommandText = @"insert into Rezultati_kampanje(Datum_zavrsetka_kampanje,Broj_konverzija,ROI)
                                                               values(@datum,@brKonverzija,@roi);";
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
