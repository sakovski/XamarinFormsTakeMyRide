using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using TakeMyRide.Services;
using TakeMyRide.Validators;
using Xamarin.Forms;

namespace TakeMyRide.ViewModels
{
    public class OfferRideViewModel : BaseViewModel
    {
        public OfferRideService offerRideService = new OfferRideService();

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

        private DateTime _dateOfStart = DateTime.Today;
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
            get { return _timeOfStart; }
            set
            {
                _timeOfStart = value;
                OnPropertyChanged("TimeOfStart");
            }
        }

        private string _priceForSeat;
        public string PriceForSeat
        {
            get { return _priceForSeat; }
            set
            {
                _priceForSeat = value;
                OnPropertyChanged("PriceForSeat");
            }
        }

        private string _amountOfSeats;
        public string AmountOfSeats
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

        public Command AddOffer
        {
            get
            {
                return new Command(async () =>
                {
                    if(!IsOfferDataValid())
                    {
                        await Application.Current.MainPage.DisplayAlert("Given data invalid!", "Correct red fields.", "OK");
                    }
                    else
                    {
                        offerRideService.OfferRide(StartCity, DestinationCity, DateOfStart, TimeOfStart, PriceForSeat, AmountOfSeats, CarInfo, AdditionalInfo);
                        await Application.Current.MainPage.DisplayAlert("Offer published!", "", "OK");
                    }
                    
                });
            }
        }

        private bool IsOfferDataValid()
        {
            return StartCity != null && Regex.IsMatch(StartCity, RegexPatterns.namePattern) 
               && DestinationCity != null && Regex.IsMatch(DestinationCity, RegexPatterns.namePattern)  
               && PriceForSeat != null && Regex.IsMatch(PriceForSeat, RegexPatterns.pricePattern) 
               && AmountOfSeats != null && Regex.IsMatch(AmountOfSeats, RegexPatterns.seatsPattern)  
               && CarInfo != null && Regex.IsMatch(CarInfo, RegexPatterns.descriptionPattern)  
               && AdditionalInfo != null && Regex.IsMatch(AdditionalInfo, RegexPatterns.descriptionPattern)  
               && DatesValidators.IsDateOfRideValid(DateOfStart);
        }
    }
}
