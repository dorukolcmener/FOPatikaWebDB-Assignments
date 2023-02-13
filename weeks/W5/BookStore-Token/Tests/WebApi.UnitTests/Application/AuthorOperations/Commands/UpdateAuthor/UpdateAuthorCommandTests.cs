using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;
using WebApi.AuthorOperations.Commands.UpdateAuthor;
using WebApi.DBOperations;
using static WebApi.AuthorOperations.Commands.UpdateAuthor.UpdateAuthorCommand;

namespace Application.AuthorOperations.Commands.UpdateAuthor;

public class UpdateAuthorCommandTests : IClassFixture<CommonTestFixture>
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;

    public UpdateAuthorCommandTests(CommonTestFixture testFixture)
    {
        _context = testFixture.Context;
        _mapper = testFixture.Mapper;
    }

    [Fact]
    public void WhenGivenAuthorInfoIsNotFound_InvalidOperationException_ShouldBeReturn()
    {
        UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
        command.AuthorId = 999;
        command.model = new UpdateAuthorModel()
        {
            Name = "Updated Name",
            Surname = "Updated Surname"
        };
        FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Author not found");
    }

    [Fact]
    public void WhenGivenAuthorInfoIsFound_Author_ShouldBeReturn()
    {
        UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
        command.AuthorId = 1;
        command.model = new UpdateAuthorModel()
        {
            Name = "Updated Name",
            Surname = "Updated Surname"
        };
        FluentActions.Invoking(() => command.Handle()).Should().NotThrow();
    }
}