using Restoreo.Views;
using Restoreo.WorkWithBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Restoreo.ViewModels
{
    internal class EndPageViewModel : ViewModelBase
    {
        private static bool wasOrder;
        public string Day
        {
            get { return TablesMapViewModelcs.Myzakaz.Day; }
        }
        public string Time
        {
            get { return TablesMapViewModelcs.Myzakaz.time; }
        }
        public int PlacesTable
        {
            get { return TablesMapViewModelcs.Myzakaz.places; }
        }
        public int IdTable
        {
            get { return TablesMapViewModelcs.Myzakaz.tableid; }
        }
        public string Vip
        {
            get
            {
                if (TablesMapViewModelcs.Myzakaz.vip)
                {
                    return "VIP";
                }
                return "Standart";
            }
        }

        public string Dishes
        {
            get
            {
                string dishes = "";
                for (int i = 0; i < RegistrationViewModel.user.dishes.Count; i++)
                {
                   
                    dishes +="\n"+ RegistrationViewModel.user.dishes[i].Name;

                }
                return dishes;
            }
        }

        public string Coast
        {
            get
            {
                int coast = 0;
                foreach (var item in RegistrationViewModel.user.dishes)
                {
                    coast += Int32.Parse(item.Coast);
                }
                return coast.ToString();
            }
        }



        #region Command

        public ICommand SaveCommand { get; }


        public EndPageViewModel()
        {
            wasOrder = FormingWorkBD.CanFormingOrder();
            SaveCommand = new Command(ExecuteSaveCommand,CanExecuteSaveCommand);
        }

        private bool CanExecuteSaveCommand(object arg)
        {
            if(RegistrationViewModel.user.table == null)
            {
                return false;
            }
            if (RegistrationViewModel.user.table.isFree == false || wasOrder )
            {
                return false;
            }
            return true;
        }

        private void ExecuteSaveCommand(object obj)
        {
            ResponseOnOrder responseOnOrderWindow = new ResponseOnOrder();

            if (FormingWorkBD.FormingOrder(TablesMapViewModelcs.Myzakaz))
            {
                foreach (var item in RegistrationViewModel.user.dishes)
                {
                    if (!FormingWorkBD.FormingDishList(TablesMapViewModelcs.Myzakaz, item))
                    {
                        return;
                    }

                }
                wasOrder = true;
                responseOnOrderWindow.DataContext = new ResponseViewModel("Столик забронирован", "/Sources/icons8-инстаграм-галочка-100.png");
            }
            else
            {
                responseOnOrderWindow.DataContext = new ResponseViewModel("Произошла ошибка", "/Sources/icons8-инстаграм-галочка-100.png");
            }
            responseOnOrderWindow.Show();
        }
        #endregion

    }

}