using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAgency.Data.Data.CMS
{
    public class Pioneer
    {
        [Key]
        public int IdPioneer { get; set; }

        [Required(ErrorMessage = "Please write the Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please write the SurName")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Please write the Status")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Please write the Current Planet")]
        [Display(Name = "Current Planet")]
        public string CurrentPlanet { get; set; }
    }
}
