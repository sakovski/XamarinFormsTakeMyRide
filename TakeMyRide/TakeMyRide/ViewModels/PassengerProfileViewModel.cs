using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TakeMyRide.Helpers;
using TakeMyRide.Models;
using TakeMyRide.Views;
using Xamarin.Forms;

namespace TakeMyRide.ViewModels
{
    public class PassengerProfileViewModel : BaseViewModel
    {
        public PassengerProfileViewModel()
        {
            var user = App.Database.GetUserAsync(Settings.Username).Result;
            var offers = App.Database.GetPassengerRidesOrderedByDateAsync(Settings.Username).Result;
            OffersList = new ObservableCollection<Ride>(offers);
            UserName = user.FirstName + " " + user.LastName;
            UserEmail = user.Email;
            UserTelephone = user.Telephone;
        }

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

        private string _userEmail;
        public string UserEmail
        {
            get { return _userEmail; }
            set
            {
                _userEmail = value;
                OnPropertyChanged("UserEmail");
            }
        }

        private string _userTelephone;
        public string UserTelephone
        {
            get { return _userTelephone; }
            set
            {
                _userTelephone = value;
                OnPropertyChanged("UserTelephone");
            }
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
                    var offerDetailsViewModel = InitOfferDetailsViewModel();
                    var offerDetailsPage = new OfferDetailsPage(offerDetailsViewModel);
                    await Application.Current.MainPage.Navigation.PushAsync(offerDetailsPage);
                });
            }
        }

        private OfferDetailsViewModel InitOfferDetailsViewModel()
        {
            return new OfferDetailsViewModel
            {
                Id = _selectedOffer.Id,
                DriverId = _selectedOffer.DriverId,
                DriverUsername = _selectedOffer.Driver.User.UserName,
                Driver = _selectedOffer.Driver,
                StartCity = _selectedOffer.StartCity,
                DestinationCity = _selectedOffer.DestinationCity,
                DateOfStart = _selectedOffer.DateOfStart,
                PriceForSeat = _selectedOffer.PriceForSeat,
                AmountOfSeats = _selectedOffer.AmountOfSeats,
                CarInfo = _selectedOffer.CarInfo,
                AdditionalInfo = _selectedOffer.AdditionalInfo
            };
        }
    }
}
