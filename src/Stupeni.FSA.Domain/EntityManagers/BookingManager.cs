using Stupeni.FSA.Entities;
using Stupeni.FSA.EntityManagers.Interfaces;
using Stupeni.FSA.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Stupeni.FSA.EntityManagers
{
    public class BookingManager : DomainService, IBookingManager
    {
        private readonly IRepository<Flight, int> _flightRepository;

        public BookingManager(IRepository<Flight, int> flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task<Booking> CreateBookingAsync(DateTime bookingDate, Guid userId,
            IEnumerable<Flight> bookedFlights, CancellationToken cancellationToken)
        {
            var booking = new Booking(Guid.NewGuid(), userId, bookingDate);

            foreach(var flight in bookedFlights)
            {
                await ThrowIfFlightNotOperatingOnBookingDate(flight.Id, bookingDate, cancellationToken);
                booking.AddFlight(flight);
            }

            return booking;
        }

        /// <summary>
        /// Проверка на доступность бронирования билета на рейс по указанной дате
        /// </summary>
        /// <param name="flightId">Бронируемый номер рейса </param>
        /// <param name="bookingDate">Дата бронирования</param>
        private async Task ThrowIfFlightNotOperatingOnBookingDate(int flightId, DateTime bookingDate, CancellationToken token)
        {
            // найти рейс по flightNumber, если рейс по flightNumber, то выдать Exception
            var flight = await _flightRepository.FindAsync(flightId, cancellationToken: token)
                ?? throw new Exception($"Flight number {flightId} has not been found.");

            // проверка даты бронирования в расписании рейсов
            var matchingFlight = flight.DaysOfOperation.Contains(bookingDate.DayOfWeek);

            if (!matchingFlight) { throw new FlightNotOperatOnBookedDate($"Flights are not operated on the specified date."); }
        }
    }
}