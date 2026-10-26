using Volo.Abp.Modularity;

namespace Acme.Admin;

[DependsOn(
    typeof(AdminApplicationModule),
    typeof(AdminDomainTestModule)
)]
public class AdminApplicationTestModule : AbpModule
{

}
