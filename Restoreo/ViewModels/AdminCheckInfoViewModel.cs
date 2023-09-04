using Restoreo.Models;
using Restoreo.WorkWithBD;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoreo.ViewModels
{
    internal class AdminCheckInfoViewModel:ViewModelBase
    {
        private User user;
        private Table table;
        private Zakaz order;
        private List<int> dishesId;
        private ObservableCollection<Dish> dishes = DishesWorkBD.GetDishes("all");
        public AdminCheckInfoViewModel()
        {
            this.order = AdminWOrkRableViewModel.order;
            this.table = AdminWOrkRableViewModel.table;
            user = UsersBD.GetUser(order.Name);
            dishesId = AdminGetInfoBD.GetOrderDishes(order);
        }


        public int Id
        {
            get { return table.id; }
        }

        public int Places
        {
            get { return table.places; }
        }

        public string Vip
        {
            get
            {
                if (table.vip)
                {
                    return "VIP";
                }
                return "Standart";
            }
        }

        public string Name
        {
            get { return user.name; }
        }
        public string Number
        {
            get { return user.number; }
        }
        public string Date
        {
            get { return order.Day; }
        }
        public string Time
        {
            get { return order.time; }
        }

        public string Firstname
        {
            get { return user.firstName; }
        }
        public string Dishes
        {
            get
            {
                string resut ="";
                for (int i = 0; i < dishesId.Count; i++)
                {
                    foreach (var dish in dishes)
                    {
                        if (dish.Id == dishesId[i])
                        {
                            if (i % 3 == 0)
                            {
                                resut += "\n" + "  "+dish.Name + ",";
                                break;
                            }
                            if (i == dishesId.Count -1)
                            {
                                resut += "  "+dish.Name + ".";
                                break;
                            }
                            resut += "  " + dish.Name + ",";
                        }
                    }
                }
                return resut;
            }
        }
        public string Coast
        {
            get
            {
                int resut = 0;
                foreach (var item in dishesId)
                {
                    foreach (var dish in dishes)
                    {
                        if (dish.Id == item)
                        {
                            resut += Int32.Parse(dish.Coast);
                        }
                    }
                }
                return resut.ToString();
            }
        }


    }
}
