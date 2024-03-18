using System;
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

        /// <summary>
        /// Идентификатор пользователя осуществившего бронирование
        /// </summary>
        public Guid UserId { get; private set; }

        public Guid FlightId { get; internal set; }

        /// <summary>
        /// Навигационное свойство
        /// </summary>
        public Flight Flight { get; set; }

        public void AddFlight(Flight flight)
        {
            Flight = flight;
            FlightId = flight.Id;
        }
    }
}