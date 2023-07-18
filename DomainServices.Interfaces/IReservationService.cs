using Domain;

namespace DomainServices.Interfaces
{
    public interface IReservationService
    {
        Task<Reservation> Cancel(Guid id);
        Task<IEnumerable<Reservation>> GetAll();
        Task<Reservation> GetById(Guid id);
        Task<Reservation> Reserve(Guid userId, int chargerId);
    }
}
