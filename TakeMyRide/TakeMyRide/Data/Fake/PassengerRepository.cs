using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TakeMyRide.Models;

namespace TakeMyRide.Data.Fake
{
    public class PassengerRepository
    {
        public List<Passenger> passengers;

        public PassengerRepository()
        {
            passengers = new List<Passenger>();
        }

        public async Task<int> UpdatePassenger(Passenger passenger)
        {
            throw new NotImplementedException();
        }

        public async Task<int> InsertPassenger(Passenger passenger)
        {
            passengers.Add(passenger);
            return 1;
        }
    }
}
