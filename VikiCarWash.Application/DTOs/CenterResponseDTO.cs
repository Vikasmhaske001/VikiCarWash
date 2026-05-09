using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VikiCarWash.Application.DTOs
{
    public class CenterResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Rating { get; set; }
        public bool IsActive { get; set; }
        public string OwnerName { get; set; }
    }
}
