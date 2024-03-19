using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Stupeni.FSA.Flights.Dto
{
    public class FlightDto
    {
        /// <summary>
        /// Номер рейса
        /// </summary>
        public string FlightNumber { get; set; }

        /// <summary>
        /// Дни полета
        /// </summary>
        [JsonConverter(typeof(DayOfWeekConverter))]
        public List<DayOfWeek> DaysOfOperation { get; set; }

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
        public TimeSpan DepartureTime { get; set; }

        /// <summary>
        /// Время прилёта
        /// </summary>
        public TimeSpan ArrivalTime { get; set; }

        /// <summary>
        /// Название перевозчика. Например, Uzbekistan Airways
        /// </summary>
        public string CarrierName { get; set; }

        public double Price { get; set; }
    }
}