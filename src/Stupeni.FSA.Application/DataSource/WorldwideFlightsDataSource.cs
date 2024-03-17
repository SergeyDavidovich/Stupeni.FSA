using Stupeni.FSA.Flights.DataSource;
using Stupeni.FSA.Flights.Dto;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Stupeni.FSA.DataSource
{
    public class WorldwideFlightsDataSource : IWorldwideFlightsSource
    {
        public async Task<IEnumerable<FlightDto>> GetFlightsAsync(CancellationToken token)
        {
            await Task.CompletedTask;

            return new List<FlightDto>
            {
                new FlightDto()
                {
                    FlightNumber = "SU101",
                    DaysOfOperation = new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Friday },
                    DepartureCity = "Istanbul",
                    DestinationCity = "London",
                    DepartureTime = new TimeSpan(10, 0, 0),
                    ArrivalTime = new TimeSpan(12, 30, 0),
                    CarrierName = "Turkish Airlines",
                    Price = 200.0
                },
                new FlightDto()
                {
                    FlightNumber = "SU102",
                    DaysOfOperation = new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Friday },
                    DepartureCity = "Istanbul",
                    DestinationCity = "Prague",
                    DepartureTime = new TimeSpan(10, 0, 0),
                    ArrivalTime = new TimeSpan(12, 30, 0),
                    CarrierName = "Turkish Airlines",
                    Price = 300.0
                },
                new FlightDto()
                {
                    FlightNumber = "SU103",
                    DaysOfOperation = new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Friday },
                    DepartureCity = "London",
                    DestinationCity = "Istanbul",
                    DepartureTime = new TimeSpan(10, 0, 0),
                    ArrivalTime = new TimeSpan(12, 30, 0),
                    CarrierName = "Turkish Airlines",
                    Price = 200.0
                },
                new FlightDto()
                {
                    FlightNumber = "SU104",
                    DaysOfOperation = new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Friday },
                    DepartureCity = "Prague",
                    DestinationCity = "Istanbul",
                    DepartureTime = new TimeSpan(10, 0, 0),
                    ArrivalTime = new TimeSpan(12, 30, 0),
                    CarrierName = "Turkish Airlines",
                    Price = 300.0
                },
            };
        }
    }
}