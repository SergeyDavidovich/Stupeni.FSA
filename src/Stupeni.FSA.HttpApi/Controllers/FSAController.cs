using Stupeni.FSA.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Stupeni.FSA.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class FSAController : AbpControllerBase
{
    protected FSAController()
    {
        LocalizationResource = typeof(FSAResource);
    }
}
