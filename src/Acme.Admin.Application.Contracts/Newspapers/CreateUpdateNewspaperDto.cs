using System.ComponentModel.DataAnnotations;

namespace Acme.Admin.Newspapers;

public class CreateUpdateNewspaperDto
{
    [Required]
    [StringLength(128)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(16)]
    public string Code { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;
}