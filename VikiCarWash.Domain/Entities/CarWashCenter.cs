using System;
using System.Collections.Generic;
using System.Text;

namespace VikiCarWash.Domain.Entities
{
    public class CarWashCenter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int OwnerId { get; set; }
        public Customer Owner { get; set; }
        public ICollection<CarWashBooking> Bookings { get; set; }

    }
}
