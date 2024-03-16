using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Domain.Entities;

namespace Stupeni.FSA.Entities
{
    /// <summary>
    /// Представляет собой данные о бронированных билетах на рейс
    /// Бронирование - это резервация места на определенном рейсе
    /// </summary>
    public class Booking : Entity<Guid>
    {
        private Booking() { }

        internal Booking(Guid id, Guid userId, DateTime bookingDate) : base(id)
        {
            BookingDate = bookingDate;
            UserId = userId;
        }

        /// <summary>
        /// Дата бронирования
        /// </summary>
        public DateTime BookingDate { get; private set; }

        public Guid UserId { get; }

        public IList<int> FlightIds { get; set; } = new List<int>();

        /// <summary>
        /// Навигационное свойство
        /// </summary>
        public IList<Flight> Flights { get; internal set; } = new List<Flight>();

        public double Price
        {
            get
            {
                return Flights.Sum(x => x.Price);
            }
        }

        public void AddFlight(Flight flight)
        {
            Flights.Add(flight);
            FlightIds.Add(flight.Id);
        }
    }
}