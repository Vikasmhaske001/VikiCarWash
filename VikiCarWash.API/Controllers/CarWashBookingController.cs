using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
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

        //POST: api/CarWashBooking
        [HttpPost]
        public async Task<IActionResult> Create(CreateBookingDTO dto)
        {
            var result = await _service.CreateAsync(dto);

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
