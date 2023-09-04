using Restoreo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Restoreo.WorkWithBD
{
    internal class UsersBD:BaseWorkWithBD
    {
        public static bool ValidateUser(string login, string password,string role)
        {
            Connection();
            if (role == "Admin")  role = "User";
            else  role = "Admin";

            string zapros = "select count(*) from Users where Login = rtrim(@login) and Password = rtrim(@password) and Role = @role";
            SqlCommand command = new SqlCommand(zapros, connection);
            SqlParameter loginParam = new SqlParameter("@login", login);
            SqlParameter passwordParam = new SqlParameter("@password", password);
            SqlParameter roleParam = new SqlParameter("@role", role);
            command.Parameters.Add(loginParam);
            command.Parameters.Add(passwordParam);
            command.Parameters.Add(roleParam);
            int result = (int)command.ExecuteScalar();
            DisConnect();
            if (result == 0)
            {
                
                return true;
            }
            return false;
        }
        public static bool ValidateUser(string login, string role = "User")
        {
            Connection();

            string zapros = "select count(*) from Users where Login = rtrim(@login) and Role = rtrim(@role)";
            SqlCommand command = new SqlCommand(zapros, connection);
            SqlParameter loginParam = new SqlParameter("@login", login);
            SqlParameter roleParam = new SqlParameter("@role", role);
            command.Parameters.Add(loginParam);
            command.Parameters.Add(roleParam);
            int result = (int)command.ExecuteScalar();
            DisConnect();
            if (result == 0)
            {
                return true;
            }
            return false;
        }
        public static bool RegisterUser(string login, string password)
        {
            Connection();
            string zapros = "insert Users values(@login, @password,@role ,@login,@firstName,@number,@gender,@img, @adress)";
            SqlCommand command = new SqlCommand(zapros, connection);
            SqlParameter loginParam = new SqlParameter("@login", login);
            SqlParameter passwordParam = new SqlParameter("@password", password);
            SqlParameter role = new SqlParameter("@role", "user");
            SqlParameter addressParam = new SqlParameter("@adress", "");
            SqlParameter firstName = new SqlParameter("@firstName", "");
            SqlParameter numberParameter = new SqlParameter("@number", "");
            SqlParameter genderParameter = new SqlParameter("@gender", "");
            SqlParameter imgParameter = new SqlParameter("@img", "");

            command.Parameters.Add(loginParam);
            command.Parameters.Add(passwordParam);
            command.Parameters.Add(role);
            command.Parameters.Add(firstName);
            command.Parameters.Add(numberParameter);
            command.Parameters.Add(genderParameter);
            command.Parameters.Add(imgParameter);
            command.Parameters.Add(addressParam);
            int result = command.ExecuteNonQuery();
            DisConnect();
            return result == 1;
        }

        public static User GetUser(string login, string password, string role)
        {
            Connection();
            if (role == "Admin") role = "User";
            else role = "Admin";

            string zapros = "select * from Users where Login = @login and Password = @password and Role = @role";
            SqlCommand command = new SqlCommand(zapros, connection);
            SqlParameter loginParam = new SqlParameter("@login", login);
            SqlParameter passwordParam = new SqlParameter("@password", password);
            SqlParameter roleParam = new SqlParameter("@role", role);
            command.Parameters.Add(loginParam);
            command.Parameters.Add(passwordParam);
            command.Parameters.Add(roleParam);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                User user = new User(reader.GetString(0), reader.GetString(1), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7));
                DisConnect();
                return user;
            }
            DisConnect();
            return null;
        }

        public static User GetUser(string login,string role = "User")
        {
            Connection();
                
            string zapros = "select * from Users where Login = @login and Role = @role";
            SqlCommand command = new SqlCommand(zapros, connection);
            SqlParameter loginParam = new SqlParameter("@login", login);
            SqlParameter roleParam = new SqlParameter("@role", role);
            command.Parameters.Add(loginParam);
            command.Parameters.Add(roleParam);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                User user = new User(reader.GetString(0), reader.GetString(1), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7));
                DisConnect();
                return user;
            }
            DisConnect();
            return null;

        }

    }
}
