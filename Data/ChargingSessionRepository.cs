using Data.Interfaces;
using Data.Interfaces.Configuration;
using Domain;

namespace Data
{
    public class ChargingSessionRepository : BaseFileRepository<ChargingSession>, IChargingSessionRepository
    {
        public ChargingSessionRepository(IChargingSessionRepositoryConfig config) : base(config)
        {

        }

        public Task<ChargingSession> Add(ChargingSession chargingSession)
        {
            base.Append(chargingSession);           
            return Task<ChargingSession>.Factory.StartNew(() => chargingSession);           
        }

        public Task<IEnumerable<ChargingSession>> GetAll()
        {
            var chargingSessions = ReadFile();
            return Task<IEnumerable<ChargingSession>>.Factory.StartNew(
                () => chargingSessions.ToList()
            );
        }

        public Task<ChargingSession?> GetById(Guid chargingSessionId)
        {
            var chargingSessions = base.ReadFile();
            var result = chargingSessions.FirstOrDefault(x => x.Id == chargingSessionId);
            return Task<ChargingSession?>.Factory.StartNew(() => result);
        }

        public Task Update(ChargingSession chargingSession)
        {
            return Task.Factory.StartNew(
                () => base.Update(chargingSession, new Predicate<ChargingSession>((x) => x.Id == chargingSession.Id))
            );
        }
    }
}
