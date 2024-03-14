using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace Stupeni.FSA.Flights
{
    public class SearchFlightDto
    {
        /// <summary>
        /// Номер рейса
        /// </summary>
        [Required]
        public string flightNumber {  get; set; }

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

    }
}