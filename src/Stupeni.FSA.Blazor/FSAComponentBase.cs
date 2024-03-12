using Stupeni.FSA.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Stupeni.FSA.Blazor;

public abstract class FSAComponentBase : AbpComponentBase
{
    protected FSAComponentBase()
    {
        LocalizationResource = typeof(FSAResource);
    }
}
