using TakeMyRide.Data.Fake;
using TakeMyRide.Models;

namespace TakeMyRide.Views
{
    public class RatingService
    {
        public bool AddRateToUser(string username, float rate)
        {
            var driver = DriverRepository.GetDriverByUsername(username).Result;
            driver.Ratings.Add(rate);
            return true;
        }
    }
}