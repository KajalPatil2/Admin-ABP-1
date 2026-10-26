using System;
using System.Threading.Tasks;
using Acme.Admin.Permissions;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.Admin.Newspapers;

public class NewspaperAppService :
    CrudAppService<Newspaper, NewspaperDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateNewspaperDto>,
    INewspaperAppService
{
    public NewspaperAppService(IRepository<Newspaper, Guid> repository) : base(repository)
    {
        GetPolicyName = AdminPermissions.Newspapers.Default;
        GetListPolicyName = AdminPermissions.Newspapers.Default;
        CreatePolicyName = AdminPermissions.Newspapers.Create;
        UpdatePolicyName = AdminPermissions.Newspapers.Edit;
        DeletePolicyName = AdminPermissions.Newspapers.Delete;
    }

    public override async Task<NewspaperDto> CreateAsync(CreateUpdateNewspaperDto input)
    {
        await CheckCreatePolicyAsync();

        var code = input.Code.Trim().ToUpperInvariant();
        await EnsureCodeIsUniqueAsync(code, null);

        var newspaper = new Newspaper(GuidGenerator.Create(), input.Name.Trim(), code)
        {
            IsActive = input.IsActive
        };
        await Repository.InsertAsync(newspaper, autoSave: true);

        return await MapToGetOutputDtoAsync(newspaper);
    }

    public override async Task<NewspaperDto> UpdateAsync(Guid id, CreateUpdateNewspaperDto input)
    {
        await CheckUpdatePolicyAsync();

        var code = input.Code.Trim().ToUpperInvariant();
        await EnsureCodeIsUniqueAsync(code, id);

        var newspaper = await Repository.GetAsync(id);
        newspaper.Name = input.Name.Trim();
        newspaper.Code = code;
        newspaper.IsActive = input.IsActive;
        await Repository.UpdateAsync(newspaper, autoSave: true);

        return await MapToGetOutputDtoAsync(newspaper);
    }

    private async Task EnsureCodeIsUniqueAsync(string code, Guid? currentId)
    {
        var exists = await Repository.AnyAsync(x => x.Code == code && x.Id != currentId);
        if (exists)
        {
            throw new BusinessException("Admin:DuplicateNewspaperCode").WithData("Code", code);
        }
    }
}