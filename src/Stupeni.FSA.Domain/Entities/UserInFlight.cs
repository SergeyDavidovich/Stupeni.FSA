using System;
using Stupeni.FSA.Enums;
using Volo.Abp.Domain.Entities;

namespace Stupeni.FSA.Entities
{
    /// <summary>
    /// Представляет собой данные о рейсах, забронированные пользователем
    /// Бронирование - это резервация места на определенном рейсе самолета
    /// </summary>
    public class UserInFlight : Entity
    {
        private UserInFlight() { }

        public UserInFlight(
            int userId,
            int flightTicketId)
        {
            UserId = userId;
            FlightTicketId = flightTicketId;                
        }

        /// <summary>
        /// Идентификатор пользователя, осуществляющего бронирование
        /// </summary>
        public int UserId { get; set; }

        public User User { get; set; }

        /// <summary>
        /// Идентификатор забронирование билета на рейс
        /// </summary>
        public int FlightTicketId { get; set; }

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

        public UserInFlightStatus Status { get; set; }

        public override object?[] GetKeys()
        {
            return [UserId, FlightTicketId];
        }
    }
}