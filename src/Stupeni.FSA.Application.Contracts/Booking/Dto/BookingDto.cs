using Stupeni.FSA.Flights.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stupeni.FSA.Booking.Dto
{
    public class BookingDto
    {
        public Guid BookingId { get; set; }

        public DateTime BookingDate { get; set; }

        public Guid UserId { get; }

        public FlightDto Flight { get; set; }
    }
}
