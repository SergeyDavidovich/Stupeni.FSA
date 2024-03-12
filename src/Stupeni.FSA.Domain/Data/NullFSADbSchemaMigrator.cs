using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Stupeni.FSA.Data;

/* This is used if database provider does't define
 * IFSADbSchemaMigrator implementation.
 */
public class NullFSADbSchemaMigrator : IFSADbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
