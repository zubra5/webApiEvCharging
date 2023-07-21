using Common.Exceptions;
using Data.Interfaces;
using Domain;
using Domain.Enum;
using DomainServices.Interfaces;
using DomainServices.Interfaces.Validation;

namespace DomainServices
{
    public class ChargingSessionService : IChargingSessionService
    {
        private readonly IChargingSessionRepository _chargingSessionRepository;
        private readonly IChargerValidationService _chargerValidationService;

        public ChargingSessionService(IChargingSessionRepository chargingSessionRepository,
                                      IChargerValidationService chargerValidationService)
        {
            _chargingSessionRepository = chargingSessionRepository;
            _chargerValidationService = chargerValidationService;
        }

        public async Task<ChargingSession> FinalizeSession(Guid id)
        {
            var chargingSession = await _chargingSessionRepository.GetById(id);
            if (chargingSession is null)
            {
                throw new ChargingSessionNotFoundException($"Session id={id} not found");
            }
            if (chargingSession.Status != ChargingSessionStatus.Start &&
                chargingSession.Status != ChargingSessionStatus.Processing) {
                throw new ChargingSessionNotFinalizedException($"Session id={id} is not able to finilize");
            }
            chargingSession.Status = ChargingSessionStatus.Finished;
            chargingSession.FinishedTime = DateTime.UtcNow;
            await _chargingSessionRepository.Update(chargingSession);
            return chargingSession;
        }

        public Task<IEnumerable<ChargingSession>> GetAll()
        {
            return _chargingSessionRepository.GetAll();
        }

        public async Task<ChargingSession> GetBy(Guid id)
        {
            var chargingSession = await _chargingSessionRepository.GetById(id);
            if (chargingSession is null)
            {
                throw new ChargingSessionNotFoundException($"Session id={id} not found");
            }

            return chargingSession;
        }

        public async Task<ChargingSession> StartSession(ChargingSession chargingSession)
        {
            if (chargingSession.KilowattHour <= 0)
            {
                throw new ChargingSessionNotStartedException("The parameter KilowattHour should be more than 0");
            }
            await _chargerValidationService.CheckChargerExisting(chargingSession.ChargerId);
            
            var isReservedforUser = await _chargerValidationService.IsChargerReserved(chargingSession.ChargerId, chargingSession.UserId);
            if (!isReservedforUser) {
                await _chargerValidationService.IsChargerAvailable(chargingSession.ChargerId);
            }

            chargingSession.Status = ChargingSessionStatus.Start;
            chargingSession.StartTime = DateTime.UtcNow;
            await _chargingSessionRepository.Add(chargingSession);
            return chargingSession;
        }
    }
}
