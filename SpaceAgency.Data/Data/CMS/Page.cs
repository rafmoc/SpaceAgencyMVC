using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAgency.Data.Data.CMS
{
    public class Page
    {
        [Key]
        public int IdPage { get; set; }

        [Required(ErrorMessage = "Please write the Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please write the Header")]
        public string Header { get; set; }

        [Required(ErrorMessage = "Please write the TopContent")]
        public string TopContent { get; set; }

        [Required(ErrorMessage = "Please write the BotContent")]
        public string BotContent { get; set; }
    }
}
