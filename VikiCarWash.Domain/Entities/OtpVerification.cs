namespace VikiCarWash.Domain.Entities;

public class OtpVerification
{
    public int Id { get; set; }
    public string PhoneNumber { get; set; }
    public string OtpCode { get; set; }
    public DateTime ExpiryTime { get; set; }
    public bool IsUsed { get; set; } = false;
}