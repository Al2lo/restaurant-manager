using Restoreo.Models;
using Restoreo.Views;
using Restoreo.WorkWithBD;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media.TextFormatting;

namespace Restoreo.ViewModels
{
    internal class AccauntViewModel:ViewModelBase
    {
        private string name = RegistrationViewModel.user.name;
        private string firstname = RegistrationViewModel.user.firstName;
        private string img;
        private string gender = RegistrationViewModel.user.gender;
        private string number = RegistrationViewModel.user.number;
        private List<History> histories;
        public AccauntViewModel()
        {
            img= RegistrationViewModel.user.img;
            if (img == null || img == "")
            {
                Img = "/Sources/NoAvatarImg.png";
            }
            AddPhoto = new Command(ExecuteaddPhotoCommand, CanExecuteaddPhotoCommand);
            SaveChanges = new Command(ExecuteSaveChangesCommand, CanExecuteSaveChangesCommand);
            DeletePhoto = new Command(ExecuteDeletePhotoCommand, CanExecuteDeletePhotoCommand);
            Leave = new Command(ExecuteLeaveCommand, CanExecuteLeaveCommand);
            Histories = AccauntWorkBD.GetHistory();
        }

        public List<History> Histories
        {
            get { return histories; }
            set { histories = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return name; }
            set { 
                name = value;
                OnPropertyChanged();
            }
        }
        public string FirstName
        {
            get { return firstname; }
            set
            {
                firstname = value;
                OnPropertyChanged();
            }
        }
        public string Number
        {
            get { return number; }
            set
            {
                number = value;
                OnPropertyChanged();
            }
        }
        public string Img
        {
            get { return img; }
            set
            {
                img = value;
                OnPropertyChanged();
            }
        }
        public string Gender
        {
            get { return gender; }
            set
            {
                gender = value;
                OnPropertyChanged("Gender");
            }
        }



        #region Commands
        public ICommand DeletePhoto { get; }
        public ICommand AddPhoto { get; }
        public ICommand SaveChanges { get; }
        public ICommand Leave { get; }


        private void ExecuteLeaveCommand(object obj)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            System.Windows.Application.Current.Windows[System.Windows.Application.Current.Windows.Count-2].Close();
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

        private void ExecuteaddPhotoCommand(object obj)
        {
            Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog();
            bool? respone = fileDialog.ShowDialog();
            if (respone is true)
            {
                Img = fileDialog.FileName;
            }

        }

        private bool CanExecuteaddPhotoCommand(object arg)
        {

            return true;
        }

        private void ExecuteSaveChangesCommand(object obj)
        {
            AccauntWorkBD.SaveChangesAccaunt(RegistrationViewModel.user.login, Name, FirstName, Number, Img, gender);
            RegistrationViewModel.user.name = Name;
            RegistrationViewModel.user.firstName = FirstName;
            RegistrationViewModel.user.img = Img;
            RegistrationViewModel.user.number = Number;
            RegistrationViewModel.user.gender = gender;
        }
        private bool CanExecuteSaveChangesCommand(object arg)
        {
            if (gender is null)
            {
                Gender = "";
                return true;
            }
            if (gender.Length >1)
            {
                return false;
            }
            return true;
        }


        private bool CanExecuteDeletePhotoCommand(object arg)
        {
            if (Img != "/Sources/NoAvatarImg.png")
            {
                return true;
            }
            return false;
        }

        private void ExecuteDeletePhotoCommand(object obj)
        {
            Img = "/Sources/NoAvatarImg.png";
        }


        #endregion
    }

}

