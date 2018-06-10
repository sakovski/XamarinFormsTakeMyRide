using System;
using System.Collections.Generic;
using System.Text;
using TakeMyRide.Helpers;
using TakeMyRide.Models;

namespace TakeMyRide.Services
{
    public class OfferRideService
    {
        public async void OfferRideAsync(string startCity, string destinationCity, DateTime dateOfStart, 
            TimeSpan timeOfStart, string priceForSeat, string amountOfSeats, string carInfo, string additionalInfo)
        {
            var driver = await App.Database.GetDriverAsync(Settings.Username);
            DateTime dateTime = new DateTime(dateOfStart.Year, dateOfStart.Month, dateOfStart.Day, timeOfStart.Hours, timeOfStart.Minutes, 0);
            decimal price = Decimal.Parse(priceForSeat);
            int amountSeats = Int32.Parse(amountOfSeats);
            var ride = CreateRideAsync(driver, startCity, destinationCity, dateTime, price, amountSeats, carInfo, additionalInfo);
            await App.Database.SaveRideAsync(ride);
        }

        private Ride CreateRideAsync(Driver driver, string startCity, string destinationCity, DateTime dateOfStart, 
            decimal priceForSeat, int amountOfSeats, string carInfo, string additionalInfo)
        {
            return new Ride()
            {
                Driver = driver,
                DriverId = driver.Id,
                StartCity = startCity,
                DestinationCity = destinationCity,
                DateOfStart = dateOfStart,
                PriceForSeat = priceForSeat,
                AmountOfSeats = amountOfSeats,
                CarInfo = carInfo,
                AdditionalInfo = additionalInfo,
                Passengers = new List<Passenger>(0)
            };
        }
    }
}
