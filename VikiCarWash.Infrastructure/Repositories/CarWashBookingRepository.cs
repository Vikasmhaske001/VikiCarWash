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

        /// <summary>
        /// Gets bookings for a specific owner's centers.
        /// Uses projection for performance and automatic filtering via query filters.
        /// </summary>
        public async Task<List<CarWashBooking>> GetBookingsByOwnerIdAsync(int ownerId)
        {
            return await _context.CarWashBookings
                .Where(b => b.Center.OwnerId == ownerId)
                .Include(b => b.Customer)
                .Include(b => b.Center)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var booking = await _context.CarWashBookings.FindAsync(id);
            if (booking != null)
            {
                _context.CarWashBookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
          
        }

        public async Task<List<CarWashBooking>> GetAllAsync()
        {
            return await _context.CarWashBookings
                .Include(b => b.Customer)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<CarWashBooking> GetByIdAsync(int id)
        {
            return await _context.CarWashBookings
                .Include(b => b.Customer)
                .Include(b => b.Center)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task UpdateAsync(CarWashBooking booking)
        {
            _context.CarWashBookings.Update(booking);
            await _context.SaveChangesAsync();
        }
    }
}
