using Microsoft.AspNetCore.Mvc;
using VikiCarWash.Application.DTOs;
using VikiCarWash.Application.Interfaces;
using VikiCarWash.Domain.Entities;

namespace VikiCarWash.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarWashBookingController : ControllerBase
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
            var result = data.Select(x => new BookingResponseDTO
            {
                Id = x.Id,
                CustomerName = x.CustomerName,
                PhoneNumber = x.PhoneNumber,
                CarType = x.CarType,
                BookingDate = x.BookingDate,
                Price = x.Price,
                IsCompleted = x.IsCompleted
            });
            return Ok(result);
        }
        //GET: api/CarWashBooking/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var x = await _repository.GetByIdAsync(id);
            if (x == null)
            {
                return NotFound();
            }
            var result = new BookingResponseDTO
            {
                Id = x.Id,
                CustomerName = x.CustomerName,
                PhoneNumber = x.PhoneNumber,
                CarType = x.CarType,
                BookingDate = x.BookingDate,
                Price = x.Price,
                IsCompleted = x.IsCompleted
            };
            return Ok(result);
        }

        //POST: api/CarWashBooking
        [HttpPost]
        public async Task<IActionResult> Create(CreateBookingDTO dto)
        {
            var booking = new CarWashBooking
            {
                CustomerName = dto.CustomerName,
                PhoneNumber = dto.PhoneNumber,
                CarType = dto.CarType,
                BookingDate = dto.BookingDate,
                Price = dto.Price,
                IsCompleted = false
            };
            await _repository.AddAsync(booking);
            return Ok(booking);
        }

        //PUT: api/CarWashBooking/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateBookingDTO dto)
        {
            var booking = new CarWashBooking
            {
                Id = id,
                CustomerName = dto.CustomerName,
                PhoneNumber = dto.PhoneNumber,
                CarType = dto.CarType,
                BookingDate = dto.BookingDate,
                Price = dto.Price,
                IsCompleted = dto.IsCompleted
            };

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
