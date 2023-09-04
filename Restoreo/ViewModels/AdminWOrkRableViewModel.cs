using Restoreo.Models;
using Restoreo.Pages;
using Restoreo.WorkWithBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Restoreo.ViewModels
{
    internal class AdminWOrkRableViewModel:ViewModelBase
    {
       public static Table table;
       public static Zakaz order;

        private Page content;
        private Uri  source ;


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



        #region Commands

        public ICommand MoveToInfoPage { get; }
        public ICommand MoveToContinuePage { get; }

        public AdminApplicationViewModels window;
        public AdminWOrkRableViewModel(Table table, Zakaz order, AdminApplicationViewModels window)
        {
            MoveToInfoPage = new Command(ExecuteMoveMoveToInfoPageCommand, CanExecuteMoveMoveToInfoPageCommand);
            MoveToContinuePage = new Command(ExecuteMoveToMoveToContinuePageCommand, CanExecuteMoveToMoveToContinuePageCommand);

            this.window = window;
            AdminWOrkRableViewModel.table = table;
            AdminWOrkRableViewModel.order = order;
            content = new InfoPageAdmin();
            source = new Uri("/Pages/InfoPageAdmin.xaml", UriKind.RelativeOrAbsolute);
        }


        private void ExecuteMoveMoveToInfoPageCommand(object obj)
        {
            Content = new InfoPageAdmin();
            Source = new Uri("/Pages/InfoPageAdmin.xaml", UriKind.RelativeOrAbsolute);

        }
        private bool CanExecuteMoveMoveToInfoPageCommand(object arg)
        {
            if (Content.GetType() != typeof(InfoPageAdmin))
            {
                return true;
            }
            return false;
        }
        private void ExecuteMoveToMoveToContinuePageCommand(object obj)
        {
            Content = new ContinuePageAdmin(window);
            Source = new Uri("/Pages/ContinuePageAdmin.xaml", UriKind.RelativeOrAbsolute);

        }
        private bool CanExecuteMoveToMoveToContinuePageCommand(object arg)
        {
            if (Content.GetType() != typeof(ContinuePageAdmin))
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
