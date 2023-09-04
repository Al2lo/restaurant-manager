using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoreo.Models
{
    internal class History
    {
        public History()
        {
        }

        public int IdTable { get; set; }
        public int placesTable { get; set; }
        public string Date{ get; set; }
        public string Time { get; set; }

        public History(int idTable, int placesTable, string date, string time)
        {
            IdTable = idTable;
            this.placesTable = placesTable;
            Date = date;
            Time = time;
        }
    }
}
