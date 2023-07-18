using Domain.Enum;
using Domain;

namespace WebAPI.Models
{
    public class ChargingStationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Charger> Chargers { get; set; }
        public Location Location { get; set; }
        public ChargingStationStatus Status { get; set; }
    }
}
