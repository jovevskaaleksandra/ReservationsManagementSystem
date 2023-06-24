using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationSystem.API.Models;

namespace ReservationSystem.API.Controllers
{
    [Route("reservations")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly ReservationSystemContext _context;

        public ReservationsController(ReservationSystemContext context)
        {
            _context = context;
        }

        //to test
        [HttpGet]
        [Route("details")]
        public IActionResult GetReservationDetails()
        {
            var reservations = _context.ReservationDetails.ToList();
            return Ok(reservations);
        }

        // too slow view or test again
        [HttpGet]
        [Route("types")]
        public IActionResult GetReservationTypes()
        {
            var reservations = _context.ReservationTypes.ToList();
            return Ok(reservations);
        }

       
        [HttpGet("report")]
        public IActionResult GenerateReservationReport()
        {
            var result = _context.Reservations.FromSql($"select * from public.generate_reservation_report() limit 5").ToList();

            return Ok(result);
        }


    }
}
