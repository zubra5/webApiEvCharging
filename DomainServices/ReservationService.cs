using Common.Exceptions;
using Data.Interfaces;
using Domain;
using Domain.Enum;
using DomainServices.Interfaces;
using DomainServices.Interfaces.Configuration;
using DomainServices.Interfaces.Validation;

namespace DomainServices
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationConfig _reservationConfig;
        private readonly IReservationRepostitory _reservationRepostitory;
        private readonly IChargerValidationService _chargerValidationService;
        private readonly IChargerService _chargerService;

        public ReservationService(IReservationRepostitory reservationRepostitory,
                                  IChargerValidationService chargerValidationService,
                                  IChargingStationRepository chargingStationRepository,
                                  IChargerService chargerRepository,
                                  IReservationConfig reservationConfig)
        {
            _reservationRepostitory = reservationRepostitory;
            _chargerValidationService = chargerValidationService;          
            _reservationConfig = reservationConfig;
            _chargerService = chargerRepository;
        }

        public Task<IEnumerable<Reservation>> GetAll()
        {
            return _reservationRepostitory.GetAll();
        }

        public Task<Reservation> GetById(Guid id)
        {
            return _reservationRepostitory.GetById(id);
        }

        public async Task<Reservation> Reserve(Guid userId, int chargerId)
        {
            await _chargerValidationService.CheckChargerExisting(chargerId);
            await _chargerValidationService.IsChargerAvailable(chargerId);
            var expiredDateTime = DateTime.UtcNow;
            var reservation = new Reservation
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                ChargerId = chargerId,
                Status = ReservationStatus.Engaged,
                Engaged = expiredDateTime,
                Expired = expiredDateTime.AddMinutes(_reservationConfig.CountMinutesOfReservationAvailability)
            };

            var result =  await _reservationRepostitory.Add(reservation);

            await _chargerService.ReservedCharger(chargerId);

            return result;
        }

        public async Task<Reservation> Cancel(Guid id)
        {
            var reservation = await _reservationRepostitory.GetById(id);
            if (reservation is null)
            {
                throw new ReservationNotFoundException($"Reservation id={id} not found");
            }

            if (reservation.Status != ReservationStatus.Engaged 
                || reservation.Expired < DateTime.UtcNow) 
            {
                throw new ReservationCanNotCancelException($"Reservation id={id} is not able to be canceled");
            }

            reservation.Status = ReservationStatus.Canceled;
            await _reservationRepostitory.Update(reservation);

            await _chargerService.ReleasedCharger(reservation.ChargerId);

            return reservation;
        }
    }
}
