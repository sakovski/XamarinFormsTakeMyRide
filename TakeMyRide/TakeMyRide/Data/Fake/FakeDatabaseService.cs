using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TakeMyRide.Data.Fake;
using TakeMyRide.Models;

namespace TakeMyRide.Data
{
    public class FakeDatabaseService
    {

        public FakeDatabaseService()
        {
            DatabaseSeeder.SeedDatabase();            
        }

        #region User
        public Task<List<User>> GetUsersAsync()
        {
            return UserRepository.GetAllAsync();
        }


        public Task<User> GetUserAsync(int id)
        {
            return UserRepository.GetUserById(id);
        }

        public Task<User> GetUserAsync(string username)
        {
            return UserRepository.GetUserByUsername(username);
        }

        public Task<User> GetUserByEmailAsync(string email)
        {
            return UserRepository.GetUserByEmail(email);
        }

        public Task<int> SaveUserAsync(User user)
        {
            if (user.Id != 0)
            {
                return UserRepository.UpdateUser(user);
            }
            else
            {
                return UserRepository.InsertUser(user);
            }
        }

        public Task<int> DeleteUserAsync(User user)
        {
            return UserRepository.DeleteUser(user);
        }
        #endregion

        #region Driver
        public Task<int> SaveDriverAsync(Driver driver)
        {
            if (driver.Id != 0)
            {
                return DriverRepository.UpdateDriver(driver);
            }
            else
            {
                return DriverRepository.InsertDriver(driver);
            }
        }

        public Task<Driver> GetDriverAsync(string userName)
        {
            return DriverRepository.GetDriverByUsername(userName);
        }
        #endregion

        #region Passenger

        public Task<int> SavePassengerAsync(Passenger passenger)
        {
            if (passenger.Id != 0)
            {
                return PassengerRepository.UpdatePassenger(passenger);
            }
            else
            {
                return PassengerRepository.InsertPassenger(passenger);
            }
        }

        public Task<Passenger> GetPassengerAsync(string userName)
        {
            return PassengerRepository.GetPassengerByUsername(userName);
        }
        #endregion
        #region Ride
        public async Task<IEnumerable<Ride>> GetRidesAsync()
        {
            return await RideRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Ride>> GetAvailableRidesOrderedByDateAsync()
        {
            return await RideRepository.GetAllAvailableOrderedByDateAsync();
        }

        public async Task<int> GetLastRideId()
        {
            return await RideRepository.GetLastId();
        }
        public Task<Ride> GetRideAsync(int id)
        {
            return RideRepository.GetRideById(id);
        }

        public Task<int> SaveRideAsync(Ride ride)
        {
            if (ride.Id != 0)
            {
                return RideRepository.UpdateRide(ride);
            }
            else
            {
                return RideRepository.InsertRide(ride);
            }
        }

        public Task<int> DeleteRideAsync(Ride ride)
        {
            return RideRepository.DeleteRide(ride);
        }
        #endregion       
    }
}
