using Stupeni.FSA.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Stupeni.FSA.EntityManagers.Interfaces
{
    public interface IFlightRepository
    {
        Task<Flight> GetAllAsync(Flight flight, CancellationToken token);
        Task<Flight> GetByIdAsync(Flight flight, CancellationToken token);
        Task<Flight> CreateAsync(Flight flight, CancellationToken token);
        Task<Flight> UpdateAsync(Flight flight, CancellationToken token);
        Task<Flight> DeleteAsync(Flight flight, CancellationToken token);
    }
}