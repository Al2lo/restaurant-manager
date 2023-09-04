using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Restoreo.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Coast { get; set; }
        public int count { get; set; }

        public Dish(int id, string name, string description, string coast)
        {
            Id = id;
            Name = name;
            Description = description;
            Coast = coast;
        }

    }
}
