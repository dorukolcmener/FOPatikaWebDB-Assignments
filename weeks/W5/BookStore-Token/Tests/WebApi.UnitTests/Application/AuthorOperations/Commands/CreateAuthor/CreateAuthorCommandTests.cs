using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.AuthorOperations.Commands.CreateAuthor;
using WebApi.DBOperations;
using WebApi.Entities;
using static WebApi.AuthorOperations.Commands.CreateAuthor.CreateAuthorCommand;

namespace Application.AuthorOperations.Commands.CreateAuthor;

public class CreateAuthorCommandTests : IClassFixture<CommonTestFixture>
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;
    public CreateAuthorCommandTests(CommonTestFixture testFixture)
    {
        _context = testFixture.Context;
        _mapper = testFixture.Mapper;
    }

    [Fact]
    public void WhenGivenAuthorInfoIsNotValid_InvalidOperationException_ShouldBeReturn()
    {
        _context.Authors.Add(new Author() { Name = "Author Name", Surname = "Author Surname", BirthDate = DateTime.Now.Date.AddYears(-32) });
        CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
        command.model = new CreateAuthorModel() { Name = "Author Name", Surname = "Author Surname", BirthDate = DateTime.Now.Date.AddYears(-32) };
        FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Author already exists.");
    }

    [Fact]
    public void WhenGivenAuthorInfoIsValid_Author_ShouldBeCreated()
    {
        CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
        command.model = new CreateAuthorModel() { Name = "Author Name", Surname = "Author Surname" };
        FluentActions.Invoking(() => command.Handle()).Should().NotThrow();
        var author = _context.Authors.SingleOrDefault(author => author.Name == command.model.Name && author.Surname == command.model.Surname);
        author.Should().NotBeNull();
    }
}