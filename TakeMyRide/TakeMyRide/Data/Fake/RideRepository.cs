using System;
using System.Collections.Generic;
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

        public static Task<Ride> GetRideById(int id)
        {
            throw new NotImplementedException();
        }

        public static Task<int> UpdateRide(Ride ride)
        {
            throw new NotImplementedException();
        }

        public static async Task<int> InsertRide(Ride ride)
        {
            rides.Add(ride);
            return 0;
        }

        public static Task<int> DeleteRide(Ride ride)
        {
            throw new NotImplementedException();
        }
    }
}
