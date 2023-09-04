using Microsoft.OData.Edm;
using Restoreo.Models;
using Restoreo.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Restoreo.WorkWithBD
{
    internal class AdminGetInfoBD:BaseWorkWithBD
    {
        public static List<int> GetOrderDishes(Zakaz order)
        {
            int id = FormingWorkBD.GetNumberOrder(order);
            string zapros = "Select NumberDish from DishesGroups where NumberOrder = @numberOrder";
            List<int> result = new List<int>();
            Connection();

            SqlCommand command = new SqlCommand(zapros, connection);
            SqlParameter parameter = new SqlParameter("@numberOrder", id);
            command.Parameters.Add(parameter);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                result.Add(reader.GetInt32(0));
            }
            DisConnect();
            return result;
        }


        public static bool ContinueOrder(Zakaz order)
        {
            DeleteOrder(order);
            DateTime dateime = DateTime.Now;
            string date = "";
            string time = "";
            date = dateime.Day.ToString() +"." + dateime.Month.ToString() + "." + dateime.Year.ToString();
            if (ControlInfoPagesAdmin.CountHours == 1)
                time = (dateime.Hour).ToString() + ":" + dateime.Minute.ToString();
            else
                time = (dateime.Hour+1).ToString() + ":" + dateime.Minute.ToString();

            string zapros = "FormingOrder @login,@tableId,@date,@time";
            Connection();
            SqlCommand command = new SqlCommand(zapros, connection);
            SqlParameter loginP = new SqlParameter("@login", order.Name);
            SqlParameter idP = new SqlParameter("@tableId", order.tableid);
            SqlParameter dateP = new SqlParameter("@date", date);
            SqlParameter timeP= new SqlParameter("@time", time);
            command.Parameters.Add(loginP);
            command.Parameters.Add(idP);
            command.Parameters.Add(dateP);
            command.Parameters.Add(timeP);
            var result = command.ExecuteNonQuery();
            DisConnect();
            if (result == 0)
            {
                return false;
            }
            return true;
        }


        public static bool DeleteOrder(Zakaz order)
        {

            string zapros = "Delete DishesGroups where NumberOrder = @numberOrder";
            Connection();
            SqlCommand command = new SqlCommand(zapros, connection);
            SqlParameter numberOrder = new SqlParameter("@numberOrder", FormingWorkBD.GetNumberOrder(order));
            command.Parameters.Add(numberOrder);
            var result = command.ExecuteNonQuery();
            DisConnect();

            Connection();
            zapros = "Delete Orders where UserLogin = @login and TableId = @tableId and Date = @date and Time = @time";
            command = new SqlCommand(zapros, connection);
            SqlParameter loginP = new SqlParameter("@login", order.Name);
            SqlParameter idP = new SqlParameter("@tableId", order.tableid);
            SqlParameter dateP = new SqlParameter("@date", order.Day);
            SqlParameter timeP = new SqlParameter("@time", order.time);
            command.Parameters.Add(loginP);
            command.Parameters.Add(idP);
            command.Parameters.Add(dateP);
            command.Parameters.Add(timeP);
            result = command.ExecuteNonQuery();
            DisConnect();
            if (result == 0)
            {
                return false;
            }
            return true;
        }

        public static ObservableCollection<AdminOrderInfo> GetAllOrdersAdmin()
        {
            ObservableCollection<AdminOrderInfo> orders = new ObservableCollection<AdminOrderInfo>();
            string zapros = "exec GetAllOrders";
            Connection();
            SqlCommand command = new SqlCommand(zapros, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                if (reader.GetString(0) == "" && reader.GetString(1) == "" && reader.GetString(2) == "" ) 
                {
                    break;
                }
                AdminOrderInfo adminOrderInfo = new AdminOrderInfo(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5), reader.GetString(6));
                orders.Add(adminOrderInfo);
            }

            return orders;
        }
    }
}
