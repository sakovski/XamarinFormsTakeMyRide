﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TakeMyRide.Helpers;
using TakeMyRide.Models;
using TakeMyRide.Views;
using Xamarin.Forms;

namespace TakeMyRide.ViewModels
{
    public class DriverProfileViewModel : BaseViewModel
    {
        public DriverProfileViewModel()
        {
            var user = App.Database.GetUserAsync(Settings.Username).Result;
            var driver = App.Database.GetDriverAsync(Settings.Username).Result;
            var offers = App.Database.GetDriverRidesOrderedByDateAsync(Settings.Username).Result;
            OffersList = new ObservableCollection<Ride>(offers);
            DriverName = user.FirstName + " " + user.LastName;
            DriverEmail = user.Email;
            DriverTelephone = user.Telephone;
            DriverRating = driver.RatingAvarage;
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

        private string _driverName;
        public string DriverName
        {
            get { return _driverName; }
            set
            {
                _driverName = value;
                OnPropertyChanged("DriverName");
            }
        }

        private string _driverEmail;
        public string DriverEmail
        {
            get { return _driverEmail; }
            set
            {
                _driverEmail = value;
                OnPropertyChanged("DriverEmail");
            }
        }

        private string _driverTelephone;
        public string DriverTelephone
        {
            get { return _driverTelephone; }
            set
            {
                _driverTelephone = value;
                OnPropertyChanged("DriverTelephone");
            }
        }

        private float _driverRating;
        public float DriverRating
        {
            get { return _driverRating; }
            set
            {
                _driverRating = value;
                OnPropertyChanged("DriverRating");
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
