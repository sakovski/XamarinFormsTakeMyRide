using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TakeMyRide.Models;

namespace TakeMyRide.Services
{
    public class RegisterService
    {
        public async void registerUserAsync(string function, string username, string password, string firstname, string lastname, string email, string telephone, DateTime dateOfBirth)
        {
            var newUser = createUser(username, password, firstname, lastname, email, telephone, dateOfBirth);
            await App.Database.SaveUserAsync(newUser);
            var user = await App.Database.GetUserAsync(username);

            switch (function)
            {
                case "Driver":
                    var driver = createDriver(user);
                    await App.Database.SaveDriverAsync(driver);
                    break;
                case "Passenger":
                    var passenger = createPassenger(user);
                    await App.Database.SavePassengerAsync(passenger);
                    break;
                default:
                    break;
            }
        }

        private User createUser(string username, string password, string firstname, string lastname, string email, string telephone, DateTime dateOfBirth)
        {
            return new User()
            {
                Id = 0,
                UserName = username,
                Password = password,
                FirstName = firstname,
                LastName = lastname,
                Email = email,
                Telephone = telephone,
                DateOfBirth = dateOfBirth
            };
        }

        private Driver createDriver(User user)
        {
            return new Driver()
            {
                UserId = user.Id,
                User = user,
                RidesAsDriver = new List<Ride>(),
                Ratings = new List<float>()

            };
        }

        private Passenger createPassenger(User user)
        {
            return new Passenger()
            {
                UserId = user.Id,
                User = user,
                RidesAsPassenger = new List<Ride>()
            };
        }
    }
}
