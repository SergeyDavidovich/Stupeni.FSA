using Stupeni.FSA.Entities;
using System.Threading.Tasks;
using System.Threading;

namespace Stupeni.FSA.EntityManagers.Interfaces
{
    public interface IBookingRepository
    {
        Task<Booking> CreateAsync(Booking userInFlight, CancellationToken token);
        Task<Booking> DeleteAsync(Booking userInFlight, CancellationToken token);
    }
}