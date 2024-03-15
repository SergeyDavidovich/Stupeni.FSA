using Stupeni.FSA.Entities;
using Stupeni.FSA.Flights.DataSource;
using Stupeni.FSA.Flights.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stupeni.FSA.DataSource
{
    public class WorldwideFlightsSource : IWorldwideFlightsSource
    {
        public async Task<IEnumerable<FlightDto>> GetFlightsAsync()
        {
            //throw new NotImplementedException();
            var result = new List<Flight>()
            {
                new Flight()
                {
                    FlightNumber = "KC-7315",
                    DaysOfOperation = new List<int> { 1, 2 },
                    DepartureCity = "Tashkent",
                    DestinationCity = "Almaty",
                    DepartureTime = new TimeSpan(10,15,0),
                    ArrivalTime = new TimeSpan(14,0,0),
                    CarrierName = "Uzbekistan Airways",
                    CountTransfers = 0
                }
            };

        }
    }
}