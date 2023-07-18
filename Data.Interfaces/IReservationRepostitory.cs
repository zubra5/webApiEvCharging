using Domain;

namespace Data.Interfaces
{
    public interface IReservationRepostitory
    {
        Task Update(Reservation reservation);
        Task<IEnumerable<Reservation>> GetAll();
        Task<Reservation> GetById(Guid id);

        Task<Reservation> GetActiveByChargerId(int chargerId, Guid userId);
        Task<Reservation> Add(Reservation reservation);
    }
}
