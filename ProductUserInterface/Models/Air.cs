using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductUserInterface.Models
{
    public class Air
    {
        public int AirId { get; set; }
        public string AirName { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string Class { get; set; }
        public double AirPrice { get; set; }
        public string IsSaved { get; set; }
        public string IsBooked { get; set; }
    }
}