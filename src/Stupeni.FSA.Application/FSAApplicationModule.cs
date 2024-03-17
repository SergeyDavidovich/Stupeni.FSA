using Microsoft.Extensions.DependencyInjection;
using Stupeni.FSA.DataSource;
using Stupeni.FSA.Flights.DataSource;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.Caching;

namespace Stupeni.FSA;

[DependsOn(
    typeof(FSADomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(FSAApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
[DependsOn(typeof(AbpCachingModule))]
    public class FSAApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<FSAApplicationModule>();
        });

        context.Services.AddSingleton<ICISFlightsSource, CisFlightsDataSource>();
        context.Services.AddSingleton<IWorldwideFlightsSource, WorldwideFlightsDataSource>();
    }
}
