using System;
using System.Collections.Generic;
using System.Text;

namespace VikiCarWash.Domain.Entities
{
    public class CarWashBooking
    {
        public int Id {get;set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string CarType { get; set; }
        public DateTime BookingDate { get; set; }
        public decimal Price { get; set; }
        public bool IsCompleted { get; set; }
    }
}
