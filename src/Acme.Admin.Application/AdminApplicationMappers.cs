using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;
using Acme.Admin.Books;
using Acme.Admin.Newspapers;

namespace Acme.Admin;

[Mapper]
public partial class BookToBookDtoMapper : MapperBase<Book, BookDto>
{
    public override partial BookDto Map(Book source);

    public override partial void Map(Book source, BookDto destination);
}

[Mapper]
public partial class NewspaperToNewspaperDtoMapper : MapperBase<Newspaper, NewspaperDto>
{
    public override partial NewspaperDto Map(Newspaper source);

    public override partial void Map(Newspaper source, NewspaperDto destination);
}