using DomainServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Mappers;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/stations")]
    [ApiController]
    public class ChargingStationController : ControllerBase
    {
        private readonly IChargingStationService _chargingStationService;
        private readonly IChargerService _chargerService;

        public ChargingStationController(IChargingStationService chargingStationService,
                                        IChargerService chargerService)
        {
            _chargingStationService = chargingStationService;
            _chargerService = chargerService;
        }

        [HttpGet("all/available")]
        public async Task<IEnumerable<ChargingStationViewModel>> GelAllAvailable()
        {
            var domains = await _chargingStationService.GelAllAvailable();
            var chargerIds = domains.SelectMany(x => x.Chargers);
            var chargers =  await _chargerService.GetListByIds(chargerIds);
            
            return domains.Select(x => x.MapToViewModel(chargers));
        }
    }
}
