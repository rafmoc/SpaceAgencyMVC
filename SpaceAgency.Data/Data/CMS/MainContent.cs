using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAgency.Data.Data.CMS
{
    public class MainContent
    {
        [Key]
        public int IdMainContent { get; set; }

        [Required(ErrorMessage = "Please write the Title")]
        public string Icon { get; set; }

        [Required(ErrorMessage = "Please write the Header")]
        public string Header { get; set; }

        [Required(ErrorMessage = "Please write the Content")]
        public string Content { get; set; }

    }
}
