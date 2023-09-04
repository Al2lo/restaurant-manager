using Restoreo.Models;
using Restoreo.Views;
using Restoreo.WorkWithBD;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace Restoreo.ViewModels
{
    public class MenusViewModel : ViewModelBase
    {
        public static ICommand AddCommand;
        public static ICommand DeleteCommand;

        private static ObservableCollection<Dish> dishes = new ObservableCollection<Dish>();

        private string searchText;
        private bool searchVisible = true;
        private Dish selectedDish;

        public MenusViewModel()
        {
            dishes = DishesWorkBD.GetDishes("");
            AddCommand = new Command(ExecuteAddCommand, CanExecuteAddCommand);
            DeleteCommand = new Command(ExecuteDeleteCommand, CanExecuteDeleteCommand);

            for (int i = 0; i < Dishes.Count; i++)
            {
                foreach (var item in RegistrationViewModel.user.dishes)
                {
                    if (item.Id == Dishes[i].Id)
                    {
                        Dish dish = new Dish(Dishes[i].Id, Dishes[i].Name, Dishes[i].Description, Dishes[i].Coast);
                        dish.count = ++Dishes[i].count;
                        Dishes.RemoveAt(i);
                        Dishes.Insert(i, dish);
                    }
                }
            }
        }

        public ObservableCollection<Dish> Dishes {
            get { return dishes; }
            set {
                dishes = value;
                OnPropertyChanged(nameof(Dishes));
            }
        }
        public Dish SelectedDish
        {
            get { return selectedDish; }
            set {
                selectedDish = value;
                OnPropertyChanged(nameof(SelectedDish));
            }
        }
        public string SearchText
        {
            get { return searchText; }
            set { searchText = value;
                SearchVisible = false;
                Dishes = DishesWorkBD.GetDishes(searchText);
                for (int i = 0; i < Dishes.Count; i++)
                {
                    foreach (var item in RegistrationViewModel.user.dishes)
                    {
                        if (item.Id == Dishes[i].Id)
                        {
                            Dish dish = new Dish(Dishes[i].Id, Dishes[i].Name, Dishes[i].Description, Dishes[i].Coast);
                            dish.count = ++Dishes[i].count;
                            Dishes.RemoveAt(i);
                            Dishes.Insert(i,dish);
                        }
                    }
                }

                OnPropertyChanged(nameof(SearchText));

            }
        }

        public bool SearchVisible
        {

            get
            {
                return searchVisible;
            }
            set
            {
                searchVisible = value;
                OnPropertyChanged(nameof(SearchVisible));
            }
        }


        private void ExecuteDeleteCommand(object obj)
        {
            Dish dish = new Dish(SelectedDish.Id, SelectedDish.Name, SelectedDish.Description, SelectedDish.Coast);
            dish.count = selectedDish.count;
            if (dish.count == 0)
            {
                return;
            }
            for (int i = 0; i < RegistrationViewModel.user.dishes.Count; i++)
            {
                if (dish.Id == RegistrationViewModel.user.dishes[i].Id)
                {
                    RegistrationViewModel.user.dishes.RemoveAt(i);
                }
            }
            for (int i = 0; i < Dishes.Count; i++)
            {

                    if (dish.Id == Dishes[i].Id)
                    {

                        Dishes.RemoveAt(dish.Id);
                        dish.count--;
                        Dishes.Insert(i, dish);
                        break;
                    }
                
            };
        }

        private bool CanExecuteDeleteCommand(object arg)
        {
            if (RegistrationViewModel.user.dishes.Count >0)
            {
                return true;
            }
            return false;

        }

        private void ExecuteAddCommand(object obj)
        {
            Dish dish = new Dish(SelectedDish.Id, SelectedDish.Name, SelectedDish.Description, SelectedDish.Coast);
            dish.count = selectedDish.count;
            RegistrationViewModel.user.dishes.Add(SelectedDish);

            for (int i = 0; i < Dishes.Count; i++)
            {
                if (dish.Id == Dishes[i].Id)
                {
                    Dishes.RemoveAt(dish.Id);
                    dish.count++;
                    Dishes.Insert(i, dish);
                    break;
                }
            }
        }

        private  bool CanExecuteAddCommand(object arg)
        {
            if (RegistrationViewModel.user.dishes.Count < 5)
            {
                return true;
            }
            return false;

        }
    }
}
