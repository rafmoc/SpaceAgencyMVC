using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAgency.Data.Data.Travels
{
    public class Planet
    {
        [Key]
        public int IdPlanet { get; set; }

        [Required(ErrorMessage = "Please write the Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please write the Security Level")]
        public string SecurityLevel { get; set; }

        [Required(ErrorMessage = "Please write the Type")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Please write the Status")]
        public string Status { get; set; }

        public List<Travel> Engine { get; set; }
    }
}
