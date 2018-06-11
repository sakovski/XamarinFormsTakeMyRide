using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [ForeignKey(typeof(User))]
        public int UserId { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public ICollection<Ride> RidesAsDriver { get; set; }

        //public float RatingAvarage { get; set; }

        public float RatingAvarage
        {
            get
            {
                if(Ratings.Count() == 0)
                {
                    return 1f;
                }
                else
                {
                    return Enumerable.Average(Ratings);
                }               
            }
        }

        public ICollection<float> Ratings { get; set; }
    }
}
