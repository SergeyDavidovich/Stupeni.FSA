using Stupeni.FSA.Samples;
using Xunit;

namespace Stupeni.FSA.EntityFrameworkCore.Domains;

[Collection(FSATestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<FSAEntityFrameworkCoreTestModule>
{

}
