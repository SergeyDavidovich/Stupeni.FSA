using Stupeni.FSA.Entities;
using Stupeni.FSA.EntityManagers.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Stupeni.FSA.EntityManagers
{
    public class BookingManager : DomainService
    {
        private readonly IRepository<Flight, int> _flightRepository;

        public BookingManager(IRepository<Flight, int> flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task<Booking> CreateBookingAsync(DateTime bookingDate, IEnumerable<Flight> bookedFlights, CancellationToken cancellationToken)
        {
            var booking = new Booking(Guid.NewGuid(), bookingDate);
            foreach(var flight in bookedFlights)
            {
                await ThrowIfFlightNotOperatingOnBookingDate(flight.FlightNumber, bookingDate, cancellationToken);
                booking.Fligths.Add(flight);
            }

            return booking;
        }

        /// <summary>
        /// Проверка на доступность бронирования билета на рейс по указанной дате
        /// </summary>
        /// <param name="flightNumber">Бронируемый номер рейса </param>
        /// <param name="bookingDate">Дата бронирования</param>
        private async Task ThrowIfFlightNotOperatingOnBookingDate(string flightNumber, DateTime bookingDate, CancellationToken token)
        {
            // найти рейс по flightNumber, если рейс по flightNumber, то выдать Exception
            var flight = await _flightRepository.FirstOrDefaultAsync(x => x.Id == flightId, token)
                ?? throw new Exception($"Flight number {flightId} has not been found.");

            // проверка даты бронирования в расписании рейсов
            var matchingFlight = flight.DaysOfOperation.Contains(bookingDate.DayOfWeek);

            if (!matchingFlight) { throw new Exception($"Flights are not operated on the specified date."); }
        }
    }
}