using Stupeni.FSA.Entities;
using System.Threading.Tasks;
using System.Threading;

namespace Stupeni.FSA.EntityManagers.Interfaces
{
    public interface IUserInFlightRepository
    {
        Task<UserInFlight> GetAllAsync(UserInFlight userInFlight, CancellationToken token);
        Task<UserInFlight> GetByIdAsync(UserInFlight userInFlight, CancellationToken token);
        Task<UserInFlight> CreateAsync(UserInFlight userInFlight, CancellationToken token);
        Task<UserInFlight> UpdateAsync(UserInFlight userInFlight, CancellationToken token);
        Task<UserInFlight> DeleteAsync(UserInFlight userInFlight, CancellationToken token);
    }
}