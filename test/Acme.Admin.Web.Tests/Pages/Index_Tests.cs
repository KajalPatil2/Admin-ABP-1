using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Acme.Admin.Pages;

[Collection(AdminTestConsts.CollectionDefinitionName)]
public class Index_Tests : AdminWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
