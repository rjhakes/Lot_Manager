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
    public class UserController : ControllerBase
    {
        private readonly IUserBL _userBL;
        
        public UserController(IUserBL userBL) //IMediator mediator)
        {
            _userBL = userBL;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            return Ok(await _userBL.GetUsersAsync());
        }

        // GET: api/<UserController>/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetUserByIdAsync(Guid id)
        {
            var user = await _userBL.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // POST: api/<UserController>
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> AddUserAsync([FromBody] User user)
        {
            try
            {
                await _userBL.AddUserAsync(user);
                return CreatedAtAction("AddUser", user);
            }
            catch (Exception e)
            {
                return StatusCode(400);
            }
        }

        // Put: api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserAsync(Guid id, [FromBody] User user)
        {
            try
            {
                await _userBL.UpdateUserAsync(user);
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAsync(Guid id)
        {
            try
            {
                await _userBL.DeleteUserAsync(await _userBL.GetUserByIdAsync(id));
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}