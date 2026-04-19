using VikiCarWash.Domain.Enums;

namespace VikiCarWash.Application.DTOs;

public class UpdateBookingDTO
{
    public string CustomerName { get; set; }
    public string PhoneNumber { get; set; }
    public CarTypeEnum CarType { get; set; }
    public WashTypeEnum WashType { get; set; }
    public DateTime BookingDate { get; set; }
    public bool IsCompleted { get; set; }
}