using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TakeMyRide.Models;

namespace TakeMyRide.Data.Fake
{
    public class DriverRepository
    {
        public List<Driver> drivers;

        public DriverRepository()
        {
            drivers = new List<Driver>();
        }

        public async Task<int> UpdateDriver(Driver driver)
        {
            throw new NotImplementedException();
        }

        public async Task<int> InsertDriver(Driver driver)
        {
            drivers.Add(driver);
            return 0;
        }
    }
}
