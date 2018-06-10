using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeMyRide.Models;

namespace TakeMyRide.Data.Fake
{
    public static class PassengerRepository
    {
        private static List<Passenger> passengers;

        static PassengerRepository()
        {
            passengers = new List<Passenger>();
        }

        public static async Task<int> UpdatePassenger(Passenger passenger)
        {
            throw new NotImplementedException();
        }

        public static async Task<int> InsertPassenger(Passenger passenger)
        {
            passengers.Add(passenger);
            return 1;
        }

        public static async Task<Passenger> GetPassengerByUsername(string username)
        {
            return await Task.FromResult(passengers.FirstOrDefault(u => u.User.UserName.Equals(username)));
        }
    }
}
