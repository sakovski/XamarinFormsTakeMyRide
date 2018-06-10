using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TakeMyRide.Models;
using Xamarin.Forms;

namespace TakeMyRide.ViewModels
{
    public class OffersListViewModel : BaseViewModel
    {
        public OffersListViewModel()
        {
            var offers = App.Database.GetRidesAsync();
            OffersList = new ObservableCollection<Ride>(offers.Result);
        }

        private Ride _selectedOffer;
        public Ride SelectedOffer
        {
            get { return _selectedOffer; }
            set
            {
                _selectedOffer = value;
                if (_selectedOffer == null)
                {
                    return;
                }
                SelectOffer.Execute(_selectedOffer);
                _selectedOffer = null;
                OnPropertyChanged("SelectedOffer");
            }
        }

        private ObservableCollection<Ride> _offersList;
        public ObservableCollection<Ride> OffersList
        {
            get
            {
                return _offersList;
            }
            set
            {
                _offersList = value;
                OnPropertyChanged("OffersList");
            }
        }

        public Command SelectOffer
        {
            get
            {
                return new Command(async () =>
                {
                    //var visitDetailsViewModel = InitVisitDetailsViewModel();
                    // var visitDetailsPage = new VisitDetailsPage(visitDetailsViewModel);
                    //await Application.Current.MainPage.Navigation.PushAsync(visitDetailsPage);
                    await Application.Current.MainPage.DisplayAlert("Selected Offer", "", "OK");
                });
            }
        }
    }
}
