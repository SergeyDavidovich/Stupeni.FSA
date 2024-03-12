using Volo.Abp.Modularity;

namespace Stupeni.FSA;

/* Inherit from this class for your domain layer tests. */
public abstract class FSADomainTestBase<TStartupModule> : FSATestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
