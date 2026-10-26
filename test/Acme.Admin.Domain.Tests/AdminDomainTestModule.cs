using Volo.Abp.Modularity;

namespace Acme.Admin;

[DependsOn(
    typeof(AdminDomainModule),
    typeof(AdminTestBaseModule)
)]
public class AdminDomainTestModule : AbpModule
{

}
