using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VikiCarWash.Application.DTOs;
using VikiCarWash.Application.Interfaces;
using VikiCarWash.Application.Services;
using VikiCarWash.Domain.Entities;


namespace VikiCarWash.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarWashBookingController : ControllerBase
    {
        private readonly ICarWashBookingService _service;

        public CarWashBookingController(ICarWashBookingService service)
        {
            _service = service;
        }

        //GET: api/CarWashBooking
        [Authorize(Roles = "Admin")]
        [HttpGet("all-users")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllAsync();
            return Ok(data);
        }
        //GET: api/CarWashBooking/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _service.GetByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            
            return Ok(data);
        }

        [Authorize(Roles = "Owner")]
        [HttpGet("center-bookings")]
        public async Task<IActionResult> GetCenterBookings()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdClaim, out var ownerId))
            {
                return Unauthorized(new { error = "Invalid user identity" });
            }

            try
            {
                var result = await _service.GetBookingsByOwnerIdAsync(ownerId);
                return Ok(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
        }

        //POST: api/CarWashBooking
        [Authorize(Roles ="Customer")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateBookingDTO dto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var result = await _service.CreateAsync(dto, userId);

            return Ok(result);
        }

        //PUT: api/CarWashBooking/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateBookingDTO dto)
        {
            var result = await _service.UpdateAsync(id, dto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
