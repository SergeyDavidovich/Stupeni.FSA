using Stupeni.FSA.Samples;
using Xunit;

namespace Stupeni.FSA.EntityFrameworkCore.Applications;

[Collection(FSATestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<FSAEntityFrameworkCoreTestModule>
{

}
