using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Xunit;

namespace Stupeni.FSA.Flights
{
    public abstract class FlightsApplicationLayerTest<TStartupModule> : FSAApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly IFlightApplicationService _flightApplicationService;

        protected FlightsApplicationLayerTest()
        {
            _flightApplicationService = GetRequiredService<IFlightApplicationService>();
        }

        [Fact]
        public async Task ShouldReturnFilteredFlights()
        {
            var departureCity = "Tashkent";
            var destinationCity = "Almata";
            var departureDate = new DateTime(2024, 3, 18); // Monday

            var flights = await _flightApplicationService.GetFlightsAsync(departureDate, departureCity, destinationCity, default);

            flights.ShouldNotContain(x => 
            x.DepartureCity != departureCity && 
            x.DestinationCity != destinationCity && 
            !x.DaysOfOperation.Contains(departureDate.DayOfWeek));
        }
    }
}
