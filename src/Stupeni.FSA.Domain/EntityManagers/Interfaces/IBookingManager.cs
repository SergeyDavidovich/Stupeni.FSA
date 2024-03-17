using Stupeni.FSA.Entities;
using System;

namespace Stupeni.FSA.EntityManagers.Interfaces
{
    public interface IBookingManager
    {
        public Booking CreateBooking(DateTime bookingDate, Guid userId, Flight bookedFlight);
    }
}