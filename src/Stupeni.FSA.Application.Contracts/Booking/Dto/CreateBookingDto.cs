using System;
using System.Collections.Generic;

namespace Stupeni.FSA.Booking.Dto
{
    public class CreateBookingDto
    {
        public DateTime BookingDate { get; set; }

        public Guid UserId { get; set; }

        public IEnumerable<int> FlightIds { get; set; }
    }
}
