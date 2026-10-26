using Acme.Admin.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Acme.Admin.Web.Pages;

public abstract class AdminPageModel : AbpPageModel
{
    protected AdminPageModel()
    {
        LocalizationResourceType = typeof(AdminResource);
    }
}
