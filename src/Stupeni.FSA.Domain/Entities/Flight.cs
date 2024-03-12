using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Stupeni.FSA.Entities
{
    /// <summary>
    /// Представляет собой рейс. Рейс - это запланированное перемещение самолета от одного аэропорта к другому 
    /// </summary>
    public class Flight : AggregateRoot<int>
    {
        internal Flight() { }

        public Flight(int id, 
            [NotNull] string aircraft     
            ) : base(id)
        {
            SetAircraft(aircraft);
        }

        /// <summary>
        /// Дата проведения полета
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Название авиакомпании
        /// </summary>
        public string AirlineName { get; set; }

        /// <summary>
        /// Тип или регистрационный номер воздушного судна, использовавшегося для полета
        /// </summary>
        public string Aircraft { get; set; }

        /// <summary>
        /// Запланированное время отправления (STD)
        /// </summary>
        public DateTime STD { get; set; }

        /// <summary>
        /// Фактическое время отправления (ATD)
        /// </summary>
        public DateTime ATD { get; set; }

        /// <summary>
        /// Запланированное время прибытия (STA)
        /// </summary>
        public DateTime STA { get; set; }

        /// <summary>
        /// Текущий статус рейса (например, задержан, прибыл вовремя, приземлился)
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Место вылета рейса
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// Пункт назначения полета
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// Продолжительность полета
        /// </summary>
        public TimeSpan FlightTime { get; set; }

        public ICollection<UserInFlight> UsersInFlights { get; set; }

        /// <summary>
        /// Присвоение типа или регистрационного номера воздушного судна.
        /// Присвоение осуществляется после проверки параметра на null, наличие пробелов
        /// и на количество символов, которое не должно превышать разрешенное количество символов
        /// </summary>
        /// <param name="aircraft">Тип или регистрационный номер воздушного судна, использовавшегося для полета</param>
        private void SetAircraft(string aircraft)
        {
            Aircraft = Check.NotNullOrWhiteSpace(
                aircraft,
                nameof(aircraft),
                minLength: FlightConsts.MinAircraftLength,
                maxLength: FlightConsts.MaxAircraftLength);
        }
    }
}