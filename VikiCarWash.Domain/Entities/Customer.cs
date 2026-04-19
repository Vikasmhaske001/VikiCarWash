using System;
using System.Collections.Generic;
using System.Text;

namespace VikiCarWash.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsVerified { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public List<CarWashBooking> Bookings { get; set; } 
    }
}
