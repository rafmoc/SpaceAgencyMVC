using SpaceAgency.Data.Data.CMS;
using SpaceAgency.Intranet.Models;

namespace SpaceAgency.Intranet.TwoViews
{
    public class TwoViewsAtOnce
    {
        public IEnumerable<Page> Pages { get; set; }
        public Page Page { get; set; }
        public IEnumerable<Pioneer> Pioneers { get; set; }
        public Pioneer Pioneer { get; set; }
        public IEnumerable<Structure> Structures { get; set; }
        public Structure Structure { get; set; }
    }
}
