using System;
using System.Collections.Generic;
using System.Text;
using TakeMyRide.Models;
using Xamarin.Forms;

namespace TakeMyRide.ViewModels
{
    public class OfferDetailsViewModel : BaseViewModel
    {
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

        private int _driverId;
        public int DriverId
        {
            get { return _driverId; }
            set
            {
                _driverId = value;
                OnPropertyChanged("DriverId");
            }
        }

        private string _driverUsername;
        public string DriverUsername
        {
            get { return _driverUsername; }
            set
            {
                _driverUsername = value;
                OnPropertyChanged("DriverUsername");
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

        private Driver _driver;
        public Driver Driver
        {
            get { return _driver; }
            set
            {
                _driver = value;
                OnPropertyChanged("Driver");
            }
        }

        private string _startCity;
        public string StartCity
        {
            get { return _startCity; }
            set
            {
                _startCity = value;
                OnPropertyChanged("StartCity");
            }
        }

        private string _destinationCity;
        public string DestinationCity
        {
            get { return _destinationCity; }
            set
            {
                _destinationCity = value;
                OnPropertyChanged("DestinationCity");
            }
        }

        private DateTime _dateOfStart;
        public DateTime DateOfStart
        {
            get { return _dateOfStart; }
            set
            {
                _dateOfStart = value;
                OnPropertyChanged("DateOfStart");
            }
        }

        private TimeSpan _timeOfStart;
        public TimeSpan TimeOfStart
        {
            get { return DateOfStart.TimeOfDay; }
            set
            {
                _timeOfStart = value;
                OnPropertyChanged("TimeOfStart");
            }
        }

        private decimal _priceForSeat;
        public decimal PriceForSeat
        {
            get { return _priceForSeat; }
            set
            {
                _priceForSeat = value;
                OnPropertyChanged("PriceForSeat");
            }
        }

        private int _amountOfSeats;
        public int AmountOfSeats
        {
            get { return _amountOfSeats; }
            set
            {
                _amountOfSeats = value;
                OnPropertyChanged("AmountOfSeats");
            }
        }

        private string _carInfo;
        public string CarInfo
        {
            get { return _carInfo; }
            set
            {
                _carInfo = value;
                OnPropertyChanged("CarInfo");
            }
        }

        private string _additionalInfo;
        public string AdditionalInfo
        {
            get { return _additionalInfo; }
            set
            {
                _additionalInfo = value;
                OnPropertyChanged("AdditionalInfo");
            }
        }

        public Command BookSeat
        {
            get
            {
                return new Command(async () =>
                {
                    await Application.Current.MainPage.DisplayAlert("TODO", "Booking service", "OK");
                });
            }
        }
    }
}
