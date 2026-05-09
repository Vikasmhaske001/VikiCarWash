using System;
using System.Collections.Generic;
using System.Text;
using VikiCarWash.Domain.Enums;

namespace VikiCarWash.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsVerified { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public List<CarWashBooking> Bookings { get; set; } 
        public UserRole Role { get; set; } = UserRole.Customer;

    }
}
