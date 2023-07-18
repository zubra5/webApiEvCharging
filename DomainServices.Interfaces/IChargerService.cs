using Domain;

namespace DomainServices.Interfaces
{
    public interface IChargerService
    {
        Task<IEnumerable<Charger>> GetListByIds(IEnumerable<int> ids);

        Task ReservedCharger(int chargerId);

        Task ReleasedCharger(int chargerId);
    }
}
