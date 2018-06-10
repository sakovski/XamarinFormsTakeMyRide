using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeMyRide.Models;

namespace TakeMyRide.Data.Fake
{
    public static class DriverRepository
    {
        private static List<Driver> drivers;

        static DriverRepository()
        {
            drivers = new List<Driver>();
        }

        public static async Task<int> UpdateDriver(Driver driver)
        {
            throw new NotImplementedException();
        }

        public static async Task<int> InsertDriver(Driver driver)
        {
            drivers.Add(driver);
            return 0;
        }

        public static async Task<Driver> GetDriverByUsername(string username)
        {
            return await Task.FromResult(drivers.FirstOrDefault(u => u.User.UserName.Equals(username)));
        }
    }
}
