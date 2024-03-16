﻿using Stupeni.FSA.Flights;
using Stupeni.FSA.Flights.DataSource;
using Stupeni.FSA.Flights.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Stupeni.FSA.Flight
{
    public class FlightApplicationService : ApplicationService, IFlightApplicationService
    {
        private readonly ICISFlightsSource _cisFlightsSource;
        private readonly IWorldwideFlightsSource _worldwideFlightsSource;

        public FlightApplicationService(ICISFlightsSource cisFlightsSource, IWorldwideFlightsSource worldwideFlightsSource)
        {
            _cisFlightsSource = cisFlightsSource;
            _worldwideFlightsSource = worldwideFlightsSource;
        }

        public async Task<IEnumerable<FlightDto>> GetFlightsAsync(DateTime departureDate, string deaprtureCity, string destinationCity, CancellationToken token, DateTime? arrivalDate = null, double? minimumPrice = null, double? maximumPrice = null)
        {
            var cisFlights = await _cisFlightsSource.GetFlightsAsync();
            var worldwideFlights = await _worldwideFlightsSource.GetFlightsAsync();

            var filteredCisFlights = GetFilteredList(cisFlights, departureDate, deaprtureCity, destinationCity, token, minimumPrice, maximumPrice);
            var filteredWorldWideFlights = GetFilteredList(worldwideFlights, departureDate, deaprtureCity, destinationCity, token, minimumPrice, maximumPrice);

            return filteredCisFlights.Concat(filteredWorldWideFlights);
        }

        private IEnumerable<FlightDto> GetFilteredList(
            IEnumerable<FlightDto> flights, 
            DateTime departureDate, 
            string deaprtureCity, 
            string destinationCity, 
            CancellationToken token,
            double? minimumPrice = null, 
            double? maximumPrice = null)
        {
            var dayOfDeparture = departureDate.DayOfWeek;

            var filteredList = flights
                .Where(x => x.DepartureCity == deaprtureCity && x.DestinationCity == destinationCity)
                .Where(x => x.DaysOfOperation.Contains(dayOfDeparture))
                .Where(x => x.Price > minimumPrice && x.Price < maximumPrice);

            return filteredList;
        }
    }
}
