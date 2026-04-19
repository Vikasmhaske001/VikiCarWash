using AutoMapper;
using VikiCarWash.Application.DTOs;
using VikiCarWash.Application.Interfaces;
using VikiCarWash.Application.Services;
using VikiCarWash.Domain.Entities;
using VikiCarWash.Domain.Enums;

namespace VikiCarWash.Infrastructure.Services;

public class CarWashBookingService : ICarWashBookingService
{
    private readonly IMapper _mapper;
    private readonly ICarWashBookingRepository _repository;

    public CarWashBookingService(ICarWashBookingRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<BookingResponseDTO>> GetAllAsync()
    {
        var data = await _repository.GetAllAsync();

        return _mapper.Map<List<BookingResponseDTO>>(data);
    }

    public async Task<BookingResponseDTO> GetByIdAsync(int id)
    {
        var x = await _repository.GetByIdAsync(id);

        if (x == null)
        throw new Exception("Booking not found");

        return _mapper.Map<BookingResponseDTO>(x);
    }

    public async Task<BookingResponseDTO> CreateAsync(CreateBookingDTO dto)
    {
        var booking = _mapper.Map<CarWashBooking>(dto);

        booking.Price = CalculatePrice(booking.CarType, booking.WashType);

        booking.IsCompleted = false; 

        await _repository.AddAsync(booking);

        return _mapper.Map<BookingResponseDTO>(booking);
    }

    public async Task<BookingResponseDTO> UpdateAsync(int id, UpdateBookingDTO dto)
    {
        var existing = await _repository.GetByIdAsync(id);

        if (existing == null)
            throw new Exception("Booking not found");

        _mapper.Map(dto, existing);

        existing.Price = CalculatePrice(existing.CarType, existing.WashType);
        await _repository.UpdateAsync(existing);

        return _mapper.Map<BookingResponseDTO>(existing);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null)
            throw new Exception("Booking not found");

        await _repository.DeleteAsync(id);
        return true;
    }

    private decimal CalculatePrice(CarTypeEnum carType, WashTypeEnum washType)
    {
        decimal basePrice = carType switch
        {
            CarTypeEnum.Hatchback => 300,
            CarTypeEnum.Sedan => 400,
            CarTypeEnum.CompactSUV => 500,
            CarTypeEnum.SUV => 600,
            CarTypeEnum.MUV => 700,
            CarTypeEnum.EV => 550,
            CarTypeEnum.Utility => 650,

            _ => throw new ArgumentOutOfRangeException(nameof(carType), "Invalid car type")
        };
        decimal washMultiplier = washType switch {
            WashTypeEnum.Basic => 1.0m,
            WashTypeEnum.Steam => 1.5m,
            WashTypeEnum.DeepClean => 2.0m,
            WashTypeEnum.Premium => 2.5m,
            _ => throw new ArgumentOutOfRangeException(nameof(washType), "Invalid wash type")
        };
        return basePrice * washMultiplier;
    }
}