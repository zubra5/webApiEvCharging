using Domain;

namespace Data.Interfaces
{
    public interface IChargingSessionRepository
    {
        Task<IEnumerable<ChargingSession>> GetAll();

        Task<ChargingSession?> GetById(Guid chargingSessionId);

        Task Update(ChargingSession chargingSession);

        Task<ChargingSession> Add(ChargingSession chargingSession);
    }
}
