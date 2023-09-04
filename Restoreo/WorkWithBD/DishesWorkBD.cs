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
    internal class DishesWorkBD:BaseWorkWithBD
    {
        public static ObservableCollection<Dish> GetDishes(string name)
        {
            Connection();
            ObservableCollection<Dish> dishes = new ObservableCollection<Dish>();
            string zapros = "Select * from Dishes where Name like @name";
            SqlCommand command = new SqlCommand(zapros, connection);
            if (name != "" && name != "all" && name != "все" && name != null)
            {
                name.Insert(0, "%");
                name += "%";
            }
            else { name = "%%"; }

            SqlParameter parameter = new SqlParameter("@name", name);
            command.Parameters.Add(parameter);
            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                Dish dish = new Dish(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                dishes.Add(dish);
            }

            return dishes;


        }

        public static bool InsertDish(string name,string description,string coast)
        {
            Connection();
            string zapros = "InsertDish @name, @description, @coast";
            SqlCommand command = new SqlCommand(zapros, connection);
            SqlParameter parameterName = new SqlParameter("@name", name);
            SqlParameter parameterDescr = new SqlParameter("@description", description);
            SqlParameter parameterCoast = new SqlParameter("@coast",coast);
            command.Parameters.Add(parameterName);
            command.Parameters.Add(parameterDescr);
            command.Parameters.Add(parameterCoast);

            int result = command.ExecuteNonQuery();
            DisConnect();
            if (result == 0)
            {
                return false;
            }
            return true;
        }

        public static bool DeleteDish(Dish dish)
        {
            Connection();
            string zapros = "Delete Dishes where Id = @id";
            SqlCommand command = new SqlCommand(zapros, connection);
            SqlParameter parameterId = new SqlParameter("@id", dish.Id);
            command.Parameters.Add(parameterId);

            int result = command.ExecuteNonQuery();
            DisConnect();
            if (result == 0)
            {
                return false;
            }
            return true;
        }

        public static bool UpdateDish(Dish dish)
        {
            Connection();
            string zapros = "Update Dishes set Name = @name, Description = @description, Coast = @coast where Id = @id";
            SqlCommand command = new SqlCommand(zapros, connection);
            SqlParameter parameterName = new SqlParameter("@name", dish.Name);
            SqlParameter parameterDescr = new SqlParameter("@description", dish.Description);
            SqlParameter parameterCoast = new SqlParameter("@coast", dish.Coast);
            SqlParameter parameterId = new SqlParameter("@id", dish.Id);
            command.Parameters.Add(parameterName);
            command.Parameters.Add(parameterDescr);
            command.Parameters.Add(parameterCoast);
            command.Parameters.Add(parameterId);

            int result = command.ExecuteNonQuery();
            DisConnect();
            if (result == 0)
            {
                return false;
            }
            return true;
        }

    }
}
