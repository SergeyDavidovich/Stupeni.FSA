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
        public async Task ShouldCreateBookingSuccessfully()
        {
            var flight = new Flight(1);
            var bookingDate = new DateTime(2024, 3, 18); // 18.03.2024, Monday
            var repo = Substitute.For<IRepository<Flight, int>>();

            repo.FindAsync(Arg.Is<int>(1), cancellationToken: default).Returns(flight);

            var manager = new BookingManager(repo);

            flight.DaysOfOperation.Add(DayOfWeek.Monday);

            var booking = await manager.CreateBookingAsync(bookingDate, Guid.NewGuid(), new List<Flight>() { flight }, default);

            booking.Flights.ShouldContain(flight);
            booking.FlightIds.ShouldContain(flight.Id);
            booking.ShouldNotBeNull();
        }

        [Fact]
        public async Task ShouldThrowIfNoFlightOnBookedDate()
        {
            var flight = new Flight(1);
            var bookingDate = new DateTime(2024, 3, 18); // 18.03.2024, Monday
            var repo = Substitute.For<IRepository<Flight, int>>();

            repo.FindAsync(Arg.Is<int>(flight.Id), cancellationToken: default).Returns(flight);

            var manager = new BookingManager(repo);

            flight.DaysOfOperation.Add(DayOfWeek.Tuesday);

            var func = () => manager.CreateBookingAsync(bookingDate, Guid.NewGuid(), new List<Flight>() { flight }, default);
            await func.ShouldThrowAsync<FlightNotOperatOnBookedDate>();
        }
    }
}
