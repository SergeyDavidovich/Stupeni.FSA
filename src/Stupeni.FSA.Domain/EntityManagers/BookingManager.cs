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
        public async Task<Booking> CreateBookingAsync(DateTime bookingDate, Guid userId,
            IEnumerable<Flight> bookedFlights, CancellationToken cancellationToken)
        {
            var booking = new Booking(Guid.NewGuid(), userId, bookingDate);

            foreach(var flight in bookedFlights)
            {
                ThrowIfFlightNotOperatingOnBookingDate(flight, bookingDate, cancellationToken);
                booking.AddFlight(flight);
            }

            return booking;
        }

        /// <summary>
        /// Проверка на доступность бронирования билета на рейс по указанной дате
        /// </summary>
        /// <param name="flightId">Бронируемый номер рейса </param>
        /// <param name="bookingDate">Дата бронирования</param>
        private void ThrowIfFlightNotOperatingOnBookingDate(Flight flight, DateTime bookingDate, CancellationToken token)
        {
            // проверка даты бронирования в расписании рейсов
            var matchingFlight = flight.DaysOfOperation.Contains(bookingDate.DayOfWeek);

            if (!matchingFlight) { throw new FlightNotOperatOnBookedDate($"Flights are not operated on the specified date."); }
        }
    }
}