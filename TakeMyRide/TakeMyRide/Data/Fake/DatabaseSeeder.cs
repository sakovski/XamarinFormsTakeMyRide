using System;
using System.Collections.Generic;
using System.Text;
using TakeMyRide.Models;

namespace TakeMyRide.Data.Fake
{
    public static class DatabaseSeeder
    {
        public static async void SeedDatabase()
        {
            User user1 = new User { Id = 1, UserName = "testdriver", Password = "testdriver", FirstName = "Test", LastName = "Test", Email = "driver@test.pl", Telephone = "123123123", DateOfBirth = DateTime.Today.AddYears(-40) };
            User user2 = new User { Id = 2, UserName = "testpassenger", Password = "testpassenger", FirstName = "Test", LastName = "Test", Email = "passenger@test.pl", Telephone = "111222333", DateOfBirth = DateTime.Today.AddYears(-40) };
            Driver driver1 = new Driver() { User = user1, UserId = user1.Id, RidesAsDriver = new List<Ride>(), Ratings = new List<float>() };
            Passenger passenger1 = new Passenger() { User = user2, UserId = user2.Id, RidesAsPassenger = new List<Ride>() };
            await UserRepository.InsertUser(user1);
            await UserRepository.InsertUser(user2);
            await DriverRepository.InsertDriver(driver1);
            await PassengerRepository.InsertPassenger(passenger1);
            for (int i = 0; i < 15; i++)
            {
                Ride ride = new Ride()
                {
                    Id = i + 1,
                    Driver = driver1,
                    DriverId = driver1.Id,
                    StartCity = "Gdańsk",
                    DestinationCity = "Poznań",
                    DateOfStart = DateTime.Now.AddDays(1),
                    PriceForSeat = 24.50M,
                    AmountOfSeats = 2,
                    CarInfo = "Skoda Fabia, 1996, Green",
                    AdditionalInfo = "Animals friendly",
                    Passengers = new List<Passenger>(2)
                };
                await RideRepository.InsertRide(ride);
            }
        }
    }
}
