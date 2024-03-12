using Stupeni.FSA.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Stupeni.FSA.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(FSAEntityFrameworkCoreModule),
    typeof(FSAApplicationContractsModule)
    )]
public class FSADbMigratorModule : AbpModule
{
}
