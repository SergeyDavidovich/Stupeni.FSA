using NSubstitute;
using Shouldly;
using Stupeni.FSA.Entities;
using Stupeni.FSA.EntityManagers;
using Stupeni.FSA.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Stupeni.FSA.Booking.EntityManager
{
    public class BookingManagerTest
    {
        [Fact]
        public void ShouldCreateBookingSuccessfully()
        {
            var guid = Guid.NewGuid();
            var flight = new Flight(guid);
            var bookingDate = new DateTime(2024, 3, 18); // 18.03.2024, Monday

            var manager = new BookingManager();

            flight.DaysOfOperation.Add(DayOfWeek.Monday);

            var booking = manager.CreateBooking(bookingDate, Guid.NewGuid(), flight);

            booking.Flight.ShouldBe(flight);
            booking.FlightId.ShouldBe(flight.Id);
            booking.ShouldNotBeNull();
        }

        [Fact]
        public void ShouldThrowIfNoFlightOnBookedDate()
        {
            var guid = Guid.NewGuid();
            var flight = new Flight(guid);
            var bookingDate = new DateTime(2024, 3, 18); // 18.03.2024, Monday

            var manager = new BookingManager();

            flight.DaysOfOperation.Add(DayOfWeek.Tuesday);

            var func = () => manager.CreateBooking(bookingDate, Guid.NewGuid(), flight);
            func.ShouldThrow<FlightNotOperatOnBookedDate>();
        }
    }
}
