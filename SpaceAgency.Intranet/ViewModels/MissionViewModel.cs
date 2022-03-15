using SpaceAgency.Data.Data.CMS;
using SpaceAgency.Intranet.Models;

namespace SpaceAgency.Intranet.ViewModels
{
    public class MissionViewModel
    {
        public IEnumerable<Mission> Missions { get; set; }
        public Mission Mission { get; set; }
    }
}
