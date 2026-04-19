using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VikiCarWash.Application.Interfaces;
using VikiCarWash.Domain.Entities;
using VikiCarWash.Infrastructure.Data;

namespace VikiCarWash.Infrastructure.Repositories
{
    public class CarWashBookingRepository : ICarWashBookingRepository
    {
        private readonly AppDbContext _context;
        public CarWashBookingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CarWashBooking booking)
        {
            await _context.CarWashBookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var booking = _context.CarWashBookings.Find(id);
            if (booking != null)
            {
                _context.CarWashBookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
          
        }

        public async Task<List<CarWashBooking>> GetAllAsync()
        {
            return await _context.CarWashBookings.ToListAsync();
        }

        public async Task<CarWashBooking> GetByIdAsync(int id)
        {
            return await _context.CarWashBookings.FindAsync(id);
        }

        public async Task UpdateAsync(CarWashBooking booking)
        {
            await _context.SaveChangesAsync();
        }
    }
}
