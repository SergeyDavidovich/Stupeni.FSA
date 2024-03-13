using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Stupeni.FSA.Entities
{
    /// <summary>
    /// Представляет собой данные о рейсах, забронированные пользователем
    /// Бронирование - это резервация места на определенном рейсе самолета
    /// </summary>
    public class Booking : Entity<int>
    {
        private Booking() { }

        public Booking(int id,
            string flightId) : base(id)
        {
            FlightId = flightId;                
        }

        /// <summary>
        /// Идентификатор забронирование билета на рейс
        /// </summary>
        public string FlightId { get; set; }

        public Flight Flight { get; set; }

        /// <summary>
        /// Дата начала бронирования рейс
        /// </summary>
        public DateTime StartBookingDate { get; set; }

        /// <summary>
        /// Дата окончания бронирования рейса.
        /// Если бронированный рейс не оплачивается до окончания EndBookingDate, то бронь отменяется
        /// </summary>
        public DateTime EndBookingDate { get; set; }

        /// <summary>
        /// Является ли билет зарезервированным пользователем. 
        /// True - если резервация всё ещё действительна
        /// False - если резервация не действительна
        /// </summary>
        public bool IsReserved { get; set; }

        public ICollection<Flight> Flights { get; set;}
    }
}