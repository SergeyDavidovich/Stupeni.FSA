using Volo.Abp.Modularity;

namespace Stupeni.FSA;

[DependsOn(
    typeof(FSAApplicationModule),
    typeof(FSADomainTestModule)
)]
public class FSAApplicationTestModule : AbpModule
{

}
