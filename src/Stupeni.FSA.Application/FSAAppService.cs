using System;
using System.Collections.Generic;
using System.Text;
using Stupeni.FSA.Localization;
using Volo.Abp.Application.Services;

namespace Stupeni.FSA;

/* Inherit your application services from this class.
 */
public abstract class FSAAppService : ApplicationService
{
    protected FSAAppService()
    {
        LocalizationResource = typeof(FSAResource);
    }
}
