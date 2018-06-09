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
    }
}
