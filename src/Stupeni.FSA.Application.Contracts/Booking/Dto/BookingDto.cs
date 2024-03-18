using Stupeni.FSA.Flights.Dto;
using System;

namespace Stupeni.FSA.Booking.Dto
{
    public class BookingDto
    {
        public Guid BookingId { get; set; }

        public DateTime BookingDate { get; set; }

        public Guid UserId { get; set; }

        public FlightDto Flight { get; set; }
    }
}