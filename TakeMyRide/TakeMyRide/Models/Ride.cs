using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace TakeMyRide.Models
{
    [Table("Rides")]
    public class Ride
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Driver))]
        public int DriverId { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.CascadeRead)]
        public Driver Driver { get; set; }

        public string BaseCity { get; set; }

        public string GoalCity { get; set; }

        public DateTime DateOfStart { get; set; }

        public decimal PriceForSeat { get; set; }

        public int AmountOfSeats { get; set; }

        public string CarInfo { get; set; }

        public string AdditionalInfo { get; set; }

        [ManyToMany(typeof(PassengerRide), CascadeOperations = CascadeOperation.All, ReadOnly = true)]
        public ICollection<Passenger> Passengers { get; set; }
    }
}
