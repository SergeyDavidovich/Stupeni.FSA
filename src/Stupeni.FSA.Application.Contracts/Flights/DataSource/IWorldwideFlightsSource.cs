namespace Stupeni.FSA.Flights.DataSource
{
    /// <summary>
    /// Позволяет регистрировать реализацию сервиса, который возвращает рейсы,
    /// которые действуют по всему миру
    /// </summary>
    public interface IWorldwideFlightsSource : IFlightsDataSource { }
}