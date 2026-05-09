using System;
using System.Collections.Generic;
using System.Text;
using VikiCarWash.Application.DTOs;

namespace VikiCarWash.Application.Interfaces
{
    public interface IAuthService
    {
        Task<string> SendOtpAsync(string phoneNumber);
        Task<string> VerifyOtpAsync(string phoneNumber, string otp);
        Task<CustomerProfileDTO> GetProfileAsync(int userId);
        Task<CustomerProfileDTO> CompleteProfileAsync(int userId, CompleteProfileDTO dto);
    }
}
