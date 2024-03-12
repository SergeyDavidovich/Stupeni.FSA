namespace Stupeni.FSA
{
    public enum UserInFlightStatus
    {
        Confirmed, // Бронирование было успешно обработано и подтверждено
        Cancelled // Бронирование отменено, если рейс не подтверждается до окончания EndBookingDate, то бронь отменяется
    }
}