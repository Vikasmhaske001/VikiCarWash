using VikiCarWash.Application.DTOs;
using VikiCarWash.Application.Interfaces;
using VikiCarWash.Application.Services;
using VikiCarWash.Domain.Entities;
using AutoMapper;

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
        booking.IsCompleted = false; // keep this

        await _repository.AddAsync(booking);

        return _mapper.Map<BookingResponseDTO>(booking);
    }

    public async Task<BookingResponseDTO> UpdateAsync(int id, UpdateBookingDTO dto)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null)
            throw new Exception("Booking not found");

        var booking = _mapper.Map<CarWashBooking>(dto);
        booking.Id = id;

        await _repository.UpdateAsync(booking);

        return _mapper.Map<BookingResponseDTO>(booking);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null)
            throw new Exception("Booking not found");

        await _repository.DeleteAsync(id);
        return true;
    }
}