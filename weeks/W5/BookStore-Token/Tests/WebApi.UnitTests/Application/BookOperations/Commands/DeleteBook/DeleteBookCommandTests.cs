using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.DeleteBook;
using WebApi.DBOperations;
using WebApi.Entities;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;

namespace Application.BookOperations.Commands.DeleteBook;

public class DeleteBookCommandTests : IClassFixture<CommonTestFixture>
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;
    public DeleteBookCommandTests(CommonTestFixture testFixture)
    {
        _context = testFixture.Context;
        _mapper = testFixture.Mapper;
    }

    [Fact]
    public void WhenBookNotExists_InvalidOperationException_ShouldBeReturn()
    {
        // arrange
        DeleteBookCommand command = new DeleteBookCommand(_context);
        command.BookId = 0;

        // act & assert
        FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Book not found");
    }

    [Fact]
    public void WhenValidInputsAreGiven_Book_ShouldBeDeleted()
    {
        // arrange
        var book = new Book()
        {
            Title = "DeleteTest_The Hobbit",
            PageCount = 295,
            PublishDate = new DateTime(1937, 9, 21),
            GenreId = 1,
            AuthorId = 1
        };
        _context.Books.Add(book);
        int bookId = _context.SaveChanges();

        DeleteBookCommand command = new DeleteBookCommand(_context);
        command.BookId = bookId;

        // act & assert
        FluentActions.Invoking(() => command.Handle()).Should().NotThrow();
    }
}