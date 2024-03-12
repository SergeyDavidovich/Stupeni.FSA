using System.Collections.Generic;

namespace Stupeni.FSA.Entities
{
    /// <summary>
    /// Представляет собой пользователя.
    /// Пользователь приложения может осуществлять просмотр список доступных рейсов и бронировать их
    /// </summary>
    public class User
    {
        /// <summary>
        /// Уникальный идентификатор для рейса
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string FistName { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        ///  Почта пользователя
        /// </summary>
        public string Email { get; set; }

        public ICollection<UserInFlight> UsersInFlights { get; set; }
    }
}