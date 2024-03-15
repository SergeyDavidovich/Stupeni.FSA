using Shouldly;
using Stupeni.FSA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Stupeni.FSA.Booking
{
    public class BookingTests
    {
        [Fact]
        public void ShouldReturnCorrectPrice()
        {
            var flight1 = new Flight(1);
            flight1.Price = 100;
            var flight2 = new Flight(2);
            flight2.Price = 100;

            var userId = Guid.NewGuid();

            var booking = new Stupeni.FSA.Entities.Booking(Guid.NewGuid(), userId, DateTime.Now);
            booking.Flights.Add(flight1);
            booking.Flights.Add(flight2);

            booking.Price.ShouldBe(flight1.Price + flight2.Price);
        }
    }
}
