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
    public class LotController : ControllerBase
    {
        private readonly ILotBL _lotBL;
        
        public LotController(ILotBL lotBL) //IMediator mediator)
        {
            _lotBL = lotBL;
        }

        // GET: api/<LotController>
        [HttpGet]
        public async Task<IActionResult> GetLotsAsync()
        {
            return Ok(await _lotBL.GetLotsAsync());
        }

        // GET: api/<LotController>/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetLotByIdAsync(Guid id)
        {
            var lot = await _lotBL.GetLotByIdAsync(id);
            if (lot == null) return NotFound();
            return Ok(lot);
        }

        // GET: api/<LotController>/5
        [HttpGet("{name}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetLotByNameAsync(string name)
        {
            var lot = await _lotBL.GetLotByNameAsync(name);
            if (lot == null) return NotFound();
            return Ok(lot);
        }

        // POST: api/<LotController>
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> AddLotAsync([FromBody] Lot lot)
        {
            try
            {
                await _lotBL.AddLotAsync(lot);
                return CreatedAtAction("AddLot", lot);
            }
            catch (Exception e)
            {
                return StatusCode(400);
            }
        }

        // Put: api/<LotController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLotAsync(Guid id, [FromBody] Lot lot)
        {
            try
            {
                await _lotBL.UpdateLotAsync(lot);
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<LotController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLotAsync(Guid id)
        {
            try
            {
                await _lotBL.DeleteLotAsync(await _lotBL.GetLotByIdAsync(id));
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}