using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TakeMyRide.Models;

namespace TakeMyRide.Services
{
    public class LoginService
    {
        public async Task<bool> loginUserAsync(string userName, string password, string function)
        {
            var user = App.Database.GetUserAsync(userName).Result;
            return user != null && IsLoginAndPasswordMatch(user, password) && IsUserFunctionMatches(user, function);          
        }

        private bool IsLoginAndPasswordMatch(User user, string password)
        {
            return password != null && password != string.Empty && user.Password.Equals(password);
        }

        private bool IsUserFunctionMatches(User user, string function)
        {
            if(function.Equals("Driver"))
            {
                var driver = App.Database.GetDriverAsync(user.UserName).Result;
                return driver != null;
            }
            else
            {
                var passenger = App.Database.GetPassengerAsync(user.UserName).Result;
                return passenger != null;
            }
        }
    }
}
