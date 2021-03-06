﻿using SQLite;
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

        [ForeignKey(typeof(User))]
        public int UserId { get; set; }

        [ManyToMany(typeof(PassengerRide), CascadeOperations = CascadeOperation.All)]
        public ICollection<Ride> RidesAsPassenger { get; set; }
    }
}
