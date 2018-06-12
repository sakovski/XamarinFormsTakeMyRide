using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeMyRide.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TakeMyRide.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PassengerProfilePage : ContentPage
	{
        PassengerProfileViewModel passengerProfileViewModel;
        public PassengerProfilePage ()
		{
            passengerProfileViewModel = new PassengerProfileViewModel();
			InitializeComponent();
            BindingContext = passengerProfileViewModel;
		}

        private void RateSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            //passengerProfileViewModel.AddRateToUser((float)e.NewValue);
        }
    }
}