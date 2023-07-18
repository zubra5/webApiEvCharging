using Domain;

namespace Data.Interfaces
{
    public interface IChargingStationRepository
    {
        Task<IEnumerable<ChargingStation>> GelAllAvailable();                
    }
}
