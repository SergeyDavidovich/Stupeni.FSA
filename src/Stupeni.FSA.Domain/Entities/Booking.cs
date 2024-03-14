using System;
using Volo.Abp.Domain.Entities;

namespace Stupeni.FSA.Entities
{
    /// <summary>
    /// Представляет собой данные о бронированных билетах на рейс
    /// Бронирование - это резервация места на определенном рейсе самолета
    /// </summary>
    public class Booking : Entity<int>
    {
        private Booking() { }

        public Booking(int id,
            string flightNumber) : base(id)
        {
            FlightNumber = flightNumber;                
        }

        /// <summary>
        /// Дата бронирования
        /// </summary>
        public DateTime BookingDate { get; set; }

        /// <summary>
        /// Является ли билет зарезервированным пользователем. 
        /// True - если резервация всё ещё действительна
        /// False - если резервация не действительна
        /// </summary>
        public bool IsReserved { get; set; }

        /// <summary>
        /// Идентификатор забронированного билета на рейс
        /// </summary>
        public string FlightNumber { get; private set; }

        public Flight Flight { get; set;}
    }
}