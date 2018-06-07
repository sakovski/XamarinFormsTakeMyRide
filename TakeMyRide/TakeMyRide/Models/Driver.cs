using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace TakeMyRide.Models
{
    [Table("Drivers")]
    public class Driver
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [OneToOne]
        public User User { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public IEnumerable<Ride> RidesAsDriver { get; set; }

        public float RatingAvarage { get; set; }

        public IEnumerable<float> Ratings { get; set; }
    }
}
