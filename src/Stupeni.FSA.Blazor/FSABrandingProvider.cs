using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Stupeni.FSA.Blazor;

[Dependency(ReplaceServices = true)]
public class FSABrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "FSA";
}
