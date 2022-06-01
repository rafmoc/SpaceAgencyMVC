using Microsoft.EntityFrameworkCore;
using SpaceAgency.Data.Data;
using SpaceAgency.Data.Data.Travels;

namespace SpaceAgency.SiteWWW.Models.BusinessLogic
{
    public class TravelOrderB
    {
        private readonly SpaceAgencyContext _context;
        private string idOrderSesion;

        public TravelOrderB(SpaceAgencyContext context, HttpContext httpContext)
        {
            _context = context;
            idOrderSesion = GetIdOrderSesion(httpContext);
        }

        private string GetIdOrderSesion(HttpContext httpContext)
        {
            if(httpContext.Session.GetString("IdOrderSesion") == null)
            {
                if(!string.IsNullOrWhiteSpace(httpContext.User.Identity.Name))
                {
                    httpContext.Session.SetString("IdOrderSesion", httpContext.User.Identity.Name);
                }
                else
                {
                    Guid tempIdOrderSesion = Guid.NewGuid();
                    httpContext.Session.SetString("IdOrderSesion", tempIdOrderSesion.ToString());
                }
            }
            return httpContext.Session.GetString("IdOrderSesion").ToString();
        }

        public void AddToOrder(Travel travel)
        {
            var tempTravelOrder =
                _context.TravelOrder
                .Where(e => e.IdTravelSesion == idOrderSesion && e.IdTravel == travel.IdTravel)
                .FirstOrDefault();

            if(tempTravelOrder != null)
            {
                tempTravelOrder.Seats++;
            }
            else
            {
                tempTravelOrder = new TravelOrder()
                {
                    IdTravelSesion = idOrderSesion,
                    IdTravel = travel.IdTravel,
                    Travel = _context.Travel.Find(travel.IdTravel),
                    Seats = 1,
                    CreationDate = DateTime.Now
                };
                _context.TravelOrder.Add(tempTravelOrder);
            }
            _context.SaveChanges();
        }

        public void RemoveFromOrder(Travel travel)
        {
            var tempTravelOrder =
                _context.TravelOrder
                .Where(e => e.IdTravelSesion == idOrderSesion && e.IdTravel == travel.IdTravel)
                .FirstOrDefault();

            if (tempTravelOrder != null)
            {
                tempTravelOrder.Seats--;
                if (tempTravelOrder.Seats <= 0)
                {
                    _context.TravelOrder.Remove(tempTravelOrder);
                }
            }
            _context.SaveChanges();
        }

        public async Task<List<TravelOrder>> GetTravelOrderClient()
        {
            return await _context.TravelOrder.Where(e => e.IdTravelSesion == this.idOrderSesion).Include(e => e.Travel).ToListAsync();
        }
    }
}
