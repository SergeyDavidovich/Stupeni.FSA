using Stupeni.FSA.Booking.Dto;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Stupeni.FSA.EntityManagers.Interfaces;

namespace Stupeni.FSA.Booking
{
    public class BookingApplicationService : ApplicationService, IBookingApplicationService
    {
        private readonly IRepository<Entities.Booking, Guid> _bookingRepository;
        private readonly IBookingManager _bookingManager;

        public BookingApplicationService(IRepository<Entities.Booking, Guid> bookingRepository
            , IBookingManager bookingManager)
        {
            _bookingRepository = bookingRepository;
            _bookingManager = bookingManager;
        }

        public async Task<BookingDto> CreateBookingAsync(CreateBookingDto dto, CancellationToken token)
        {
            var booking = await _bookingManager.CreateBookingAsync(
                dto.BookingDate, dto.UserId,
                dto.FlightIds, token);
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BookingDto>> GetBookingsByUserIdAsync(Guid userId, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}