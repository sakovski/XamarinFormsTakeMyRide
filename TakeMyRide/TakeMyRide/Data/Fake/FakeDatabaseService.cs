﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TakeMyRide.Data.Fake;
using TakeMyRide.Models;

namespace TakeMyRide.Data
{
    public class FakeDatabaseService
    {
        private UserRepository userRepository;
        private DriverRepository driverRepository;
        private PassengerRepository passengerRepository;
        private RideRepository rideRepository;

        public FakeDatabaseService()
        {
            InitFakeDb();
        }

        private void InitFakeDb()
        {
            userRepository = new UserRepository();
            driverRepository = new DriverRepository();
            passengerRepository = new PassengerRepository();
            rideRepository = new RideRepository();
        }

        #region User
        public Task<List<User>> GetUsersAsync()
        {
            return userRepository.GetAllAsync();
        }


        public Task<User> GetUserAsync(int id)
        {
            return userRepository.GetUserById(id);
        }

        public Task<User> GetUserAsync(string username)
        {
            return userRepository.GetUserByUsername(username);
        }
        
        public Task<int> SaveUserAsync(User user)
        {
            if (user.Id != 0)
            {
                return userRepository.UpdateUser(user);
            }
            else
            {
                return userRepository.InsertUser(user);
            }
        }

        public Task<int> DeleteUserAsync(User user)
        {
            return userRepository.DeleteUser(user);
        }
        #endregion

        #region Driver
        public Task<int> SaveDriverAsync(Driver driver)
        {
            if (driver.Id != 0)
            {
                return driverRepository.UpdateDriver(driver);
            }
            else
            {
                return driverRepository.InsertDriver(driver);
            }
        }

        public Task<Driver> GetDriverAsync(string userName)
        {
            return driverRepository.GetDriverByUsername(userName);
        }
        #endregion

        #region Passenger

        public Task<int> SavePassengerAsync(Passenger passenger)
        {
            if (passenger.Id != 0)
            {
                return passengerRepository.UpdatePassenger(passenger);
            }
            else
            {
                return passengerRepository.InsertPassenger(passenger);
            }
        }
        #endregion
        #region Ride
        public Task<List<Ride>> GetRidesAsync()
        {
            return rideRepository.GetAllAsync();
        }


        public Task<Ride> GetRideAsync(int id)
        {
            return rideRepository.GetRideById(id);
        }

        public Task<int> SaveRideAsync(Ride ride)
        {
            if (ride.Id != 0)
            {
                return rideRepository.UpdateRide(ride);
            }
            else
            {
                return rideRepository.InsertRide(ride);
            }
        }

        public Task<int> DeleteRideAsync(Ride ride)
        {
            return rideRepository.DeleteRide(ride);
        }
        #endregion
    }
}
