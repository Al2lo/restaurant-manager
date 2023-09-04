using Restoreo.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Restoreo.ViewModels
{
    public class AdminApplicationViewModels:ViewModelBase
    {
        public Page content;
        public  Uri  source ;

        public Page Content
        {
            get { return content; }
            set
            {
                if (content == value)
                {
                    return;
                }
                content = value;
                OnPropertyChanged(nameof(Content));
            }
        }
        public Uri Source
        {
            get { return source; }
            set
            {
                if (source == value)
                {
                    return;
                }
                source = value;
                OnPropertyChanged(nameof(Source));
            }
        }


        public void Refresh()
        {
            Content = new AdminChoiceTable(this);
            Source = new Uri("AdminChoiceTable.xaml", UriKind.RelativeOrAbsolute);
        }

        #region Commands

        public ICommand Leave { get; }
        public ICommand MoveToTables { get; }
        public ICommand MoveToMenu { get; }

        public AdminApplicationViewModels()
        {
            content = new AdminChoiceTable(this);
            source = new Uri("AdminChoiceTable.xaml", UriKind.RelativeOrAbsolute);
            MoveToTables = new Command(ExecuteMoveToTablesCommand, CanExecuteMoveToTablesCommand);
            MoveToMenu = new Command(ExecuteMoveToMenuCommand, CanExecuteMoveToMenuCommand);
            Leave = new Command(ExecuteLeaveCommand, CanExecuteLeaveCommand);
        }


        private void ExecuteMoveToTablesCommand(object obj)
        {
            Content = new AdminChoiceTable(this);
            Source = new Uri("/Pages/AdminChoiceTable.xaml", UriKind.RelativeOrAbsolute);

        }
        private bool CanExecuteMoveToTablesCommand(object arg)
        {
            if (Content.GetType() != typeof(ChoiceTablePage))
            {
                return true;
            }
            return false;
        }
     
        private void ExecuteMoveToMenuCommand(object obj)
        {
            Content = new AdminMenuWork();
            Source = new Uri("/Pages/AdminMenuWork.xaml", UriKind.RelativeOrAbsolute);

        }
        private bool CanExecuteMoveToMenuCommand(object arg)
        {
            if (Content.GetType() != typeof(ChoiceMenuPage))
            {
                return true;
            }
            return false;
        }




        private void ExecuteLeaveCommand(object obj)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            System.Windows.Application.Current.Windows[System.Windows.Application.Current.Windows.Count - 2].Close();
            TablesMapViewModelcs.Myzakaz.places = 0;
            TablesMapViewModelcs.Myzakaz.tableid = 0;
        }
        private bool CanExecuteLeaveCommand(object arg)
        {
            if (RegistrationViewModel.user != null)
            {
                return true;
            }
            return false;
        }
        #endregion


    }
}
