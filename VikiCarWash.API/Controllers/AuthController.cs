using Microsoft.AspNetCore.Mvc;
using VikiCarWash.Application.DTOs;
using VikiCarWash.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;


namespace VikiCarWash.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }
        [HttpPost("send-otp")]
        public async Task<IActionResult> SendOtp(SendOtpDTO dto)
        {
            var otp = await _service.SendOtpAsync(dto.PhoneNumber);
            return Ok(new { otp });
        }
        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp(VerifyOtpDTO dto)
        {
            var token = await _service.VerifyOtpAsync(dto.PhoneNumber, dto.Otp);
            return Ok(new { token });
        }
        [Authorize]
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var result = await _service.GetProfileAsync(userId);

            return Ok(result);
        }
        [Authorize]
        [HttpPut("complete-profile")]
        public async Task<IActionResult> CompleteProfile(CompleteProfileDTO dto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var result = await _service.CompleteProfileAsync(userId, dto);

            return Ok(result);
        }
    }
}
