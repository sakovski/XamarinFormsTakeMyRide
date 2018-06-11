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
	public partial class OfferDetailsPage : ContentPage
	{
		public OfferDetailsPage (OfferDetailsViewModel offerDetailsViewModel)
		{
			InitializeComponent();
            BindingContext = offerDetailsViewModel;
		}
	}
}