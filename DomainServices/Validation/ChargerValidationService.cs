using Common.Exceptions;
using Data.Interfaces;
using DomainServices.Interfaces.Validation;

namespace DomainServices.Validation
{
    public class ChargerValidationService : IChargerValidationService
    {
        private readonly IChargerRepository _chargerRepository;
        private readonly IReservationRepostitory _reservationRepostitory;

        public ChargerValidationService(IChargerRepository chargerRepository,
                                        IReservationRepostitory reservationRepostitory)
        {
            _chargerRepository = chargerRepository;
            _reservationRepostitory = reservationRepostitory;
        }

        public async Task CheckChargerExisting(int chargerId)
        {
            var charger = await _chargerRepository.GetById(chargerId);
            if (charger is null)
            {
                throw new ChargerNotFoundException($"Charger id={chargerId} not found");
            }
        }

        public async Task IsChargerAvailable(int chargerId)
        {
            var charger = await _chargerRepository.GetById(chargerId);
            if (charger is null || charger.Status != Domain.Enum.ChargerStatus.Available)
            {
                throw new ChargerNotAvailableException($"Charger id={chargerId} is not available");
            }
        }

        public async Task<bool> IsChargerReserved(int chargerId, Guid userId)
        {
            var result = await _reservationRepostitory.GetActiveByChargerId(chargerId, userId);
            return result is null;
        }
    }
}
