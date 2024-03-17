using Stupeni.FSA.Entities;
using System;

namespace Stupeni.FSA.EntityManagers.Interfaces
{
    public interface IBookingManager
    {
        public Booking CreateBookingAsync(DateTime bookingDate, Guid userId, Flight bookedFlight);
    }
}