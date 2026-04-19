namespace VikiCarWash.Application.DTOs;

public class CreateBookingDTO
{
    public string CustomerName { get; set; }
    public string PhoneNumber { get; set; }
    public string CarType { get; set; }
    public DateTime BookingDate { get; set; }
    public decimal Price { get; set; }
}