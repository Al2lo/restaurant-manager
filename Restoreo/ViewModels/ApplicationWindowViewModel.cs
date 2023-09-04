using Restoreo.Models;
using Restoreo.Pages;
using Restoreo.Views;
using Restoreo.WorkWithBD;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace Restoreo.ViewModels
{
    internal class ApplicationWindowViewModel : ViewModelBase
    {
        private Page content = new ChoiceTablePage();
        private Uri source = new Uri("ChoiceTablePage.xaml", UriKind.RelativeOrAbsolute);

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

        public ICommand MoveToTables { get; }
        public ICommand MoveToMenu { get; }
        public ICommand MoveToEnd { get; }
        public ICommand MoveToAccaunt { get; }
        public ApplicationWindowViewModel()
        {
            MoveToTables = new Command(ExecuteMoveToTablesCommand, CanExecuteMoveToTablesCommand);
            MoveToMenu = new Command(ExecuteMoveToMenuCommand, CanExecuteMoveToMenuCommand);
            MoveToEnd = new Command(ExecuteMoveToEndCommand, CanExecuteMoveToEndCommand);
            MoveToAccaunt = new Command(ExecuteMoveToAccauntCommand, CanExecuteMoveToAccauntCommand);
        }


        private void ExecuteMoveToTablesCommand(object obj)
        {
            Content = new ChoiceTablePage();
            Source = new Uri("/Pages/ChoiceTablePage.xaml", UriKind.RelativeOrAbsolute);

        }
        private bool CanExecuteMoveToTablesCommand(object arg)
        {
            if (Content.GetType() != typeof(ChoiceTablePage))
            {
                return true;
            }
            return false;
        }
        private void ExecuteMoveToEndCommand(object obj)
        {
            Content = new EndPage();
            Source = new Uri("/Pages/EndPage.xaml", UriKind.RelativeOrAbsolute);

        }
        private bool CanExecuteMoveToEndCommand(object arg)
        {
            if (Content.GetType() != typeof(EndPage))
            {
                return true;
            }
            return false;
        }
        private void ExecuteMoveToAccauntCommand(object obj)
        {
            Content = new AccauntPage();
            Source = new Uri("/Pages/AccauntPage.xaml", UriKind.RelativeOrAbsolute);

        }
        private bool CanExecuteMoveToAccauntCommand(object arg)
        {
            if (Content.GetType() != typeof(AccauntPage))
            {
                return true;
            }
            return false;
        }
        private void ExecuteMoveToMenuCommand(object obj)
        {
            Content = new ChoiceMenuPage();
            Source = new Uri("/Pages/ChoiceMenuPage.xaml", UriKind.RelativeOrAbsolute);

        }
        private bool CanExecuteMoveToMenuCommand(object arg)
        {
            if (Content.GetType() != typeof(ChoiceMenuPage))
            {
                return true;
            }
            return false;
        }



        #endregion


    }
}
