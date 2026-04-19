using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using VikiCarWash.Application.Interfaces;
using VikiCarWash.Domain.Entities;
using VikiCarWash.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace VikiCarWash.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public AuthService(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        public async Task<string> SendOtpAsync(string phoneNumber)
        {
            var otp = new Random().Next(1000, 9999).ToString();
            var entry = new OtpVerification
            {
                PhoneNumber = phoneNumber,
                OtpCode = otp,
                ExpiryTime = DateTime.UtcNow.AddMinutes(5),
                IsUsed = false
            };
            _context.OtpVerifications.Add(entry);
            await _context.SaveChangesAsync();

            return otp;
        }
        public async Task<string> VerifyOtpAsync(string phoneNumber, string otp)
        {
            var record = await _context.OtpVerifications.FirstOrDefaultAsync( x =>
            x.PhoneNumber == phoneNumber &&
            x.OtpCode == otp &&
            !x.IsUsed &&
            x.ExpiryTime > DateTime.UtcNow);

            if(record == null)
            throw new Exception("Invalid or expired OTP");

            record.IsUsed = true;

            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber);

            if (customer == null)
            {
                customer = new Customer
                {
                    PhoneNumber = phoneNumber,
                    IsVerified = true
                };

                _context.Customers.Add(customer);
            }

            await _context.SaveChangesAsync();

            return GenerateJwt(customer);
        }
        private string GenerateJwt(Customer user)
        {
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.MobilePhone, user.PhoneNumber)
    };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
