using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAgency.Data.Data.CMS
{
    public class Structure
    {
        [Key]
        public int IdStructure { get; set; }

        [Required(ErrorMessage = "Please write the Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please write the Type")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Please write the Planet")]
        public string Planet { get; set; }

        [Required(ErrorMessage = "Please write the Latitude")]
        public string Latitude { get; set; }

        [Required(ErrorMessage = "Please write the Longitude")]
        public string Longitude { get; set; }

        [Required(ErrorMessage = "Please write the Status")]
        public string Status { get; set; }
    }
}
