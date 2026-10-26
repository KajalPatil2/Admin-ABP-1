using Acme.Admin.Samples;
using Xunit;

namespace Acme.Admin.EntityFrameworkCore.Domains;

[Collection(AdminTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<AdminEntityFrameworkCoreTestModule>
{

}
