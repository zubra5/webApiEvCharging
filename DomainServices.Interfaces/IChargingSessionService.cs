using Domain;

namespace DomainServices.Interfaces
{
    public interface IChargingSessionService
    {
        Task<ChargingSession> FinalizeSession(Guid id);
        Task<IEnumerable<ChargingSession>> GetAll();
        Task<ChargingSession> GetBy(Guid id);
        Task<ChargingSession> StartSession(ChargingSession chargingSession);
    }
}
