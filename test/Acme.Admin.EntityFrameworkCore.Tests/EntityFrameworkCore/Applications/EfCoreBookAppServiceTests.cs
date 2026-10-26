using Acme.Admin.Books;
using Xunit;

namespace Acme.Admin.EntityFrameworkCore.Applications;

[Collection(AdminTestConsts.CollectionDefinitionName)]
public class EfCoreBookAppServiceTests : BookAppServiceTests<AdminEntityFrameworkCoreTestModule>
{

}