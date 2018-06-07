using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace TakeMyRide.Models
{
    [Table("PassengerRides")]
    public class PassengerRide
    {
        [ForeignKey(typeof(Passenger))]
        public string PassengerId { get; set; }
        [ForeignKey(typeof(Ride))]
        public string RideId { get; set; }
    }
}
