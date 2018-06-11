using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeMyRide.Models;

namespace TakeMyRide.Data.Fake
{
    public static class RideRepository
    {
        private static List<Ride> rides;
        static RideRepository()
        {
            rides = new List<Ride>();
        }

        public static async Task<List<Ride>> GetAllAsync()
        {
            return await Task.FromResult(rides);
        }

        public static async Task<List<Ride>> GetAllAvailableAsync()
        {
            return await Task.FromResult(rides.Where(r => r.AmountOfSeats > 0).ToList());
        }

        public static async Task<Ride> GetRideById(int id)
        {
            return await Task.FromResult(rides.FirstOrDefault(r => r.Id == id));
        }

        public static async Task<int> UpdateRide(Ride ride)
        {
            throw new NotImplementedException();
        }

        public static async Task<int> AddPassengerToRide(Passenger passenger, int rideId)
        {
            var ride = rides.Find(r => r.Id == rideId);
            ride.Passengers.Add(passenger);
            ride.AmountOfSeats -= 1;
            return 0;
        }

        public static async Task<int> InsertRide(Ride ride)
        {
            ride.Id = await GetLastId() + 1;
            rides.Add(ride);
            return 0;
        }

        public static async Task<int> GetLastId()
        {
            if(rides == null || rides.Count == 0)
            {
                return 1;   
            }
            return rides.OrderByDescending(r => r.Id).FirstOrDefault().Id;
        }

        public static Task<int> DeleteRide(Ride ride)
        {
            throw new NotImplementedException();
        }
    }
}
