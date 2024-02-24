  using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing_Agencija
{
    internal class Konekcija
    {
        public SqlConnection KreirajKonekciju()
        {
            SqlConnectionStringBuilder consb = new SqlConnectionStringBuilder
            {
                DataSource = @"DESKTOP-FPO9DJI\SQLEXPRESS01",
                InitialCatalog = "baza1",
                IntegratedSecurity = true

            };
            string con = consb.ToString();
            SqlConnection konekcija = new SqlConnection(con);
            return konekcija;
        }
    }
}
