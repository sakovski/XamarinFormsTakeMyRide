using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeMyRide.ViewModels;
using TakeMyRide.Views;
using Xamarin.Forms;

namespace TakeMyRide
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            BindingContext = new LoginViewModel();
		}

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            string logintext = LoginEntry.Text;
            string passwordtext = PasswordEntry.Text;
            if(false) //if login password valid
            {
                Navigation.PushAsync(new MainMenuPage());
            }
            else
            {
                DisplayAlert("Log in failed!", "Wrong password!", "OK");
            }
        }

        private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}
