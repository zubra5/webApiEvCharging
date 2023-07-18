using Domain.Enum;

namespace Domain
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int ChargerId { get; set; }
        public DateTime Engaged { get; set; }
        public DateTime Expired { get; set; }
        public ReservationStatus Status { get; set; }
    }
}
