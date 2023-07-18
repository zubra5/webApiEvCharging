using Domain;

namespace Data.Interfaces
{
    public interface IChargerRepository
    {
        Task<IEnumerable<Charger>> GetAll();

        Task<IEnumerable<Charger>> GetListByIds(IEnumerable<int> ids);

        Task<Charger?> GetById(int chargerId);

        Task Update(Charger charger);
    }
}
