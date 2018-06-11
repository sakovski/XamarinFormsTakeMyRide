using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TakeMyRide.Data.Fake;
using TakeMyRide.Models;

namespace TakeMyRide.Services
{
    public class BookRideService
    {
        public async void BookRide(int rideId, string username)
        {
            Passenger passenger = await PassengerRepository.GetPassengerByUsername(username);
            Ride ride = await RideRepository.GetRideById(rideId);
            passenger.RidesAsPassenger.Add(ride);
            await RideRepository.AddPassengerToRide(passenger, rideId);
        }
    }
}
