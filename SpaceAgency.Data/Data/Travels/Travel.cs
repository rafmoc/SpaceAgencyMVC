using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAgency.Data.Data.Travels
{
    public class Travel
    {
        [Key]
        public int IdTravel { get; set; }

        [Required(ErrorMessage = "Please write the Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please write the Type")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Please write the Time Off Earth")]
        public string TimeOffEarth { get; set; }

        [Required(ErrorMessage = "Please write the Seats")]
        public string Seats { get; set; }

        public int IdRocket { get; set; }
        public Planet Planet { get; set; }
    }
}
