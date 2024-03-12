using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Stupeni.FSA.Data;
using Volo.Abp.DependencyInjection;

namespace Stupeni.FSA.EntityFrameworkCore;

public class EntityFrameworkCoreFSADbSchemaMigrator
    : IFSADbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreFSADbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the FSADbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<FSADbContext>()
            .Database
            .MigrateAsync();
    }
}
