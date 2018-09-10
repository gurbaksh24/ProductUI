using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductUserInterface.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        public double ActivityPrice { get; set; }
        public string ActivityCategory { get; set; }
        public string IsSaved { get; set; }
        public string IsBooked { get; set; }
    }
}