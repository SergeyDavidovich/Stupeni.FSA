using Volo.Abp.Modularity;

namespace Stupeni.FSA;

public abstract class FSAApplicationTestBase<TStartupModule> : FSATestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
