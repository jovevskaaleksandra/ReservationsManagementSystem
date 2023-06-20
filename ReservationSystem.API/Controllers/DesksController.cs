using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationSystem.API.Models;

namespace ReservationSystem.API.Controllers
{
    [Route("desks")]
    [ApiController]
    public class DesksController : ControllerBase
    {
        private readonly ReservationSystemContext _context;

        public DesksController(ReservationSystemContext context)
        {
            _context = context;
        }

        // to slow view
        [HttpGet]
        [Route("available-for-current-date")]
        public IActionResult GetAvailableDesksForCurrentDate()
        {
            var desks = _context.AvailableDesksForCurrentDates.ToList();
            return Ok(desks);
        }

        [HttpGet]
        [Route("monitor-details")]
        public IActionResult GetDeskAndMonitorDetails()
        {
            var desks = _context.DeskMonitorDetails.ToList();
            return Ok(desks);
        }

        [HttpGet]
        [Route("reservations")]
        public IActionResult GetDeskReservations()
        {
            var desks = _context.DeskReservations.ToList();
            return Ok(desks);
        }
    }
}
