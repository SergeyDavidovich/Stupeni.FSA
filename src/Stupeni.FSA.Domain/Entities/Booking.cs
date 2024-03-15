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

        public Booking(Guid id, DateTime bookingDate) : base(id) 
        {
            BookingDate = bookingDate;
        }

        /// <summary>
        /// Дата бронирования
        /// </summary>
        public DateTime BookingDate { get; private set; }

        /// <summary>
        /// Навигационное свойство
        /// </summary>
        public ICollection<Flight> Flighs { get; internal set; }

        public double Price 
        {
            get
            {
                return Flighs.Sum(x => x.Price);
            }
        }
    }
}