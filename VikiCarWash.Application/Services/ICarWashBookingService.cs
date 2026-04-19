using VikiCarWash.Application.DTOs;

namespace VikiCarWash.Application.Services;

public interface ICarWashBookingService
{
    Task<List<BookingResponseDTO>> GetAllAsync();
    Task<BookingResponseDTO> GetByIdAsync(int id);
    Task<BookingResponseDTO> CreateAsync(CreateBookingDTO dto, int userId);
    Task<BookingResponseDTO> UpdateAsync(int id, UpdateBookingDTO dto);
    Task<bool> DeleteAsync(int id);
}