using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Restoreo.WorkWithBD
{
    internal class BaseWorkWithBD
    {
        public static SqlConnection connection;
        private static string connectionString = ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString;

        public static void Connection()
        {
            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch (SqlException e)
            {

                MessageBox.Show(e.Message);
            }
        }
        public static void DisConnect()
        {
            connection.Close();
        }
    }
}
