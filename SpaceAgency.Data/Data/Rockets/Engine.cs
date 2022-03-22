using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAgency.Data.Data.Rockets
{
    public class Engine
    {
        [Key]
        public int IdEngine { get; set; }

        [Required(ErrorMessage = "Please write the Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please write the Model")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Please write the Type")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Please write the Stage")]
        public string Stage { get; set; }

        public int IdRocket { get; set; }
        public Rocket Rocket { get; set; }
    }
}
