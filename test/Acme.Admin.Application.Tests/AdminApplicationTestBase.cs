using Volo.Abp.Modularity;

namespace Acme.Admin;

public abstract class AdminApplicationTestBase<TStartupModule> : AdminTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
