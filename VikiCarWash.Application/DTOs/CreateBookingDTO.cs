using VikiCarWash.Domain.Enums;

namespace VikiCarWash.Application.DTOs;

public class CreateBookingDTO
{
    public CarTypeEnum CarType { get; set; }
    public WashTypeEnum WashType { get; set; }
    public DateTime BookingDate { get; set; }
    public int CenterId { get; set; }

}