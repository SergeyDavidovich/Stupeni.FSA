using Stupeni.FSA.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Stupeni.FSA;

public class FSATestDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Booking, Guid> _bookingRepository;

    public FSATestDataSeedContributor(IRepository<Booking, Guid> bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
    }
}
