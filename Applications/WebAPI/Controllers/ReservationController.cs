using Domain;
using DomainServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/reservation")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet("{id}")]
        public async Task<Reservation> Get(Guid id)
        {
            return await _reservationService.GetById(id);
        }

        [HttpGet("all")]
        public async Task<IEnumerable<Reservation>> GetAll()
        {
            return await _reservationService.GetAll();
        }

        [HttpPost]
        public async Task<Reservation> Reserve(AddReservationViewModel addReservationViewModel)
        {
            return await _reservationService.Reserve(
                addReservationViewModel.UserId, 
                addReservationViewModel.ChargerId
            );
        }

        [HttpPut("cancel/{id}")]
        public async Task<Reservation> Cancel(Guid id)
        {
            return await _reservationService.Cancel(id);
        }
    }
}
