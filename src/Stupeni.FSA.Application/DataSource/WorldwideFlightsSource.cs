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
            throw new NotImplementedException();
        }
    }
}