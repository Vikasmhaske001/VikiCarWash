using System;
using System.Collections.Generic;
using System.Text;

namespace VikiCarWash.Domain.Enums
{
    public enum BookingStatusEnum
    {
        Pending = 1,
        Confirmed = 2,
        InProgress = 3,
        Completed = 4,
        Cancelled = 5,
        Rejected = 6
    }
}
