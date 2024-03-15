using System;
using System.Collections;
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

        public Booking(Guid id, Guid userId, DateTime bookingDate) : base(id)
        {
            BookingDate = bookingDate;
            UserId = userId;
        }

        /// <summary>
        /// Дата бронирования
        /// </summary>
        public DateTime BookingDate { get; private set; }

        public Guid UserId { get; }

        public ICollection<string> FlightIds { get; set; }

        /// <summary>
        /// Навигационное свойство
        /// </summary>
        public ICollection<Flight> Flights { get; internal set; }

        public double Price
        {
            get
            {
                return Flights.Sum(x => x.Price);
            }
        }
    }
}