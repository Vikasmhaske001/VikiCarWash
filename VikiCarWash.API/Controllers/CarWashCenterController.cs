using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VikiCarWash.Application.DTOs;
using VikiCarWash.Application.Interfaces;

namespace VikiCarWash.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarWashCenterController : ControllerBase
    {
        private readonly ICarWashCenterService _service;

        public CarWashCenterController(ICarWashCenterService service)
        {
            _service = service;
        }

        // CUSTOMER - browse all centers
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        // CUSTOMER - search by city
        [HttpGet("by-city/{city}")]
        public async Task<IActionResult> GetByCity(string city)
        {
            var result = await _service.GetByCityAsync(city);
            return Ok(result);
        }

        // OWNER - create center
        [Authorize(Roles = "Owner")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCenterDTO dto)
        {
            var ownerId = int.Parse(
                User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var result = await _service.CreateAsync(dto, ownerId);

            return Ok(result);
        }

        // OWNER - view own centers
        [Authorize(Roles = "Owner")]
        [HttpGet("my-centers")]
        public async Task<IActionResult> GetMyCenters()
        {
            var ownerId = int.Parse(
                User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var result = await _service.GetMyCentersAsync(ownerId);

            return Ok(result);
        }

        // OWNER - update own center
        [Authorize(Roles = "Owner")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCenterDTO dto)
        {
            var ownerId = int.Parse(
                User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var result = await _service.UpdateAsync(id, dto, ownerId);

            return Ok(result);
        }

        // ADMIN - see all centers
        [Authorize(Roles = "Admin")]
        [HttpGet("admin/all")]
        public async Task<IActionResult> AdminGetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }
    }
}
