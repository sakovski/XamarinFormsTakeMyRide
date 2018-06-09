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
            var user = App.Database.GetUserAsync(userName);
            if(user.Result != null)
            {
                return true;
            }
            return false;           
        }
    }
}
