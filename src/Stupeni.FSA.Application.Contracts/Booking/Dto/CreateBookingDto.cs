using System;
using System.Collections.Generic;
using System.Text;

namespace Stupeni.FSA.Booking.Dto
{
    public class CreateBookingDto
    {
        public DateTime BookingDate { get; set; }

        public Guid UserId { get; set; }

        public ICollection<string> FlightIds { get; set; }
    }
}
