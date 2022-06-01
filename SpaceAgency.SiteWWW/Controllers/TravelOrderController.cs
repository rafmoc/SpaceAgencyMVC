using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceAgency.Data.Data;
using SpaceAgency.SiteWWW.Models.BusinessLogic;
using SpaceAgency.SiteWWW.Models.TravelOrders;

namespace SpaceAgency.SiteWWW.Controllers
{
    public class TravelOrderController : Controller
    {
        private readonly SpaceAgencyContext _context;

        public TravelOrderController(SpaceAgencyContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.ModelRockets = await _context.Planet.ToListAsync();

            TravelOrderB travelOrderB = new TravelOrderB(_context, this.HttpContext);
            DataToOrder dataToOrder = new DataToOrder()
            {
                TravelOrders = await travelOrderB.GetTravelOrderClient()
            };
            return View(dataToOrder);
        }

        public async Task<IActionResult> AddToOrder(int id)
        {
            TravelOrderB travelOrderB = new TravelOrderB(_context, this.HttpContext);
            travelOrderB.AddToOrder(await _context.Travel.FindAsync(id));
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveFromOrder(int id)
        {
            TravelOrderB travelOrderB = new TravelOrderB(_context, this.HttpContext);
            travelOrderB.RemoveFromOrder(await _context.Travel.FindAsync(id));
            return RedirectToAction("Index");
        }
    }
}
