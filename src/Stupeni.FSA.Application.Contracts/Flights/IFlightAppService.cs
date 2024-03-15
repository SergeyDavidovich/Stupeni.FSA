using Stupeni.FSA.Flights.Dto;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Stupeni.FSA.Flights
{
    public interface IFlightAppService : IApplicationService
    {
        Task<IEnumerable<FlightDto>> GetFlights(BookingDto dto);
    }
}