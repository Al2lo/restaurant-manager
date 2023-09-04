using Restoreo.Models;
using Restoreo.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Restoreo.WorkWithBD
{
    internal class FormingWorkBD:BaseWorkWithBD
    {

        public static bool CanFormingOrder()
        {
            Connection();
            string zapros = "select Orders.TableId, Tables.Places,Orders.Date, Orders.Time  from Orders inner join Tables on Orders.TableId = Tables.Id\r\nwhere (DATEPART(HOUR,GETDATE()) <= CAST(Substring(Orders.Time,0,CHARINDEX(':',Orders.Time))as int) and DATEPART(DAY,GETDATE()) = CAST(SUBSTRING(Orders.Date,0,CHARINDEX('.',Orders.Date))as int) and Orders.UserLogin = @login)\r\nor (DATEPART(DAY,GETDATE()) < CAST(SUBSTRING(Orders.Date,0,CHARINDEX('.',Orders.Date))as int))\r\nand DATEPART(MONTH,GETDATE()) <=CAST(SUBSTRING(Orders.Date,Charindex('.',Orders.date)+1,charindex('.',Orders.Date,charindex('.',Orders.Date))-2)as int)\r\nand DATEPART(YEAR,GETDATE()) <=cast (SUBSTRING(Orders.Date,CHARINDEX('.',Orders.Date,Charindex('.',Orders.Date)+1) +1, DATALENGTH(Orders.Date)) as int )\r\nand Orders.UserLogin = @login";
            SqlCommand command = new SqlCommand(zapros, connection);
            SqlParameter loginParameter = new SqlParameter("@login", RegistrationViewModel.user.login);
            command.Parameters.Add(loginParameter);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                DisConnect();
                return true;
            }
            return false;

        }
        public static bool FormingOrder(Zakaz order)
        {
            Connection();
            string zapros = "FormingOrder @loginParam,@tableidParam,@dateParam,@timeParam;";
            SqlCommand command = new SqlCommand(zapros, connection);
            SqlParameter loginParam = new SqlParameter("@loginParam", order.Name);
            SqlParameter tableidPrta = new SqlParameter("@tableidParam", order.tableid);
            SqlParameter dateParam = new SqlParameter("@dateParam", order.Day);
            SqlParameter timeParam = new SqlParameter("@timeParam", order.time);
            command.Parameters.Add(loginParam);
            command.Parameters.Add(tableidPrta);
            command.Parameters.Add(dateParam);
            command.Parameters.Add(timeParam);

            var ret = command.ExecuteScalar();

            DisConnect();
            if (ret is object)
            {
                return true;
            }
            return false;
        }

        public static bool FormingDishList(Zakaz order,Dish dish)
        {
            int id = GetNumberOrder(order);
            if (id == -1)
            {
                return false;
            }

            Connection();
            string zapros = "FormingDishList @numberOrder, @numberDish";
            SqlCommand command = new SqlCommand(zapros, connection);
            SqlParameter numberOrder = new SqlParameter("@numberOrder", id);
            SqlParameter numberDish = new SqlParameter("@numberDish", dish.Id);
            command.Parameters.Add(numberOrder);
            command.Parameters.Add(numberDish);

            var ret = command.ExecuteScalar();

            DisConnect();
            if (ret is object)
            {
                return true;
            }
            return false;
        }


        public static int GetNumberOrder(Zakaz order)
        {
            int id = -1;
            Connection();
            string prezapros = "select Orders.Id from Orders where UserLogin = @userLogin and TableId = @tableId and Date = @date and Time = @time";
            SqlCommand command = new SqlCommand(prezapros, connection);
            SqlParameter loginParam = new SqlParameter("@userLogin", order.Name);
            SqlParameter tableidPrta = new SqlParameter("@tableId", order.tableid);
            SqlParameter dateParam = new SqlParameter("@date", order.Day);
            SqlParameter timeParam = new SqlParameter("@time", order.time);
            command.Parameters.Add(loginParam);
            command.Parameters.Add(tableidPrta);
            command.Parameters.Add(dateParam);
            command.Parameters.Add(timeParam);

            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            id = reader.GetInt32(0);
            DisConnect();
            return id;
        }
    }
}
