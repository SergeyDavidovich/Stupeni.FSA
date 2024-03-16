using Stupeni.FSA.Flights.DataSource;
using Stupeni.FSA.Flights.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Stupeni.FSA.DataSource
{
    public class CisFlightsDataSource : ICISFlightsSource
    {
        public async Task<IEnumerable<FlightDto>> GetFlightsAsync()
        {
            await Task.CompletedTask;

            return new List<FlightDto>()
            {
                new FlightDto()
                {
                    FlightNumber = "AA-001",
                    DepartureCity = "Tashkent",
                    DestinationCity = "Almata",
                    ArrivalTime = new TimeSpan(1,0,0),
                    DepartureTime = new TimeSpan(2,0,0),
                    DaysOfOperation = new List<DayOfWeek>(){DayOfWeek.Monday},
                    CarrierName = "UZA",
                    Price = 100
                },
                new FlightDto()
                {
                    FlightNumber = "AA-002",
                    DepartureCity = "Tashkent",
                    DestinationCity = "Astana",
                    ArrivalTime = new TimeSpan(1,0,0),
                    DepartureTime = new TimeSpan(2,0,0),
                    DaysOfOperation = new List<DayOfWeek>(){DayOfWeek.Tuesday},
                    CarrierName = "UZA",
                    Price = 100
                },
                new FlightDto()
                {
                    FlightNumber = "AA-003",
                    DepartureCity = "Almata",
                    DestinationCity = "Tashkent",
                    ArrivalTime = new TimeSpan(1,0,0),
                    DepartureTime = new TimeSpan(2,0,0),
                    DaysOfOperation = new List<DayOfWeek>(){DayOfWeek.Monday},
                    CarrierName = "UZA",
                    Price = 100
                },
                new FlightDto()
                {
                    FlightNumber = "AA-004",
                    DepartureCity = "Astana",
                    DestinationCity = "Tashkent",
                    ArrivalTime = new TimeSpan(1,0,0),
                    DepartureTime = new TimeSpan(2,0,0),
                    DaysOfOperation = new List<DayOfWeek>(){DayOfWeek.Tuesday},
                    CarrierName = "UZA",
                    Price = 100
                }
            };
        }
    }
}
