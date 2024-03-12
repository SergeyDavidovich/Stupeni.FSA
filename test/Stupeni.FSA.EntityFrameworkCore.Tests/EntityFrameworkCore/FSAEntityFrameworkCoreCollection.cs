using Xunit;

namespace Stupeni.FSA.EntityFrameworkCore;

[CollectionDefinition(FSATestConsts.CollectionDefinitionName)]
public class FSAEntityFrameworkCoreCollection : ICollectionFixture<FSAEntityFrameworkCoreFixture>
{

}
