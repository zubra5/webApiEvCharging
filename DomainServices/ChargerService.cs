using Data.Interfaces;
using Domain;
using Domain.Enum;
using DomainServices.Interfaces;

namespace DomainServices
{
    public class ChargerService : IChargerService
    {
        private readonly IChargerRepository _chargerRepository;

        public ChargerService(IChargerRepository chargerRepository)
        {
            _chargerRepository = chargerRepository;
        }

        public Task<IEnumerable<Charger>> GetListByIds(IEnumerable<int> ids)
        {
            return _chargerRepository.GetListByIds(ids);
        }

        public async Task ReleasedCharger(int chargerId)
        {
            var charger = await _chargerRepository.GetById(chargerId);
            charger.Status = ChargerStatus.Available;
            await _chargerRepository.Update(charger);
        }

        public async Task ReservedCharger(int chargerId)
        {
            var charger = await _chargerRepository.GetById(chargerId);
            charger.Status = ChargerStatus.Reserved;
            await _chargerRepository.Update(charger);
        }
    }
}
