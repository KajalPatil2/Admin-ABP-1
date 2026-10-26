using Acme.Admin.Samples;
using Xunit;

namespace Acme.Admin.EntityFrameworkCore.Applications;

[Collection(AdminTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<AdminEntityFrameworkCoreTestModule>
{

}
