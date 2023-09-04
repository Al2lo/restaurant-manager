using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoreo.Models
{
    internal class User
    {
        public string login { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string firstName { get; set; }
        public string number { get; set; }
        public string gender { get; set; }
        public string img { get; set; }
        public Table  table{get;set;}
        public List<Dish> dishes = new List<Dish>();

        public User(string login,string password)
        {
            this.login = login;
            this.password = password;
            this.name = login;
        }
        public User(string login, string password, string name, string firstName, string number, string gender, string img) 
        {
            this.login = login;
            this.password = password;
            this.name = name;
            this.firstName = firstName;
            this.number = number;
            this.gender = gender;
            this.img = img;
        }
    }
}
