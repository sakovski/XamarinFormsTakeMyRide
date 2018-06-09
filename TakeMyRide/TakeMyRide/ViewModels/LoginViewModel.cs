using System;
using System.Collections.Generic;
using System.Text;
using TakeMyRide.Services;
using TakeMyRide.Views;
using Xamarin.Forms;

namespace TakeMyRide.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        private LoginService loginService = new LoginService();

        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged("UserName");
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        private string __function;
        public string Function
        {
            get { return __function; }
            set
            {
                __function = value;
                OnPropertyChanged("Function");
            }
        }

        public Command LoginUser
        {
            get
            {
                return new Command(async () =>
                {
                    if(await loginService.loginUserAsync(UserName, Password, Function))
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new MainMenuPage());
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Wrong username or password!", "Check if username and password match or create new account!", "OK");
                    }
                });
            }
        }

        public Command RegisterUser
        {
            get
            {
                return new Command(async () =>
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
                });
            }
        }
    }
}
