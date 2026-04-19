using System;
using System.Collections.Generic;
using System.Text;

namespace VikiCarWash.Application.Interfaces
{
    public interface IAuthService
    {
        Task<string> SendOtpAsync(string phoneNumber);
        Task<string> VerifyOtpAsync(string phoneNumber, string otp);
    }
}
