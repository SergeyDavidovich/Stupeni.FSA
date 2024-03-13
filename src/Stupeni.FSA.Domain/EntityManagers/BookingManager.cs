using Stupeni.FSA.Entities;
using Stupeni.FSA.EntityManagers.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Stupeni.FSA.EntityManagers
{
    public class BookingManager : DomainService, IBookingRepository
    {
        public async Task<Booking> CreateAsync(Booking userInFlight, CancellationToken token)
        {
            return userInFlight;
        }

        public async Task<Booking> DeleteAsync(Booking userInFlight, CancellationToken token)
        {
            return userInFlight;
        }
    }
}