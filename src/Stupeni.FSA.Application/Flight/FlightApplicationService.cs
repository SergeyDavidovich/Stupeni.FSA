using Stupeni.FSA.Flights;
using Stupeni.FSA.Flights.Dto;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Stupeni.FSA.Flight
{
    public class FlightApplicationService : ApplicationService, IFlightApplicationService
    {
        private readonly IRepository<Entities.Flight, int> _flightRepository;

        public Task<IEnumerable<FlightDto>> GetFlightsAsync(DateTime departureDate, string deaprtureCity, string destinationCity, CancellationToken token, DateTime? arrivalDate = null, double? minimumPrice = null, double? maximumPrice = null)
        {
            throw new NotImplementedException();
        }
    }
}
