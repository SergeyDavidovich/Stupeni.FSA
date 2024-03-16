using Stupeni.FSA.Booking.Dto;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Stupeni.FSA.EntityManagers.Interfaces;
using System.Linq;

namespace Stupeni.FSA.Booking
{
    public class BookingApplicationService : ApplicationService, IBookingApplicationService
    {
        private readonly IRepository<Entities.Booking, Guid> _bookingRepository;
        private readonly IRepository<Entities.Flight, Guid> _flightRepository;
        private readonly IBookingManager _bookingManager;

        public BookingApplicationService(IRepository<Entities.Booking, Guid> bookingRepository,
            IRepository<Entities.Flight, Guid> flightRepository, IBookingManager bookingManager)
        {
            _bookingRepository = bookingRepository;
            _flightRepository = flightRepository;
            _bookingManager = bookingManager;
        }

        public async Task CreateBookingAsync(CreateBookingDto dto, CancellationToken token)
        {
            var flights = new List<Entities.Flight>();
            foreach (var flightDto in dto.Flights)
            {
                var flight = new Entities.Flight(Guid.NewGuid());

                flight.ArrivalTime = flightDto.ArrivalTime;
                flight.CarrierName = flightDto.CarrierName;
                flight.DaysOfOperation = flightDto.DaysOfOperation;
                flight.DepartureCity = flightDto.DepartureCity;
                flight.DepartureTime = flightDto.DepartureTime;
                flight.DestinationCity = flightDto.DestinationCity;
                flight.FlightNumber = flightDto.FlightNumber;
                flight.Price = flightDto.Price;

                flights.Add(flight);

                await _flightRepository.InsertAsync(flight);
            }

            var booking = await _bookingManager.CreateBookingAsync(
                dto.BookingDate, dto.UserId,
                flights, token);

            await _bookingRepository.InsertAsync(booking, cancellationToken: token);
        }

        public async Task<List<BookingDto>> GetBookingsByUserIdAsync(Guid userId, CancellationToken token)
        {
            var query = await _bookingRepository.GetQueryableAsync();

            var bookings = query.Where(x => x.UserId == userId).ToList();

            // нужен маппинг
            var bookingDtos = ObjectMapper.Map<
                List<Entities.Booking>, List<BookingDto>>
                (bookings);

            return bookingDtos;
        }
    }
}