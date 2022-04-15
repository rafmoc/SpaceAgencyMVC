using SpaceAgency.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            ViewBag.ModelRockets = await _context.Rocket.ToListAsync();

            if (id == null)
            {
                var first = await _context.Rocket.FirstAsync();
                id = first.IdRocket;
            }

            return View(await _context.Engine.Where(t => t.IdRocket == id).ToListAsync());
        }

        public async Task<IActionResult> MoreInfo(int? id)
        {
            ViewBag.ModelRockets = await _context.Rocket.ToListAsync();
            return View(await _context.Engine.Where(t => t.IdEngine == id).FirstOrDefaultAsync());
        }
    }
}