using Stupeni.FSA.Booking.Dto;
using Stupeni.FSA.Flights.Dto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Stupeni.FSA.Flights
{
    public interface IFlightApplicationService : IApplicationService
    {
        Task<IEnumerable<FlightDto>> GetFlights(DateTime departureDate, string deaprtureCity, string destinationCity, DateTime? arrivalDate = null);
    }
}