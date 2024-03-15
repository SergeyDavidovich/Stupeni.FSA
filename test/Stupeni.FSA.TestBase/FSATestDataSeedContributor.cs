using Stupeni.FSA.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Stupeni.FSA;

public class FSATestDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Flight, int> _flightRepository;
    private readonly IRepository<Booking, Guid> _bookingRepository;

    public FSATestDataSeedContributor(IRepository<Flight, int> flightRepository, IRepository<Booking, Guid> bookingRepository)
    {
        _flightRepository = flightRepository;
        _bookingRepository = bookingRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        await _flightRepository.InsertAsync(
            new Flight(1)
            {
                FlightNumber = "AA-101",
                DepartureCity = "Tashkent",
                DestinationCity = "Prague",
                CarrierName = "UZA",
                DaysOfOperation = new List<DayOfWeek>()
                {
                    DayOfWeek.Monday
                },
                ArrivalTime = new TimeSpan(1, 0, 0),
                DepartureTime = new TimeSpan(12, 0, 0),
                Price = 100
            });

        await _flightRepository.InsertAsync(
            new Flight(2)
            {
                FlightNumber = "AA-102",
                DepartureCity = "Prague",
                DestinationCity = "Tashkent",
                CarrierName = "UZA",
                DaysOfOperation = new List<DayOfWeek>()
                {
                    DayOfWeek.Monday
                },
                ArrivalTime = new TimeSpan(1, 0, 0),
                DepartureTime = new TimeSpan(12, 0, 0),
                Price = 100
            });

        await _flightRepository.InsertAsync(
            new Flight(3)
            {
                FlightNumber = "AA-103",
                DepartureCity = "Moscow",
                DestinationCity = "Tashkent",
                CarrierName = "TurkishAir",
                DaysOfOperation = new List<DayOfWeek>()
                {
                    DayOfWeek.Tuesday
                },
                ArrivalTime = new TimeSpan(1, 0, 0),
                DepartureTime = new TimeSpan(12, 0, 0),
                Price = 100
            });

        await _flightRepository.InsertAsync(
            new Flight(4)
            {
                FlightNumber = "AA-105",
                DepartureCity = "Tashkent",
                DestinationCity = "Moscow",
                CarrierName = "TurkishAir",
                DaysOfOperation = new List<DayOfWeek>()
                {
                    DayOfWeek.Tuesday
                },
                ArrivalTime = new TimeSpan(1, 0, 0),
                DepartureTime = new TimeSpan(12, 0, 0),
                Price = 100
            });


    }
}
