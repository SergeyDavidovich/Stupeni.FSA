using Stupeni.FSA.Entities;
using System.Threading.Tasks;
using System;

namespace Stupeni.FSA.EntityManagers.Interfaces
{
    public interface IBookingManager
    {
        public Task<Booking> CreateBookingAsync(DateTime bookingDate, Guid userId, Flight bookedFlight);
    }
}