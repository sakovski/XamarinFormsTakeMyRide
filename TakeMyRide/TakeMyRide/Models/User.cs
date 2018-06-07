using System;
using System.Collections.Generic;
using System.Text;

namespace TakeMyRide.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Telephone { get; set; }

        public DateTime DateOfBirth { get; set; }

        public float RatingAvarage { get; set; }

        public IEnumerable<float> Ratings { get; set; }
    }
}
