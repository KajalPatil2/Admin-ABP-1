using System;
using System.Threading.Tasks;
using Acme.Admin.Permissions;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.Admin.Books;

public class BookAppService :
    CrudAppService<Book, BookDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateBookDto>,
    IBookAppService
{
    public BookAppService(IRepository<Book, Guid> repository) : base(repository)
    {
        GetPolicyName = AdminPermissions.Books.Default;
        GetListPolicyName = AdminPermissions.Books.Default;
        CreatePolicyName = AdminPermissions.Books.Create;
        UpdatePolicyName = AdminPermissions.Books.Edit;
        DeletePolicyName = AdminPermissions.Books.Delete;
    }

    public override async Task<BookDto> CreateAsync(CreateUpdateBookDto input)
    {
        await CheckCreatePolicyAsync();
        CheckPrice(input.Price);

        var book = new Book(GuidGenerator.Create(), input.Name, input.Price, input.PublishDate);
        await Repository.InsertAsync(book, autoSave: true);

        return await MapToGetOutputDtoAsync(book);
    }

    public override async Task<BookDto> UpdateAsync(Guid id, CreateUpdateBookDto input)
    {
        await CheckUpdatePolicyAsync();
        CheckPrice(input.Price);

        var book = await Repository.GetAsync(id);
        book.Name = input.Name;
        book.Price = input.Price;
        book.PublishDate = input.PublishDate;
        await Repository.UpdateAsync(book, autoSave: true);

        return await MapToGetOutputDtoAsync(book);
    }

    private static void CheckPrice(decimal price)
    {
        if (price < 0)
        {
            throw new BusinessException("Admin:NegativePrice")
                .WithData("Price", price);
        }
    }
}