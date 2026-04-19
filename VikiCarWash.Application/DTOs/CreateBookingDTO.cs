using VikiCarWash.Domain.Enums;

namespace VikiCarWash.Application.DTOs;

public class CreateBookingDTO
{
    public string CustomerName { get; set; }
    public CarTypeEnum CarType { get; set; }
    public WashTypeEnum WashType { get; set; }
    public DateTime BookingDate { get; set; }

}