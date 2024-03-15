using Stupeni.FSA.Booking.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Stupeni.FSA.Booking
{
    public interface IBookingApplicationService : IApplicationService
    {
        public Task BookFlights(CreateBookingDto dto);

        public Task<IEnumerable<BookingDto>> GetBookings(Guid userId);
    }
}
