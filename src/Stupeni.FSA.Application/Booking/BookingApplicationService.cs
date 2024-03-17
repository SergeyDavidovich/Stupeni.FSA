using Stupeni.FSA.Booking.Dto;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Stupeni.FSA.EntityManagers.Interfaces;
using System.Linq;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;

namespace Stupeni.FSA.Booking
{
    public class BookingApplicationService : ApplicationService, IBookingApplicationService
    {
        private readonly IRepository<Entities.Booking, Guid> _bookingRepository;
        private readonly IRepository<Entities.Flight, Guid> _flightRepository;
        private readonly IBookingManager _bookingManager;
        private readonly IDistributedCache<IQueryable<Entities.Booking>> _bookingCache;

        public BookingApplicationService(IRepository<Entities.Booking, Guid> bookingRepository,
            IRepository<Entities.Flight, Guid> flightRepository, IBookingManager bookingManager,
            IDistributedCache<IQueryable<Entities.Booking>> bookingCache)
        {
            _bookingRepository = bookingRepository;
            _flightRepository = flightRepository;
            _bookingManager = bookingManager;
            _bookingCache = bookingCache;
        }

        public async Task CreateBookingAsync(CreateBookingDto dto, CancellationToken token)
        {
            var flight = await AddFlight(dto, token);

            var booking = _bookingManager.CreateBookingAsync(
                dto.BookingDate, dto.UserId, flight);

            await _bookingRepository.InsertAsync(booking, cancellationToken: token);
        }

        private async Task<Entities.Flight> AddFlight(CreateBookingDto dto, CancellationToken token)
        {
            var flight = new Entities.Flight(Guid.NewGuid())
            {
                ArrivalTime = dto.Flight.ArrivalTime,
                CarrierName = dto.Flight.CarrierName,
                DaysOfOperation = dto.Flight.DaysOfOperation,
                DepartureCity = dto.Flight.DepartureCity,
                DepartureTime = dto.Flight.DepartureTime,
                DestinationCity = dto.Flight.DestinationCity,
                FlightNumber = dto.Flight.FlightNumber,
                Price = dto.Flight.Price
            };

            await _flightRepository.InsertAsync(flight, cancellationToken: token);
            return flight;
        }

        public async Task<List<BookingDto>> GetBookingsByUserIdAsync(Guid userId, CancellationToken token)
        {
            var bookingQuery = await _bookingCache.GetOrAddAsync(
                "bookingQuery",
                async () => await _bookingRepository.GetQueryableAsync(),
                () => new DistributedCacheEntryOptions
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddHours(1)
                }, null, false, token);

            var bookings = bookingQuery.Where(x => x.UserId == userId).ToList();

            foreach (var  booking in bookings)
            {
                var childFlight = await _flightRepository.SingleAsync(x => x.Id == booking.FlightId);
                booking.Flight = childFlight;
            }

            return ObjectMapper.Map<List<Entities.Booking>, List<BookingDto>>(bookings);
        }
    }
}