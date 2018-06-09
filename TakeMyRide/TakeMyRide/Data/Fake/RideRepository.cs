using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
