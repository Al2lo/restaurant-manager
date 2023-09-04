using Restoreo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restoreo.ViewModels;

namespace Restoreo.WorkWithBD
{
    internal class AccauntWorkBD:BaseWorkWithBD
    {
        public static bool SaveChangesAccaunt(string login,string name,string firstName,string number,string img,string gender)
        {
            Connection();
            string zapros = "update Users set Name = @name, FirstName = @firstName, Number = @number,Img = @img,Gender = @gender where Login = @login";
            SqlCommand command = new SqlCommand(zapros, connection);
            SqlParameter nameParameter = new SqlParameter("@name", name);
            SqlParameter firstNameParameter = new SqlParameter("@firstName", firstName);
            SqlParameter numberParameter = new SqlParameter("@number", number);
            SqlParameter imgParameter = new SqlParameter("@img", img);
            SqlParameter genderParameter = new SqlParameter("@gender", gender);
            SqlParameter loginParameter = new SqlParameter("@login", login);
          
            command.Parameters.Add(nameParameter);
            command.Parameters.Add(firstNameParameter);
            command.Parameters.Add(numberParameter);
            command.Parameters.Add(imgParameter);
            command.Parameters.Add(genderParameter);
            command.Parameters.Add(loginParameter);

            int response = command.ExecuteNonQuery();

            DisConnect();

            if (response == 1)
            {
                return true;
            }
            return false;


        }

        public static List<History> GetHistory()
        {
            List<History> history = new List<History>();
            string zapros = "select Orders.TableId, Tables.Places,Orders.Date, Orders.Time  from Orders inner join Tables on Orders.TableId = Tables.Id\r\nwhere (DATEPART(HOUR,GETDATE()) >= CAST(Substring(Orders.Time,0,CHARINDEX(':',Orders.Time))as int) and DATEPART(DAY,GETDATE()) = CAST(SUBSTRING(Orders.Date,0,CHARINDEX('.',Orders.Date))as int))\r\nor (DATEPART(DAY,GETDATE()) > CAST(SUBSTRING(Orders.Date,0,CHARINDEX('.',Orders.Date))as int))\r\nand DATEPART(MONTH,GETDATE()) >=CAST(SUBSTRING(Orders.Date,Charindex('.',Orders.date)+1,charindex('.',Orders.Date,charindex('.',Orders.Date))-2)as int)\r\nand DATEPART(YEAR,GETDATE()) >=cast (SUBSTRING(Orders.Date,CHARINDEX('.',Orders.Date,Charindex('.',Orders.Date)+1) +1, DATALENGTH(Orders.Date)) as int )\r\nand Orders.UserLogin = @userLogin";
            Connection();
            SqlCommand command = new SqlCommand(zapros, connection);
            SqlParameter userLoginParameter = new SqlParameter("@userLogin", RegistrationViewModel.user.login);
            command.Parameters.Add(userLoginParameter);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                History historyItem = new History(reader.GetInt32(0) +1,reader.GetInt32(1),reader.GetString(2),reader.GetString(3));
                history.Add(historyItem);
            }

            return history;

        }
    }
}
