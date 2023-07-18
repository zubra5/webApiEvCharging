using Domain.Enum;

namespace Domain
{
    public class ChargingSession
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int ChargerId { get; set; }       
        public DateTime StartTime { get; set; }
        public DateTime? FinishedTime { get; set; }
        public ChargingSessionStatus Status { get; set; }
        public double? KilowattHour { get; set; }
    }
}
