using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TakeMyRide.Models;

namespace TakeMyRide.Data.Fake
{
    public class RideRepository
    {
        private List<Ride> rides;
        public RideRepository()
        {
            rides = new List<Ride>();
        }

        public Task<List<Ride>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Ride> GetRideById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateRide(Ride ride)
        {
            throw new NotImplementedException();
        }

        public async Task<int> InsertRide(Ride ride)
        {
            rides.Add(ride);
            return 0;
        }

        public Task<int> DeleteRide(Ride ride)
        {
            throw new NotImplementedException();
        }
    }
}
