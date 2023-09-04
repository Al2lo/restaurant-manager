using Restoreo.WorkWithBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Restoreo.ViewModels
{
    internal class ControlInfoPagesAdmin:ViewModelBase
    {

        private static int countHours = 1;


        public static int CountHours
        {
            get { return countHours; }
            set
            {
                countHours = value;
            }
        }

        public AdminApplicationViewModels window;
        public ControlInfoPagesAdmin(AdminApplicationViewModels widnow)
        {
            this.window = widnow;
            SetOneHour = new Command(ExecuteSetOneHour, CanExecuteSetOneHour);
            SetTwoHour = new Command(ExecuteSetTwoHour, CanExecuteSetTwoHour);
            ContinueOrder = new Command(ExecuteContinueOrder, CanExecutContinueOrder);
            DeleteOrder = new Command(ExecuteDeleteOrder, CanExecuteDeleteOrder);
            
        }

























        #region Command

        public ICommand SetOneHour { get; }
        public ICommand SetTwoHour { get; }
        public ICommand ContinueOrder { get; }
        public ICommand DeleteOrder { get; }

        private void ExecuteSetOneHour(object obj)
        {
            CountHours = 1;
        }

        private bool CanExecuteSetOneHour(object arg)
        {
            if (CountHours != 1)
            {
                return true;
            }
            return false;
        }



        private void ExecuteSetTwoHour(object obj)
        {
            CountHours = 2;
        }

        private bool CanExecuteSetTwoHour(object arg)
        {
            if (CountHours != 2)
            {
                return true;
            }
            return false;
        }



        private void ExecuteContinueOrder(object obj)
        {
            if (!AdminGetInfoBD.ContinueOrder(AdminWOrkRableViewModel.order))
            {
                MessageBox.Show("Error");
            }
            window.Refresh();
            System.Windows.Application.Current.MainWindow.Close();

        }

        private bool CanExecutContinueOrder(object arg)
        {
            return true;
        }


        private void ExecuteDeleteOrder(object obj)
        {
            if (!AdminGetInfoBD.DeleteOrder(AdminWOrkRableViewModel.order))
            {
                MessageBox.Show("Error");
            }
            window.Refresh();
            System.Windows.Application.Current.Windows[System.Windows.Application.Current.Windows.Count-1].Close();
        }

        private bool CanExecuteDeleteOrder(object arg)
        {
            return true;
        }

        #endregion

    }
}
