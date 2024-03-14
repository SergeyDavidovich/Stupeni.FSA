using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Stupeni.FSA.Flights
{
    public interface IFlightrAppService : IApplicationService
    {
        //Task<Flight> SearchAsync(CancellationToken token);
    }
}