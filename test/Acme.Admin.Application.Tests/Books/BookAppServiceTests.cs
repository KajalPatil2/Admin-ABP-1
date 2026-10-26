using System;
using System.Threading.Tasks;
using Shouldly;
using Volo.Abp;
using Volo.Abp.Modularity;
using Xunit;

namespace Acme.Admin.Books;

public abstract class BookAppServiceTests<TStartupModule> : AdminApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    private readonly IBookAppService _bookAppService;

    protected BookAppServiceTests()
    {
        _bookAppService = GetRequiredService<IBookAppService>();
    }

    [Fact]
    public async Task Should_Reject_Negative_Price()
    {
        //Arrange
        var input = new CreateUpdateBookDto
        {
            Name = "Bad Book",
            Price = -5,
            PublishDate = DateTime.Now
        };

        //Act + Assert
        var exception = await Should.ThrowAsync<BusinessException>(
            async () => await _bookAppService.CreateAsync(input)
        );

        exception.Code.ShouldBe("Admin:NegativePrice");
    }

    [Fact]
    public async Task Should_Create_Book_With_Valid_Price()
    {
        //Arrange
        var input = new CreateUpdateBookDto
        {
            Name = "Good Book",
            Price = 10.5m,
            PublishDate = DateTime.Now
        };

        //Act
        var created = await _bookAppService.CreateAsync(input);

        //Assert
        created.Id.ShouldNotBe(Guid.Empty);
        created.Name.ShouldBe("Good Book");
        created.Price.ShouldBe(10.5m);
    }
}