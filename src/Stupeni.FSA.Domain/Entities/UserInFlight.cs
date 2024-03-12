using System;

namespace Stupeni.FSA.Entities
{
    /// <summary>
    /// Представляет собой данные о рейсах, забронированные пользователем
    /// Бронирование - это резервация места на определенном рейсе самолета
    /// </summary>
    public class UserInFlight
    {
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
    }
}