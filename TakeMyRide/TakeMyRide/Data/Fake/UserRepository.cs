using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using TakeMyRide.Models;
using TakeMyRide.Data.Fake;

namespace TakeMyRide.Data
{
    public static class UserRepository
    {
        private static List<User> users;

        static UserRepository()
        {
            users = new List<User>();
            SeedUsers();
        }

        private static void SeedUsers()
        {
            User user1 = new User { Id = 1, UserName = "testdriver", Password = "testdriver", FirstName = "Test", LastName = "Test", Email = "driver@test.pl", Telephone = "123123123", DateOfBirth = DateTime.Today.AddYears(-40) };
            User user2 = new User { Id = 2, UserName = "testpassenger", Password = "testpassenger", FirstName = "Test", LastName = "Test", Email = "passenger@test.pl", Telephone = "111222333", DateOfBirth = DateTime.Today.AddYears(-40) };
            users.Add(user1);
            users.Add(user2);
            DriverRepository.InsertDriver(
                new Driver()
                {
                    User = user1,
                    UserId = user1.Id,
                    RidesAsDriver = new List<Ride>(),
                    Ratings = new List<float>()
                }
                );
            PassengerRepository.InsertPassenger(
                new Passenger()
                {
                    User = user2,
                    UserId = user2.Id,
                    RidesAsPassenger = new List<Ride>()
                }
            );

        }

        public static async Task<List<User>> GetAllAsync()
        {
            return await Task.FromResult(users);
        }

        public static async Task<User> GetUserById(int id)
        {
            return await Task.FromResult(users.FirstOrDefault(u => u.Id == id));
        }

        public static async Task<User> GetUserByUsername(string username)
        {
            return await Task.FromResult(users.FirstOrDefault(u => u.UserName.Equals(username)));
        }

        public static async Task<User> GetUserByEmail(string email)
        {
            return await Task.FromResult(users.FirstOrDefault(u => u.Email.Equals(email)));
        }

        public static Task<int> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public static async Task<int> InsertUser(User user)
        {
            users.Add(user);
            return 0;
        }

        public static async Task<int> DeleteUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
