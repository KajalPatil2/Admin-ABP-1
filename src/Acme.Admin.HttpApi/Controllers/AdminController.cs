using Acme.Admin.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Acme.Admin.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AdminController : AbpControllerBase
{
    protected AdminController()
    {
        LocalizationResource = typeof(AdminResource);
    }
}
