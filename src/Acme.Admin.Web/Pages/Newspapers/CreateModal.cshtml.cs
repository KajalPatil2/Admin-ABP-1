using System.Threading.Tasks;
using Acme.Admin.Newspapers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Acme.Admin.Web.Pages.Newspapers;

public class CreateModalModel : AdminPageModel
{
    [BindProperty]
    public CreateUpdateNewspaperDto Newspaper { get; set; } = new() { IsActive = true };

    private readonly INewspaperAppService _newspaperAppService;

    public CreateModalModel(INewspaperAppService newspaperAppService)
    {
        _newspaperAppService = newspaperAppService;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _newspaperAppService.CreateAsync(Newspaper);
        return NoContent();
    }
}