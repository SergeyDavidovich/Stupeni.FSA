using Stupeni.FSA.Entities;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using System;

namespace Stupeni.FSA.EntityManagers.Interfaces
{
    public interface IBookingManager
    {
        public Task<Booking> CreateBookingAsync(DateTime bookingDate, Guid userId, IEnumerable<Flight> bookedFlights, CancellationToken cancellationToken);
    }
}