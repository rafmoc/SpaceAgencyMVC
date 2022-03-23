using Microsoft.AspNetCore.Mvc;
using SpaceAgency.Data.Data;
using SpaceAgency.SiteWWW.Models;
using System.Diagnostics;

namespace SpaceAgency.SiteWWW.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SpaceAgencyContext _context;

        public HomeController(SpaceAgencyContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? id)
        {
            ViewBag.ModelPages =
                (
                    from page in _context.Page
                    select page
                ).ToList();

            if (id == null)
            {
                id = _context.Page.First().IdPage;
            }
            var item = _context.Page.Find(id);

            return View(item);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult JoinUs()
        {
            return View();
        }
        
        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}