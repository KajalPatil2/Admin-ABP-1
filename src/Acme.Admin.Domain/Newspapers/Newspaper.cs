using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.Admin.Newspapers;

public class Newspaper : FullAuditedAggregateRoot<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;

    protected Newspaper()
    {
    }

    public Newspaper(Guid id, string name, string code)
        : base(id)
    {
        Name = name;
        Code = code;
    }
}