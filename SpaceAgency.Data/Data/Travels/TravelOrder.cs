using System.ComponentModel.DataAnnotations;

namespace SpaceAgency.Data.Data.Travels
{
    public class TravelOrder
    {
        [Key]
        public int IdTravelOrder { get; set; }
        public string IdTravelSesion { get; set; }
        public int IdTravel { get; set; }
        public Travel Travel { get; set; }
        public int Seats { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
