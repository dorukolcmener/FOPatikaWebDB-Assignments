using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Commands.DeleteGenre;
using WebApi.AuthorOperations.Commands.DeleteAuthor;
using WebApi.DBOperations;
using WebApi.Entities;

namespace Application.AuthorOperations.Commands.DeleteAuthor;

public class DeleteAuthorCommandTests : IClassFixture<CommonTestFixture>
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;

    public DeleteAuthorCommandTests(CommonTestFixture testFixture)
    {
        _context = testFixture.Context;
        _mapper = testFixture.Mapper;
    }

    [Fact]
    public void WhenGivenAuthorIdIsNotFound_InvalidOperationException_ShouldBeReturn()
    {
        DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
        command.AuthorId = 999;
        FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Author not found");
    }

    [Fact]
    public void WhenGivenAuthorHasBooks_InvalidOperationException_ShouldBeReturn()
    {
        DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
        command.AuthorId = 1;
        FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void WhenGivenAuthorIdIsFound_Author_ShouldBeReturn()
    {
        _context.Authors.Add(new Author { Name = "Author 1", Surname = "Surname 1", BirthDate = DateTime.Now.Date.AddYears(-50) });
        _context.SaveChanges();
        DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
        command.AuthorId = _context.Authors.Last().Id;
        FluentActions.Invoking(() => command.Handle()).Should().NotThrow();
    }
}