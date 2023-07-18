using Data.Interfaces;
using Data.Interfaces.Configuration;
using Domain;
using Domain.Enum;

namespace Data
{
    public class ChargingStationRepository : BaseFileRepository<ChargingStation>, IChargingStationRepository
    {
        private readonly IChargerRepository _chargerRepository;

        public ChargingStationRepository(IChargingStationRepositoryConfig chargingStationRepositoryConfig,
                                         IChargerRepository chargerRepository)
                                        : base(chargingStationRepositoryConfig)
        {
            _chargerRepository = chargerRepository;
        }

        public async Task<IEnumerable<ChargingStation>> GelAllAvailable()
        {
            var stations = ReadFile();
            var chargers = await _chargerRepository.GetAll();

            var availableStations = from station in stations
                                    from charger in chargers
                                    where station.Chargers.Contains(charger.Id)
                                        && charger.Status == ChargerStatus.Available
                                    select station;

            return availableStations.ToList();
        }
    }
}
