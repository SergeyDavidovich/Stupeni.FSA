using System;
using System.Collections.Generic;

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

        /// <summary>
        /// Количество пересадок
        /// </summary>
        public int CountTransfers { get; set; }
    }
}