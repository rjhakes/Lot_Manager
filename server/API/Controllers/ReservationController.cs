using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BL;
using Models;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationBL _reservationBL;
        
        public ReservationController(IReservationBL reservationBL) //IMediator mediator)
        {
            _reservationBL = reservationBL;
        }

        // GET: api/<ReservationController>
        [HttpGet]
        public async Task<IActionResult> GetReservationsAsync()
        {
            return Ok(await _reservationBL.GetReservationsAsync());
        }

        // GET: api/<ReservationController>/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetReservationByIdAsync(Guid id)
        {
            var reservation = await _reservationBL.GetReservationByIdAsync(id);
            if (reservation == null) return NotFound();
            return Ok(reservation);
        }

        // POST: api/<ReservationController>
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> AddReservationAsync([FromBody] Reservation reservation)
        {
            try
            {
                await _reservationBL.AddReservationAsync(reservation);
                return CreatedAtAction("AddReservation", reservation);
            }
            catch (Exception e)
            {
                return StatusCode(400);
            }
        }

        // Put: api/<ReservationController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservationAsync(Guid id, [FromBody] Reservation reservation)
        {
            try
            {
                await _reservationBL.UpdateReservationAsync(reservation);
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<ReservationController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservationAsync(Guid id)
        {
            try
            {
                await _reservationBL.DeleteReservationAsync(await _reservationBL.GetReservationByIdAsync(id));
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}