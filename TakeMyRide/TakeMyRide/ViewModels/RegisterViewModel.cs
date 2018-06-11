using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using TakeMyRide.Services;
using TakeMyRide.Validators;
using Xamarin.Forms;

namespace TakeMyRide.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private RegisterService registerService = new RegisterService();

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

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        private string _telephone;
        public string Telephone
        {
            get { return _telephone; }
            set
            {
                _telephone = value;
                OnPropertyChanged("Telephone");
            }
        }

        private DateTime _dateOfBirth = DateTime.Today;
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                _dateOfBirth = value;
                OnPropertyChanged("DateOfBirth");
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


        public Command RegisterUser
        {
            get
            {
                return new Command(async () =>
                {
                    if(!IsRegisterDataValid())
                    {
                        await Application.Current.MainPage.DisplayAlert("Given data invalid!", "", "OK");
                    }
                    else if(!await registerService.isUsernameAvailableAsync(UserName))
                    {
                        await Application.Current.MainPage.DisplayAlert("Username already in use!", "", "OK");
                    }
                    else if(!await registerService.isEmailAvailableAsync(Email))
                    {
                        await Application.Current.MainPage.DisplayAlert("Email already in use!", "", "OK");
                    }
                    else
                    {                      
                        registerService.registerUserAsync(Function, UserName, Password, FirstName, LastName, Email, Telephone, DateOfBirth);
                        await Application.Current.MainPage.Navigation.PopAsync();
                        await Application.Current.MainPage.DisplayAlert("Register succesful!", "", "OK");
                    }
                    
                });
            }
        }

        private bool IsRegisterDataValid()
        {
            return FirstName != null && Regex.IsMatch(FirstName, RegexPatterns.namePattern)
                && LastName != null && Regex.IsMatch(LastName, RegexPatterns.namePattern)
                && Telephone != null && Regex.IsMatch(Telephone, RegexPatterns.phoneNumberPattern) 
                && Email != null && Regex.IsMatch(Email, RegexPatterns.emailPattern) 
                && DatesValidators.IsDateOfBirthValid(DateOfBirth)
                && Password != null && Password != string.Empty 
                && Function != string.Empty && Function != null;
        }
    }
}
