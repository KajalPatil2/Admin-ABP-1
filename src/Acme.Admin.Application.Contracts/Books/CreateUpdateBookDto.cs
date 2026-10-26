using System;
using System.ComponentModel.DataAnnotations;

namespace Acme.Admin.Books;

public class CreateUpdateBookDto
{
    [Required]
    [StringLength(128)]
    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public DateTime PublishDate { get; set; }
}