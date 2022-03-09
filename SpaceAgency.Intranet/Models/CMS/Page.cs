using System.ComponentModel.DataAnnotations;

namespace SpaceAgency.Intranet.Models.CMS
{
    public class Page
    {
        [Key]
        public int IdPage { get; set; }
        [Required(ErrorMessage ="Please write the Title")]
        [Display(Name ="Link Title")]
        public string LinkTitle { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Position { get; set; }

    }
}
