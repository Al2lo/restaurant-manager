using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoreo.Models
{
    internal class Zakaz
    {
        public string Name { get; set; }
        public int tableid { get; set; }
        public string Day { get; set; }
        public string time { get; set; }
        public int places { get; set; }

        public bool vip { get; set; }

        public Zakaz(string name, int tableid, string day, string time)
        {
            Name = name;
            this.tableid = tableid;
            Day = day;
            this.time = time;
        }
        public Zakaz()
        { }
    }
}
