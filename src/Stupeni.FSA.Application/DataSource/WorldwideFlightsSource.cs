using Stupeni.FSA.Entities;
using Stupeni.FSA.Flights.DataSource;
using Stupeni.FSA.Flights.Dto;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace Stupeni.FSA.DataSource
{
    public class WorldwideFlightsSource : IWorldwideFlightsSource
    {
        public async Task<IEnumerable<FlightDto>> GetFlightsAsync()
        {
            List<object[]> encodedFlightsData = new List<object[]>
            {
                new object[] 
                {
                    "SU101",
                    new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Friday },
                    "Stambul",
                    "New York",
                    new TimeSpan(10, 0, 0),
                    new TimeSpan(12, 30, 0),
                    "Turkish Airlines",
                    200.0
                },
                new object[]
                {
                    "SU102",
                    new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Friday },
                    "Stambul",
                    "Warsaw",
                    new TimeSpan(10, 0, 0),
                    new TimeSpan(12, 30, 0),
                    "Turkish Airlines",
                    201.0
                }
            };

            List<Entities.Flight> flights = new List<Entities.Flight>();

            ConstructorInfo constructor = typeof(Entities.Flight).GetConstructor(
                BindingFlags.Instance | BindingFlags.NonPublic,
                null,
                new[] { typeof(int) },
                null);

            foreach (var flightData in encodedFlightsData)
            {
                Entities.Flight flight = (Entities.Flight)constructor.Invoke(new object[] { (int)flightData[7] });

                flight.FlightNumber = (string)flightData[0];
                flight.DaysOfOperation.AddRange((List<DayOfWeek>)flightData[1]);
                flight.DepartureCity = (string)flightData[2];
                flight.DestinationCity = (string)flightData[3];
                flight.DepartureTime = (TimeSpan)flightData[4];
                flight.ArrivalTime = (TimeSpan)flightData[5];
                flight.CarrierName = (string)flightData[6];
                flight.Price = (double)flightData[7];

                flights.Add(flight);
            }



            //var flights = new List<Flight>();

            //Type flightType = typeof(Flight);

            //// Get the internal constructor of Flight
            //ConstructorInfo constructor = flightType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(int) }, null);

            //flights.Add((Flight)constructor.Invoke(new object[] { 123 }));

            ////var fligths = new List<Flight>
            ////{
            ////    new Flight()
            ////    {

            ////        FlightNumber = "SU101",
            ////        DaysOfOperation = new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Friday },
            ////        DepartureCity = "Stambul",
            ////        DestinationCity = "London",
            ////        DepartureTime = new TimeSpan(10, 0, 0),
            ////        ArrivalTime = new TimeSpan(12, 30, 0),
            ////        CarrierName = "Turkish Airlines",
            ////        Price = 200.0                
            ////    }
            ////};

            throw new NotImplementedException();

        }
    }
}