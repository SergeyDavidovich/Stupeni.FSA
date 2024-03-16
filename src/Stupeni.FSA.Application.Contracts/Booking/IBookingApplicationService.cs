using Stupeni.FSA.Booking.Dto;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Stupeni.FSA.Booking
{
    public interface IBookingApplicationService : IApplicationService
    {
        public Task<BookingDto> CreateBookingAsync(CreateBookingDto dto, CancellationToken token);
        public Task<IEnumerable<BookingDto>> GetBookingsByUserIdAsync(Guid userId, CancellationToken token);
    }
}