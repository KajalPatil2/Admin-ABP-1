using System;
using System.Threading.Tasks;
using Acme.Admin.Newspapers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Acme.Admin.Web.Pages.Newspapers;

public class EditModalModel : AdminPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public CreateUpdateNewspaperDto Newspaper { get; set; } = new();

    private readonly INewspaperAppService _newspaperAppService;

    public EditModalModel(INewspaperAppService newspaperAppService)
    {
        _newspaperAppService = newspaperAppService;
    }

    public async Task OnGetAsync()
    {
        var dto = await _newspaperAppService.GetAsync(Id);
        Newspaper = new CreateUpdateNewspaperDto
        {
            Name = dto.Name,
            Code = dto.Code,
            IsActive = dto.IsActive
        };
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _newspaperAppService.UpdateAsync(Id, Newspaper);
        return NoContent();
    }
}