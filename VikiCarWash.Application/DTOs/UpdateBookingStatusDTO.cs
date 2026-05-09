using VikiCarWash.Domain.Enums;

namespace VikiCarWash.Application.DTOs;

public class UpdateBookingStatusDTO
{
    public BookingStatusEnum Status { get; set; }
}
