using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.Admin.Books;

public class Book : FullAuditedAggregateRoot<Guid>
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public DateTime PublishDate { get; set; }

    protected Book()
    {
    }

    public Book(Guid id, string name, decimal price, DateTime publishDate)
        : base(id)
    {
        Name = name;
        Price = price;
        PublishDate = publishDate;
    }
}