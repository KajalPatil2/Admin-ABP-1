using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.Admin.Newspapers;

public interface INewspaperAppService :
    ICrudAppService<NewspaperDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateNewspaperDto>
{
}