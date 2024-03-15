using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Stupeni.FSA.Entities
{
    /// <summary>
    /// Представляет собой рейс. 
    /// Рейс - это запланированное перемещение самолета от одного аэропорта к другому 
    /// </summary>
    public class Flight : Entity<int>
    {
        private Flight() { }

        internal Flight(int id) : base(id) { }

        /// <summary>
        /// Номер рейса
        /// </summary>
        public string FlightNumber { get; set; }

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
        /// Время вылета. Часы и минуты
        /// </summary>
        public TimeSpan DepartureTime { get; set; }

        /// <summary>
        /// Время прилёта. Часы и минуты
        /// </summary>
        public TimeSpan ArrivalTime { get; set; }

        /// <summary>
        /// Название перевозчика. Например, Uzbekistan Airways
        /// </summary>
        public string CarrierName { get; set; }

        /// <summary>
        /// Навигационное свойство
        /// </summary>
        public Booking Booking { get; set; }
    }
}