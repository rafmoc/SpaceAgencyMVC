using SpaceAgency.Data.Data;
using Microsoft.AspNetCore.Mvc;

namespace SpaceAgency.SiteWWW.Controllers
{
    public class SpaceOffersController : Controller
    {
        private readonly SpaceAgencyContext _context;

        public SpaceOffersController(SpaceAgencyContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? id)
        {
            return View();
        }
    }
}
