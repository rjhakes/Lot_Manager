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
    public class SpotController : ControllerBase
    {
        private readonly ISpotBL _spotBL;
        
        public SpotController(ISpotBL spotBL) //IMediator mediator)
        {
            _spotBL = spotBL;
        }

        // GET: api/<SpotController>
        [HttpGet]
        public async Task<IActionResult> GetSpotsAsync()
        {
            return Ok(await _spotBL.GetSpotsAsync());
        }

        // GET: api/<SpotController>/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetSpotByIdAsync(Guid id)
        {
            var spot = await _spotBL.GetSpotByIdAsync(id);
            if (spot == null) return NotFound();
            return Ok(spot);
        }

        // POST: api/<SpotController>
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> AddSpotAsync([FromBody] Spot spot)
        {
            try
            {
                await _spotBL.AddSpotAsync(spot);
                return CreatedAtAction("AddSpot", spot);
            }
            catch (Exception e)
            {
                return StatusCode(400);
            }
        }

        // Put: api/<SpotController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSpotAsync(Guid id, [FromBody] Spot spot)
        {
            try
            {
                await _spotBL.UpdateSpotAsync(spot);
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<SpotController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpotAsync(Guid id)
        {
            try
            {
                await _spotBL.DeleteSpotAsync(await _spotBL.GetSpotByIdAsync(id));
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}