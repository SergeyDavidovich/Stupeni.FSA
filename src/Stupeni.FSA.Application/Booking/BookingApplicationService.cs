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

namespace Stupeni.FSA.Booking
{
    public class BookingApplicationService : ApplicationService, IBookingApplicationService
    {
        private readonly IRepository<Entities.Booking, Guid> _bookingRepository;
        private readonly IRepository<Entities.Flight, Guid> _flightRepository;
        private readonly IBookingManager _bookingManager;
        private readonly IDistributedCache<List<Entities.Flight>> _flightCache;
        private readonly IDistributedCache<List<Entities.Booking>> _bookingCache;

        public BookingApplicationService(IRepository<Entities.Booking, Guid> bookingRepository,
            IRepository<Entities.Flight, Guid> flightRepository, IBookingManager bookingManager,
            IDistributedCache<List<Entities.Flight>> flightCache, IDistributedCache<List<Entities.Booking>> bookingCache)
        {
            _bookingRepository = bookingRepository;
            _flightRepository = flightRepository;
            _bookingManager = bookingManager;
            _flightCache = flightCache;
            _bookingCache = bookingCache;
        }

        public async Task CreateBookingAsync(CreateBookingDto dto, CancellationToken token)
        {
            var flight = await AddFlights(dto, token);

            var booking = await _bookingManager.CreateBookingAsync(
                dto.BookingDate, dto.UserId,
                flight);

            await _bookingRepository.InsertAsync(booking, cancellationToken: token);
        }

        private async Task<Entities.Flight> AddFlights(CreateBookingDto dto, CancellationToken token)
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
            var query = await _bookingRepository.GetQueryableAsync();

            var bookings = query.Where(x => x.UserId == userId).ToList();

            return ObjectMapper.Map<List<Entities.Booking>, List<BookingDto>>(bookings);
        }
    }
}