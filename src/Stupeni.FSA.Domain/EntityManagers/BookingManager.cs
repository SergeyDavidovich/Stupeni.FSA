using Stupeni.FSA.Entities;
using Stupeni.FSA.EntityManagers.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Stupeni.FSA.EntityManagers
{
    public class BookingManager : DomainService, IBookingRepository
    {
        private readonly IRepository<Flight, string> _flightRepository;

        public BookingManager(IRepository<Flight, string> flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task<Booking> CreateAsync(Booking userInFlight, CancellationToken token)
        {
            await IsBookingDateAvailable(userInFlight.Flight.Id, userInFlight.BookingDate, token);
            return userInFlight;
        }

        public async Task<Booking> DeleteAsync(Booking userInFlight, CancellationToken token)
        {
            return userInFlight;
        }

        /// <summary>
        /// Проверка на доступность бронирования билета на рейс по указанной дате
        /// </summary>
        /// <param name="flightNumber">Бронируемый номер рейса </param>
        /// <param name="bookingDate">Дата бронирования</param>
        private async Task IsBookingDateAvailable(string flightNumber, DateTime bookingDate, CancellationToken token)
        {
            // найти рейс по flightNumber, если рейс по flightNumber, то выдать Exception
            var flight = await _flightRepository.FirstOrDefaultAsync(x => x.Id == flightNumber, token)
                ?? throw new Exception($"Flight number {flightNumber} has not been found.");

            // получить номер дня недели bookingDate
            var bookingDateOfWeek = (int)bookingDate.DayOfWeek;

            // проверка даты бронирования в расписании рейсов
            var matchingFlight = flight.DaysOfOperation.Contains(bookingDateOfWeek);

            if (!matchingFlight) { throw new Exception($"Flights are not operated on the specified date."); }
        }
    }
}