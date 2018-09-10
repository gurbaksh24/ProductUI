using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductUserInterface.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string City { get; set; }
        public string AvailableRooms { get; set; }
        public double Price { get; set; }
        public string IsSaved { get; set; }
        public string IsBooked { get; set; }
    }
}