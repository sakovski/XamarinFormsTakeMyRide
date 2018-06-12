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
