using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Volo.Abp.Domain.Entities;

namespace Stupeni.FSA.Entities
{
    /// <summary>
    /// Представляет собой рейс. Рейс - это запланированное перемещение самолета от одного аэропорта к другому 
    /// </summary>
    public class Flight : Entity<string>
    {
        private Flight() { }

        internal Flight(string flightNumber,
            [NotNull] int bookingId) : base(flightNumber) 
        {
            BookingId = bookingId;
        }

        /// <summary>
        /// Дни полета. Может быть в диапозоне от 1 до 7, где 1 - это понедельник, а 7 - это воскресенье 
        /// </summary>
        public List<int> DaysOfOperation { get; set; }

        /// <summary>
        /// Город вылета
        /// </summary>
        public string DepartureCity { get; set; }

        /// <summary>
        /// Город прибытия
        /// </summary>
        public string DestinationCity { get; set; }

        /// <summary>
        /// Время вылета
        /// </summary>
        public DateTime DepartureTime { get; set; }

        /// <summary>
        /// Время прилёта
        /// </summary>
        public DateTime ArrivalTime { get; set; }

        /// <summary>
        /// Название перевозчика. Например, Uzbekistan Airways
        /// </summary>
        public string CarrierName { get; set; }

        public int BookingId { get; private set; }

        public Booking Booking { get; set; }
    }
}