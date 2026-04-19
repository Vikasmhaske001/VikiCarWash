using Microsoft.AspNetCore.Mvc;
using VikiCarWash.Application.Interfaces;
using VikiCarWash.Domain.Entities;

namespace VikiCarWash.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarWashBookingController : Controller
    {
        private readonly ICarWashBookingRepository _repository;
        public CarWashBookingController(ICarWashBookingRepository repository)
        {
            _repository = repository;
        }
        //GET: api/CarWashBooking
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _repository.GetAllAsync();
            return Ok(data);
        }
        //GET: api/CarWashBooking/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var booking = await _repository.GetByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
        }

        //POST: api/CarWashBooking
        [HttpPost]
        public async Task<IActionResult> Create(CarWashBooking booking)
        {
            await _repository.AddAsync(booking);
            return Ok(booking);
        }

        //PUT: api/CarWashBooking/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CarWashBooking booking)
        {
            if (id != booking.Id)
            {
                return BadRequest();
            }
            await _repository.UpdateAsync(booking);
            return Ok(booking);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return Ok();
        }
    }
}
