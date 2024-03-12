using Volo.Abp.Modularity;

namespace Stupeni.FSA;

[DependsOn(
    typeof(FSADomainModule),
    typeof(FSATestBaseModule)
)]
public class FSADomainTestModule : AbpModule
{

}
