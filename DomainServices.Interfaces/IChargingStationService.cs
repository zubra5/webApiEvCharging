using Domain;

namespace DomainServices.Interfaces
{
    public interface IChargingStationService
    {
        Task<IEnumerable<ChargingStation>> GelAllAvailable();
    }
}
