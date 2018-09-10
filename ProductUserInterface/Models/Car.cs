using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductUserInterface.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public string CarModel { get; set; }
        public string CarBrand { get; set; }
        public string CarColor { get; set; }
        public double CarPrice { get; set; }
        public string IsSaved { get; set; }
        public string IsBooked { get; set; }
    }
}