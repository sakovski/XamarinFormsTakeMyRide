using System;
using System.Collections.Generic;
using System.Text;

namespace TakeMyRide.Models
{
    class Ride
    {
        public int Id { get; set; }
        public User Driver { get; set; }
        public string BaseCity { get; set; }
        public string GoalCity { get; set; }

        public DateTime DateOfStart { get; set; }

        public decimal PriceForSeat { get; set; }

        public int AmountOfSeats { get; set; }

        public string CarInfo { get; set; }

        public string AdditionalInfo { get; set; }

        public ICollection<User> Passengers { get; set; }
    }
}
