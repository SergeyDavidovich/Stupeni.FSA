using Microsoft.Extensions.Caching.Distributed;
using Stupeni.FSA.Flights;
using Stupeni.FSA.Flights.DataSource;
using Stupeni.FSA.Flights.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Caching;

namespace Stupeni.FSA.Flight
{
    public class FlightApplicationService : ApplicationService, IFlightApplicationService
    {
        private readonly ICISFlightsSource _cisFlightsSource;
        private readonly IWorldwideFlightsSource _worldwideFlightsSource;
        private readonly IDistributedCache<IEnumerable<FlightDto>> _flightCache;

        public FlightApplicationService(ICISFlightsSource cisFlightsSource, IWorldwideFlightsSource worldwideFlightsSource,
            IDistributedCache<IEnumerable<FlightDto>> flightCache)
        {
            _cisFlightsSource = cisFlightsSource;
            _worldwideFlightsSource = worldwideFlightsSource;
            _flightCache = flightCache;
        }

        public async Task<IEnumerable<FlightDto>> GetFlightsAsync(DateTime departureDate, string deaprtureCity, string destinationCity, double minimumPrice, double maximumPrice, CancellationToken token)
        {
            var cisFlights = await _flightCache.GetOrAddAsync(
                "cisFlights",
                async () => await _cisFlightsSource.GetFlightsAsync(token),
                () => new DistributedCacheEntryOptions
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddHours(1)
                }, null, false, token);

            var worldwideFlights = await _worldwideFlightsSource.GetFlightsAsync(token);

            var filteredCisFlights = GetFilteredList(cisFlights, departureDate, deaprtureCity, destinationCity, minimumPrice, maximumPrice);
            var filteredWorldWideFlights = GetFilteredList(worldwideFlights, departureDate, deaprtureCity, destinationCity, minimumPrice, maximumPrice);

            return filteredCisFlights.Concat(filteredWorldWideFlights);
        }

        private IEnumerable<FlightDto> GetFilteredList(
            IEnumerable<FlightDto> flights,
            DateTime departureDate,
            string deaprtureCity,
            string destinationCity,
            double? minimumPrice = null,
            double? maximumPrice = null)
        {
            var dayOfDeparture = departureDate.DayOfWeek;

            var filteredList = flights
                .Where(x => x.DepartureCity == deaprtureCity && x.DestinationCity == destinationCity)
                .Where(x => x.DaysOfOperation.Contains(dayOfDeparture));

            if (minimumPrice != null)
                filteredList.Where(x => x.Price > minimumPrice);

            if (maximumPrice != null)
                filteredList.Where(x => x.Price < maximumPrice);

            return filteredList;
        }
    }
}