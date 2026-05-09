using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VikiCarWash.Domain.Entities;

namespace VikiCarWash.Application.Interfaces
{
    public interface ICarWashCenterRepository
    {
        Task AddAsync(CarWashCenter center);
        Task<List<CarWashCenter>> GetAllAsync();
        Task<List<CarWashCenter>> GetByCityAsync(string city);
        Task<List<CarWashCenter>> GetByOwnerIdAsync(int ownerId);
        Task<CarWashCenter> GetByIdAsync(int id);
        Task UpdateAsync(CarWashCenter center);
    }
}
