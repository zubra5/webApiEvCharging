using Domain.Enum;

namespace Domain
{
    public class Charger
    {
        public int Id { get; set; }
        public ConnectorType Connector { get; set; }
        public ChargerStatus Status { get; set; }
    }
}
