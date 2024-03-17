using Shouldly;
using Stupeni.FSA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Stupeni.FSA.Booking.Entity
{
    public class BookingTests
    {
        [Fact]
        public void ShouldReturnCorrectPrice()
        {
            var id1 = Guid.NewGuid();
            var flight1 = new Flight(id1);
            flight1.Price = 100;
            var id2 = Guid.NewGuid();
            var flight2 = new Flight(id2);
            flight2.Price = 100;

            var userId = Guid.NewGuid();

            var booking = new Entities.Booking(Guid.NewGuid(), userId, DateTime.Now);
            //booking.Flights.Add(flight1);
            //booking.Flights.Add(flight2);

            booking.Price.ShouldBe(flight1.Price + flight2.Price);
        }
    }
}
