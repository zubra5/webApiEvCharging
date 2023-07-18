using Data.Interfaces;
using Data.Interfaces.Configuration;
using Domain;

namespace Data
{
    public class ChargerRepository : BaseFileRepository<Charger>, IChargerRepository
    {
        public ChargerRepository(IChargerRepositoryConfig chargerRepositoryConfig)
            : base(chargerRepositoryConfig)
        {           
        }

        public Task<IEnumerable<Charger>> GetAll()
        {
            var chargers = ReadFile();

            return Task<IEnumerable<Charger>>.Factory.StartNew(
                () => chargers.ToList()
            );
        }

        public Task<IEnumerable<Charger>> GetListByIds(IEnumerable<int> ids)
        {
            var chargers = ReadFile();

            return Task<IEnumerable<Charger>>.Factory.StartNew(
                () => chargers.Where(x => ids.Contains(x.Id)).ToList()
            );
        }

        public Task<Charger?> GetById(int chargerId) {
            var chargers = ReadFile();

            return Task<Charger?>.Factory.StartNew(
                () => chargers.Where(x => x.Id == chargerId).FirstOrDefault()
            );
        }       

        public Task Update(Charger charger)
        {
            return Task.Factory.StartNew(
                () => base.Update(charger, new Predicate<Charger>((x) => x.Id == charger.Id))
            );
        }
    }
}
