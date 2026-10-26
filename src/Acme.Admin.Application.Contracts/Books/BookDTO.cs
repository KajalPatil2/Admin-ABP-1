using System;
using Volo.Abp.Application.Dtos;

namespace Acme.Admin.Books;

public class BookDto : AuditedEntityDto<Guid>
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public DateTime PublishDate { get; set; }
}