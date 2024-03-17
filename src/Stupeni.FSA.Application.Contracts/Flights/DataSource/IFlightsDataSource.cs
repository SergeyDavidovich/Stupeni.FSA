using Stupeni.FSA.Flights.Dto;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Stupeni.FSA.Flights.DataSource
{
    public interface IFlightsDataSource
    {
        public Task<IEnumerable<FlightDto>> GetFlightsAsync(CancellationToken token);
    }
}