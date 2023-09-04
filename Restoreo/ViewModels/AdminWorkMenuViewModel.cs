using Restoreo.Models;
using Restoreo.Views;
using Restoreo.WorkWithBD;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Restoreo.ViewModels
{
    internal class AdminWorkMenuViewModel:ViewModelBase
    {
        private ObservableCollection<Dish> dishes;

        private string searchText ="";
        private bool searchVisible = true;
        private string nameDish="";
        private string coastDish = "";
        private string descriprionDish = "";
        private Dish selectedDish;

        public ObservableCollection<Dish> Dishes
        {
            get { return dishes; }
            set { dishes = value; OnPropertyChanged(nameof(Dishes)); }
        }


        public AdminWorkMenuViewModel()
        {
            Dishes = DishesWorkBD.GetDishes("");
            IsertCommand = new Command(ExecuteIsertCommand, CanExecuteIsertCommand);
            DeleteCommand = new Command(ExecuteDeleteCommand, CanExecuteDeleteCommand);
            UpdateCommand = new Command(ExecuteUpdateCommand, CanExecuteUpdateCommand);
        }


        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                SearchVisible = false;
                Dishes = null;
                Dishes = DishesWorkBD.GetDishes(searchText);
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

        public string NameDish
        {
            get { return nameDish; }
            set { nameDish = value;OnPropertyChanged(nameof(NameDish)); }
        }
        public string CoastDish
        {
            get { return coastDish; }
            set { coastDish = value; OnPropertyChanged(nameof(CoastDish));  }
        }
        public string DescriptionDish
        {
            get { return descriprionDish; }
            set { descriprionDish = value; OnPropertyChanged(nameof(DescriptionDish));  }
        }

        public Dish SelectedDish
        {
            get { return selectedDish; }
            set
            {
                if (value == null)
                {
                    return;
                }
                selectedDish = value;
                NameDish = selectedDish.Name;
                CoastDish = selectedDish.Coast;
                DescriptionDish = selectedDish.Description;
                OnPropertyChanged(nameof(SelectedDish));
            }
        }



        #region Command

        public ICommand IsertCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand UpdateCommand { get; }

        private void ExecuteIsertCommand(object obj)
        {
            if (DishesWorkBD.InsertDish(NameDish, DescriptionDish, CoastDish))
            {
                ResponseOnOrder response = new ResponseOnOrder();
                response.DataContext = new ResponseViewModel("Данные изменены", "/Sources/icons8-инстаграм-галочка-100.png");
                Dishes = DishesWorkBD.GetDishes(SearchText);
                response.Show();
                return;
            }
            MessageBox.Show("error");
        }

        private bool CanExecuteIsertCommand(object arg)
        {
            return true;
        }

        private void ExecuteDeleteCommand(object obj)
        {
            Dish newDish = new Dish(SelectedDish.Id, NameDish, DescriptionDish, CoastDish);
            if (DishesWorkBD.DeleteDish(newDish))
            {
                ResponseOnOrder response = new ResponseOnOrder();
                response.DataContext = new ResponseViewModel("Данные удалены", "/Sources/icons8-инстаграм-галочка-100.png");
                Dishes = DishesWorkBD.GetDishes(SearchText);
                response.Show();
                return;
            }
            MessageBox.Show("error");
        }

        private bool CanExecuteDeleteCommand(object arg)
        {
            return true;
        }


        private void ExecuteUpdateCommand(object obj)
        {
            Dish newDish = new Dish(SelectedDish.Id, NameDish, DescriptionDish, CoastDish);
            if (DishesWorkBD.UpdateDish(newDish))
            {
                ResponseOnOrder response = new ResponseOnOrder();
                response.DataContext = new ResponseViewModel("Данные изменены", "/Sources/icons8-инстаграм-галочка-100.png");
                Dishes = DishesWorkBD.GetDishes(SearchText);
                response.Show();
                return;
            }
            MessageBox.Show("error");
        }

        private bool CanExecuteUpdateCommand(object arg)
        {
            return true;
        }
        #endregion

    }
}
