using Xunit;

namespace Acme.Admin.EntityFrameworkCore;

[CollectionDefinition(AdminTestConsts.CollectionDefinitionName)]
public class AdminEntityFrameworkCoreCollection : ICollectionFixture<AdminEntityFrameworkCoreFixture>
{

}
