using Domain;
using DomainServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/sessions")]
    [ApiController]
    public class ChargingSessionController : ControllerBase
    {
        private readonly IChargingSessionService _chargingSessionService;

        public ChargingSessionController(IChargingSessionService chargingSessionServic)
        {
            _chargingSessionService = chargingSessionServic;
        }

        [HttpGet("{id}")]
        public async Task<ChargingSession> Get(Guid id)
        {
            return await _chargingSessionService.GetBy(id);
        }

        [HttpGet("all")]
        public async Task<IEnumerable<ChargingSession>> GelAll()
        {
            return await _chargingSessionService.GetAll();
        }

        [HttpPost]
        public async Task<ChargingSession> Start(ChargingSession chargingSession)
        {
            return await _chargingSessionService.StartSession(chargingSession);
        }

        [HttpPut("finalize/{id}")]
        public async Task<ChargingSession> Finalize(Guid id)
        {
            return await _chargingSessionService.FinalizeSession(id);
        }
    }
}
