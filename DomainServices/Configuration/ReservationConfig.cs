using DomainServices.Interfaces.Configuration;
using Microsoft.Extensions.Configuration;

namespace DomainServices.Configuration
{
    public class ReservationConfig : IReservationConfig
    {
        public int CountMinutesOfReservationAvailability { get; set; }

        public const string NameOfSection = "Reservation";

        public ReservationConfig()
        {
        }

        public ReservationConfig(IConfiguration configuration)
        {
            configuration.GetSection(NameOfSection).Bind(this);
        }
    }
}
