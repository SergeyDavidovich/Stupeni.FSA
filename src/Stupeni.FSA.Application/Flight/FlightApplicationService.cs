using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Stupeni.FSA.Flights;
using Stupeni.FSA.Flights.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Caching;

namespace Stupeni.FSA.Flight
{
    public class FlightApplicationService : ApplicationService, IFlightApplicationService
    {
        private readonly IDistributedCache<IEnumerable<FlightDto>> _flightCache;

        public FlightApplicationService(IDistributedCache<IEnumerable<FlightDto>> flightCache)
        {
            _flightCache = flightCache;
        }

        public async Task<IEnumerable<FlightDto>> GetFlightsAsync(DateTime departureDate, string deaprtureCity, string destinationCity, double minimumPrice, double maximumPrice, CancellationToken token)
        {
            IEnumerable<FlightDto>? cisFlights = new List<FlightDto>();
            IEnumerable<FlightDto>? worldwideFlights = new List<FlightDto>();

            // Получить JSON из Stupeni.FSA.CSIFlightsSourceAPI
            try
            {
                using var httpClient = new HttpClient();
                var x = await httpClient.GetAsync("https://localhost:7196/api/CSIFlights");
                cisFlights = await _flightCache.GetOrAddAsync(
                    "cisFlights",
                    async () => await httpClient.GetFromJsonAsync<IEnumerable<FlightDto>>("https://localhost:7196/api/CSIFlights"),
                () => new DistributedCacheEntryOptions
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddHours(1)
                }, null, false, token);
            }
            catch (TaskCanceledException ex) when (ex.InnerException is TimeoutException)
            {
                Logger.LogError($"Timed out: {ex.Message}");
            }
            catch (TaskCanceledException ex)
            {
                Logger.LogError($"Canceled: {ex.Message}");
            }
            catch(Exception ex) 
            { 
                Logger.LogError(ex.ToString());
            }
            
            var filteredCisFlights = GetFilteredList(cisFlights, departureDate, deaprtureCity, destinationCity, minimumPrice, maximumPrice);

            // Получить JSON из Stupeni.FSA.WorlwideFlightsSourceAPI
            try
            {
                using var httpClient = new HttpClient();

                worldwideFlights = await _flightCache.GetOrAddAsync(
                    "worldwideFlights",
                    async () => await httpClient.GetFromJsonAsync<IEnumerable<FlightDto>>("https://localhost:7021/api/WorlwideFlights\r\n"),
                () => new DistributedCacheEntryOptions
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddHours(1)
                }, null, false, token);
            }
            catch (TaskCanceledException ex) when (ex.InnerException is TimeoutException)
            {
                Logger.LogError($"Timed out: {ex.Message}");
            }
            catch (TaskCanceledException ex)
            {
                Logger.LogError($"Canceled: {ex.Message}");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
            }

            var filteredWorldWideFlights = GetFilteredList(worldwideFlights, departureDate, deaprtureCity, destinationCity, minimumPrice, maximumPrice);

            return filteredCisFlights?.Concat(filteredWorldWideFlights) ?? filteredCisFlights ?? filteredWorldWideFlights ?? new List<FlightDto>();
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