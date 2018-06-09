using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TakeMyRide.Models;

namespace TakeMyRide.Data
{
    public class DatabaseService
    {
        readonly SQLiteAsyncConnection database;

        public DatabaseService(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<User>().Wait();
            database.CreateTableAsync<Passenger>().Wait();
            database.CreateTableAsync<Driver>().Wait();         
            database.CreateTableAsync<Ride>().Wait();
            database.CreateTableAsync<PassengerRide>().Wait();
        }

        #region User
        public Task<List<User>> GetUsersAsync()
        {
            return database.Table<User>().ToListAsync();
        }


        public Task<User> GetUserAsync(int id)
        {
            return database.Table<User>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<User> GetUserAsync(string username)
        {
            return database.Table<User>().Where(i => i.UserName.Equals(username)).FirstOrDefaultAsync();
        }

        public Task<int> SaveUserAsync(User user)
        {
            if (user.Id != 0)
            {
                return database.UpdateAsync(user);
            }
            else
            {
                return database.InsertAsync(user);
            }
        }

        public Task<int> DeleteUserAsync(User user)
        {
            return database.DeleteAsync(user);
        }
        #endregion

        #region Driver
        public Task<int> SaveDriverAsync(Driver driver)
        {
            if (driver.Id != 0)
            {
                return database.UpdateAsync(driver);
            }
            else
            {
                return database.InsertAsync(driver);
            }
        }
        #endregion

        #region Passenger

        public Task<int> SavePassengerAsync(Passenger passenger)
        {
            if (passenger.Id != 0)
            {
                return database.UpdateAsync(passenger);
            }
            else
            {
                return database.InsertAsync(passenger);
            }
        }
        #endregion

        #region Ride
        public Task<List<Ride>> GetRidesAsync()
        {
            return database.Table<Ride>().ToListAsync();
        }


        public Task<Ride> GetRideAsync(int id)
        {
            return database.Table<Ride>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveRideAsync(Ride ride)
        {
            if (ride.Id != 0)
            {
                return database.UpdateAsync(ride);
            }
            else
            {
                return database.InsertAsync(ride);
            }
        }

        public Task<int> DeleteRideAsync(Ride ride)
        {
            return database.DeleteAsync(ride);
        }
        #endregion
    }
}
