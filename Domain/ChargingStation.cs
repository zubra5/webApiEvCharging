using Domain.Enum;

namespace Domain
{
    public class ChargingStation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<int> Chargers { get; set; }
        public Location Location { get; set; }
        public ChargingStationStatus Status { get; set; }
    }
}
