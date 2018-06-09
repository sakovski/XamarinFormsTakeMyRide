using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using TakeMyRide.Models;

namespace TakeMyRide.Data
{
    public class UserRepository
    {
        private List<User> users;
        
        public UserRepository()
        {
            users = new List<User>();
            SeedUsers();
        }

        private void SeedUsers()
        {
            users.Add(new User { Id = 1, UserName = "test", Password = "Test" });
            users.Add(new User { Id = 2, UserName = "Test2", Password = "Test2" });
            users.Add(new User { Id = 3, UserName = "Test3", Password = "Test3" });
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await Task.FromResult(users);
        }

        public async Task<User> GetUserById(int id)
        {
            return await Task.FromResult(users.FirstOrDefault(u => u.Id == id));
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await Task.FromResult(users.FirstOrDefault(u => u.UserName.Equals(username)));
        }

        public Task<int> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<int> InsertUser(User user)
        {
            users.Add(user);
            return 0;
        }

        public async Task<int> DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        internal Task<int> InsertPasenger(Passenger passenger)
        {
            throw new NotImplementedException();
        }
    }
}
