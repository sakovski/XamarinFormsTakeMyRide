using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace TakeMyRide.Models
{
    [Table("Passenger")]
    public class Passenger
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [OneToOne]
        public User User { get; set; }

        [ManyToMany(typeof(PassengerRide), CascadeOperations = CascadeOperation.All)]
        public IEnumerable<Ride> RidesAsPassenger { get; set; }
    }
}
