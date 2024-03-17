using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using Stupeni.FSA.Flights;
using System.Collections.Generic;
using Stupeni.FSA.Flights.Dto;
using Microsoft.AspNetCore.Http;
using System.Net.Mime;

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
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType<IEnumerable<FlightDto>>(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<FlightDto>>> GetFlights(DateTime departureDate, string deaprtureCity, string destinationCity, double minimumPrice, double maximumPrice, CancellationToken token)
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