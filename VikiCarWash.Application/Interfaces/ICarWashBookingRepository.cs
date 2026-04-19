using System;
using System.Collections.Generic;
using System.Text;
using VikiCarWash.Domain.Entities;

namespace VikiCarWash.Application.Interfaces
{
    public interface ICarWashBookingRepository
    {
        Task<List<CarWashBooking>> GetAllAsync();
        Task<CarWashBooking> GetByIdAsync(int id);
        Task AddAsync(CarWashBooking booking);
        Task UpdateAsync(CarWashBooking booking);
        Task DeleteAsync(int id);

    }
}
