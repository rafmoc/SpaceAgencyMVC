using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAgency.Data.Data.CMS
{
    public class Mission
    {
        [Key]
        public int IdMission { get; set; }

        [Required(ErrorMessage = "Please write the Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please write the Destination")]
        public string Destination { get; set; }

        [Required(ErrorMessage = "Please write the Type")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Please write the Status")]
        public string Status { get; set; }
    }
}
