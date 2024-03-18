using Stupeni.FSA.Entities;
using Stupeni.FSA.EntityManagers.Interfaces;
using Stupeni.FSA.Exceptions;
using System;
using Volo.Abp.Domain.Services;

namespace Stupeni.FSA.EntityManagers
{
    public class BookingManager : DomainService, IBookingManager
    {
        public Booking CreateBooking(DateTime bookingDate, Guid userId, Flight bookedFlight)
        {
            var booking = new Booking(Guid.NewGuid(), userId, bookingDate);

            ThrowIfFlightNotOperatingOnBookingDate(bookedFlight, bookingDate);
            booking.AddFlight(bookedFlight);

            return booking;
        }

        /// <summary>
        /// Проверка на доступность бронирования билета на рейс по указанной дате
        /// </summary>
        /// <param name="flightId">Бронируемый номер рейса </param>
        /// <param name="bookingDate">Дата бронирования</param>
        private void ThrowIfFlightNotOperatingOnBookingDate(Flight flight, DateTime bookingDate)
        {
            // проверка даты бронирования в расписании рейсов
            var matchingFlight = flight.DaysOfOperation.Contains(bookingDate.DayOfWeek);

            if (!matchingFlight) { throw new FlightNotOperatOnBookedDate($"Flights are not operated on the specified date."); }
        }
    }
}