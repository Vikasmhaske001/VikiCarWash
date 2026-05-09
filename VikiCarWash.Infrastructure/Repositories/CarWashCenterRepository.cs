using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VikiCarWash.Application.Interfaces;
using VikiCarWash.Domain.Entities;
using VikiCarWash.Infrastructure.Data;

namespace VikiCarWash.Infrastructure.Repositories
{
    public class CarWashCenterRepository : ICarWashCenterRepository
    {
        private readonly AppDbContext _context;

        public CarWashCenterRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CarWashCenter center)
        {
            await _context.CarWashCenters.AddAsync(center);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CarWashCenter>> GetAllAsync()
        {
            return await _context.CarWashCenters
                .Include(x => x.Owner)
                .Where(x => x.IsActive)
                .ToListAsync();
        }

        public async Task<List<CarWashCenter>> GetByCityAsync(string city)
        {
            return await _context.CarWashCenters
                .Include(x => x.Owner)
                .Where(x => x.City == city && x.IsActive)
                .ToListAsync();
        }

        public async Task<List<CarWashCenter>> GetByOwnerIdAsync(int ownerId)
        {
            return await _context.CarWashCenters
                .Where(x => x.OwnerId == ownerId)
                .ToListAsync();
        }

        public async Task<CarWashCenter> GetByIdAsync(int id)
        {
            return await _context.CarWashCenters
                .Include(x => x.Owner)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(CarWashCenter center)
        {
            _context.CarWashCenters.Update(center);
            await _context.SaveChangesAsync();
        }
    }
}
