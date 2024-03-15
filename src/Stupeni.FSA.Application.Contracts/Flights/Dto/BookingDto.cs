using System;
using System.Collections.Generic;
using System.Text;

namespace Stupeni.FSA.Flights.Dto
{
    public class BookingDto
    {
        public string DestinationCity { get; set; }

        public string CurrentCity { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }
    }
}
