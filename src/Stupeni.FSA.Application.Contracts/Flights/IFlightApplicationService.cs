using Stupeni.FSA.Flights.Dto;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Stupeni.FSA.Flights
{
    public interface IFlightApplicationService : IApplicationService
    {
        Task<IEnumerable<FlightDto>> GetFlightsAsync(
            DateTime departureDate, 
            string deaprtureCity, 
            string destinationCity, 
            double minimumPrice, 
            double maximumPrice,
            CancellationToken token);
    }
}