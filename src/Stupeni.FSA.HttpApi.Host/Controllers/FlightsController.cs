using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using Stupeni.FSA.Flights;

namespace Stupeni.FSA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : AbpController
    {
        private readonly IFlightApplicationService _flightApplicationService;

        public FlightsController(IFlightApplicationService flightApplicationService)
        {
            _flightApplicationService = flightApplicationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFlights(DateTime departureDate, string deaprtureCity, string destinationCity, double minimumPrice, double maximumPrice, CancellationToken token)
        {
            try
            {
                var result = await _flightApplicationService.GetFlightsAsync(departureDate, deaprtureCity, destinationCity, minimumPrice, maximumPrice, token);

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(503);
            }
        }
    }
}