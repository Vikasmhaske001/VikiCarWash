using VikiCarWash.Application.DTOs;
using VikiCarWash.Application.Interfaces;
using VikiCarWash.Application.Services;
using VikiCarWash.Domain.Entities;

namespace VikiCarWash.Infrastructure.Services;

public class CarWashBookingService : ICarWashBookingService
{
    private readonly ICarWashBookingRepository _repository;

    public CarWashBookingService(ICarWashBookingRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<BookingResponseDTO>> GetAllAsync()
    {
        var data = await _repository.GetAllAsync();

        return data.Select(x => new BookingResponseDTO
        {
            Id = x.Id,
            CustomerName = x.CustomerName,
            PhoneNumber = x.PhoneNumber,
            CarType = x.CarType,
            BookingDate = x.BookingDate,
            Price = x.Price,
            IsCompleted = x.IsCompleted
        }).ToList();
    }

    public async Task<BookingResponseDTO> GetByIdAsync(int id)
    {
        var x = await _repository.GetByIdAsync(id);

        if (x == null) return null;

        return new BookingResponseDTO
        {
            Id = x.Id,
            CustomerName = x.CustomerName,
            PhoneNumber = x.PhoneNumber,
            CarType = x.CarType,
            BookingDate = x.BookingDate,
            Price = x.Price,
            IsCompleted = x.IsCompleted
        };
    }

    public async Task<BookingResponseDTO> CreateAsync(CreateBookingDTO dto)
    {
        var booking = new CarWashBooking
        {
            CustomerName = dto.CustomerName,
            PhoneNumber = dto.PhoneNumber,
            CarType = dto.CarType,
            BookingDate = dto.BookingDate,
            Price = dto.Price,
            IsCompleted = false
        };

        await _repository.AddAsync(booking);

        return new BookingResponseDTO
        {
            Id = booking.Id,
            CustomerName = booking.CustomerName,
            PhoneNumber = booking.PhoneNumber,
            CarType = booking.CarType,
            BookingDate = booking.BookingDate,
            Price = booking.Price,
            IsCompleted = booking.IsCompleted
        };
    }

    public async Task<BookingResponseDTO> UpdateAsync(int id, UpdateBookingDTO dto)
    {
        var booking = new CarWashBooking
        {
            Id = id,
            CustomerName = dto.CustomerName,
            PhoneNumber = dto.PhoneNumber,
            CarType = dto.CarType,
            BookingDate = dto.BookingDate,
            Price = dto.Price,
            IsCompleted = dto.IsCompleted
        };

        await _repository.UpdateAsync(booking);

        return new BookingResponseDTO
        {
            Id = booking.Id,
            CustomerName = booking.CustomerName,
            PhoneNumber = booking.PhoneNumber,
            CarType = booking.CarType,
            BookingDate = booking.BookingDate,
            Price = booking.Price,
            IsCompleted = booking.IsCompleted
        };
    }

    public async Task<bool> DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
        return true;
    }
}