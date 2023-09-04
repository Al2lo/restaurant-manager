using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoreo.Models
{
    public class AdminOrderInfo
    {
        public AdminOrderInfo(string login, string firstName, string number, string date, string time, int tableId, string dishes)
        {
            Login = login;
            FirstName = firstName;
            Number = number;
            Date = date;
            Time = time;
            TableId = tableId;
            Dishes = dishes;
        }

        public string Login { get; set; }
       public string FirstName { get; set; }

       public string Number { get; set; }
       public string Date { get; set; }
       public string Time { get; set; }
        public int TableId { get; set; }
       public string Dishes { get; set; }

        
    }
}
