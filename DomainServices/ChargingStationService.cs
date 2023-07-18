using Data.Interfaces;
using Domain;
using DomainServices.Interfaces;

namespace DomainServices
{
    public class ChargingStationService : IChargingStationService
    {
        private readonly IChargingStationRepository _chargingStationRepository;

        public ChargingStationService(IChargingStationRepository chargingStationRepository)
        {
            _chargingStationRepository = chargingStationRepository;
        }

        public Task<IEnumerable<ChargingStation>> GelAllAvailable()
        {
            return _chargingStationRepository.GelAllAvailable();
        }
    }
}
