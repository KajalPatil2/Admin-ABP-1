using System;
using Volo.Abp.Application.Dtos;

namespace Acme.Admin.Newspapers;

public class NewspaperDto : AuditedEntityDto<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}