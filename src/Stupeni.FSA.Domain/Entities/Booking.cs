using System;
using System.Collections;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Stupeni.FSA.Entities
{
    /// <summary>
    /// Представляет собой данные о бронированных билетах на рейс
    /// Бронирование - это резервация места на определенном рейсе
    /// </summary>
    public class Booking : Entity<int>
    {
        private Booking() { }

        public Booking(int id) : base(id) { }

        /// <summary>
        /// Дата бронирования
        /// </summary>
        public DateTime BookingDate { get; set; }

        /// <summary>
        /// Идентификатор забронированного билета на рейс
        /// </summary>
        public ICollection<int> FlightId { get; private set; }

        /// <summary>
        /// Навигационное свойство
        /// </summary>
        public ICollection<Flight> Flighs { get; set;}
    }
}