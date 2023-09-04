using Restoreo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoreo.WorkWithBD
{
    internal class TableBD:BaseWorkWithBD
    {
        public static ObservableCollection<Table> GetTables()
        {
            ObservableCollection<Table> tables = new ObservableCollection<Table>();
            string zapros = "Select * from Tables";
            Connection();
            SqlCommand command = new SqlCommand(zapros, connection);
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                Table table = new Table(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetInt32(6), reader.GetInt32(7), reader.GetString(8));
                tables.Add(table);
            }
            DisConnect();
            return tables;
        }

        public static List<Zakaz> GetOrders()
        {
            List<Zakaz> orders = new List<Zakaz>();
            string zapros = "Select * from Orders";
            Connection();
            SqlCommand command = new SqlCommand(zapros, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Zakaz order = new Zakaz(reader.GetString(1),reader.GetInt32(2),reader.GetString(3),reader.GetString(4));
                orders.Add(order);
            }
            DisConnect();
            return orders;
        }
    }
}
