using Data.Interfaces;
using Data.Interfaces.Configuration;
using Domain;

namespace Data
{
    public class ReservationRepostitory : BaseFileRepository<Reservation>, IReservationRepostitory
    {
        public ReservationRepostitory(IReservationRepositoryConfig reservationRepositoryConfig)
                : base(reservationRepositoryConfig)
        {
        }

        public Task Update(Reservation reservation)
        {
            return Task.Factory.StartNew(
                () => base.Update(reservation, new Predicate<Reservation>((x)=>x.Id == reservation.Id))
            );
        }

        public Task<IEnumerable<Reservation>> GetAll()
        {
            var reservations = base.ReadFile();

            return Task<IEnumerable<Reservation>>.Factory.StartNew(
                () => reservations.ToList()
            );
        }

        public Task<Reservation> GetById(Guid id)
        {
            var reservations = base.ReadFile();
            var result = reservations.FirstOrDefault(x => x.Id == id);
            return Task<Reservation>.Factory.StartNew(() => result);
        }

        public Task<Reservation> Add(Reservation reservation)
        {
            base.Append(reservation);
            return Task<Reservation>.Factory.StartNew(() => reservation);
        }

        public Task<Reservation> GetActiveByChargerId(int chargerId, Guid userId)
        {
            var reservations = base.ReadFile();
            var result = reservations.FirstOrDefault(x => x.ChargerId==chargerId 
                                            && x.Status ==Domain.Enum.ReservationStatus.Engaged
                                            && x.UserId == userId);
            return Task<Reservation>.Factory.StartNew(() => result);
        }
    }
}
