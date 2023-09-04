using Restoreo.Models;
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
    internal class RegistrationViewModel:ViewModelBase
    {
        #region Private Fields
        public static User user;
        private string login = "";
        private string password = "";
        private string messageLogin = "";
        private string messagePassword = "";
        private string signOrRegist = "Sign up";
        private string userType = "Admin";
        private bool check = false;
        private string enterButtonText = "Авторизация";

        #endregion

        #region Public Fields

        public string Login
        {
            get
            {   return login;}
            set
            {
                if (value.Length > 25)
                {
                    login = "";
                    messageLogin = "Логин не может превышать 25 символов";
                    OnPropertyChanged(nameof(Login));
                    OnPropertyChanged(nameof(messageLogin));
                    return;
                }
                if (login == value)
                {
                    return;
                }
                login = value;
                ValidateLogin();
                OnPropertyChanged(nameof(Login));
                OnPropertyChanged(nameof(messageLogin));
            }
        }
        public string SignOrRegist
        {
            get { return signOrRegist; }
            set { signOrRegist = value; OnPropertyChanged(); }
        }
        public string EnterButtonText
        {
            get { return enterButtonText; }
            set { enterButtonText = value; OnPropertyChanged(); }
        }
        public bool Check
        {
            get { return check; }
            set { check = value; OnPropertyChanged(); }
        }
        public string UserType
        {
            get { return userType; }
            set { userType = value; OnPropertyChanged(); }
        }
        public string Password
        {
            get { return password; }
            set
            {
                if (value.Length > 25)
                {
                    password = "";
                    messagePassword = "Пароль не может превышать 25 символов";
                    OnPropertyChanged(nameof(messagePassword));
                    OnPropertyChanged(nameof(Password));
                    return;
                }
                if (password == value)
                {
                    return;
                }
                password = value;
                ValidatePassword();
                OnPropertyChanged(nameof(Password));
                OnPropertyChanged(nameof(messagePassword));
            }
        }

        public string MessageLogin
        {
            get { return messageLogin; }
            set
            {
                if (messageLogin == value)
                {
                    return;
                }
                messageLogin = value;
                OnPropertyChanged();
            }
        }

        public string MessagePassword
        {
            get { return messagePassword; }
            set
            {
                if (messagePassword == value)
                {
                    return;
                }
                messagePassword = value;
                
                OnPropertyChanged();
            }
        }

        #endregion


        #region Commands

        public ICommand UserTypeReverseCommand { get; }
        public ICommand ReversSignCommand { get; }
        public ICommand RegisterCommand { get; }


        public RegistrationViewModel()
        {
            UserTypeReverseCommand = new Command(ExecuteUserTypeReverseCommand, CanExecuteUserTypeReverseCommand);
            ReversSignCommand = new Command(ExecuteReversSignCommandCommand, CanExecuteReversSignCommandCommand);
            RegisterCommand = new Command(ExecuteRegisterCommand, CanExecuteRegisterCommand);
        }

        private void ExecuteRegisterCommand(object obj)
        {
            if (signOrRegist == "Log in")
            {
                if (UsersBD.ValidateUser(Login))
                {
                    if (UsersBD.RegisterUser(Login, Password))
                    {
                        user = new User(Login, Password);
                        ApplicationWindow window = new ApplicationWindow();
                        window.Show();
                        System.Windows.Application.Current.MainWindow.Close();
                    }
                }
                else
                {
                    Login = "";
                    Password = "";
                    Check = false;
                    MessageLogin = "Пользователь с таким логином существует";
                    MessagePassword = "Пользователь с таким логином существует";
                    return;

                }
            }
            else
            {
                if (!UsersBD.ValidateUser(Login,Password, UserType))
                {

                    user = UsersBD.GetUser(Login, Password, UserType);
                    if (UserType == "User")
                    {
                        AdminApplicationWindow window = new AdminApplicationWindow();
                        window.Show();
                    }
                    else
                    {
                        ApplicationWindow window = new ApplicationWindow();
                        window.Show();
                    }
                    System.Windows.Application.Current.MainWindow.Close();
                }
                else
                {
                    Login = "";
                    Password = "";
                    Check = false;
                    MessagePassword = "Попробуйте поменять Пароль";
                    MessageLogin = "Попробуйте поменять Логин";

                }
            }

        }

        private bool CanExecuteRegisterCommand(object arg)
        {
            if (messageLogin == "" && messagePassword == "")
            {
                if (SignOrRegist == "Log in")
                {
                    if (Check)
                    {
                        return true;
                    }
                    return false;
                }
                return true;
            }
            return false;
        }



        private bool CanExecuteReversSignCommandCommand(object obj)
        {
            return true;
        }
        private void ExecuteReversSignCommandCommand(object obj)
        {
            if (signOrRegist == "Sign up")
            { SignOrRegist = "Log in"; EnterButtonText = "Регистрация"; }
            else
            { SignOrRegist = "Sign up"; EnterButtonText = "Авторизация"; }

            Login = "";
            Password = "";
            Check = false;
            OnPropertyChanged(nameof(SignOrRegist));
        }

        private bool CanExecuteUserTypeReverseCommand(object obj)
        {
            return true;
        }
        private void ExecuteUserTypeReverseCommand(object obj)
        {
            if (userType == "User")
                UserType = "Admin";
            else
                UserType = "User";
  
            Login = "";
            Password = "";
            OnPropertyChanged(nameof(UserType));
        }



        #endregion


        #region Methods

        private void ValidateLogin()
        {
            if (signOrRegist == "Log in")
            {
                if (login == "")
                {
                    messageLogin = "Введите логин";
                    return;
                }
                else if (login[0] == ' ')
                {
                    messageLogin = "Нельзя начинать логин с симовала пробел";
                    return;
                }
                else if (!UsersBD.ValidateUser(login, password, UserType))
                {
                    MessageLogin = "Пользователь с таким логином существует";
                    Check = false;
                    return;
                }
                else if (UserType == "User")
                {
                    messageLogin = "Нельзя регистрировать учетную запись админа";
                    return;
                }
            }
            messageLogin = "";
            return;
        }


        private void ValidatePassword()
        {
            if (signOrRegist == "Log in")
            {
                if (password == "")
                {
                    messagePassword = "Введите пароль";
                    Check = false;
                    return;
                }
                else if (password[0] == ' ')
                {
                    messagePassword = "Нельзя начинать пароль с симовала пробел";
                    Check = false;
                    return;
                }
                else if (!UsersBD.ValidateUser(login, password,UserType))
                {
                    Check = false;
                    return;
                }
                else if (UserType == "User")
                {
                    messagePassword = "Нельзя регистрировать учетную запись админа";
                    Check = false;
                    return ;
                }
            }
            messagePassword = "";
            return;
        }
        #endregion
    }
}
