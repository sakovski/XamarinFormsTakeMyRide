using System;
using System.Collections.Generic;
using System.Text;

namespace TakeMyRide.Models
{
    public class RideOfferCardDataModel
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public string StartCity { get; set; }
        public string DestinationCity { get; set; }

        public DateTime Date { get; set; }

    }
}
