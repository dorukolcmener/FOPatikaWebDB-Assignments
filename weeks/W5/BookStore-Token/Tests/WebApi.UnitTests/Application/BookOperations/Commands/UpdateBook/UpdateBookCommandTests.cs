using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.BookOperations.UpdateBook;
using WebApi.DBOperations;
using WebApi.Entities;
using static WebApi.BookOperations.UpdateBook.UpdateBookCommand;

namespace Application.BookOperations.Commands.UpdateBook;

public class UpdateBookCommandTests : IClassFixture<CommonTestFixture>
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;
    public UpdateBookCommandTests(CommonTestFixture testFixture)
    {
        _context = testFixture.Context;
        _mapper = testFixture.Mapper;
    }

    [Fact]
    public void WhenInvalidBookInputsAreGiven_InvalidOperationException_ShouldBeReturn()
    {
        // arrange
        var book = new Book()
        {
            Title = "UpdateBookTest_The Hobbit",
            PageCount = 295,
            PublishDate = new DateTime(1937, 9, 21),
            GenreId = 1,
            AuthorId = 1
        };
        _context.Books.Add(book);
        int bookId = _context.SaveChanges();

        UpdateBookCommand command = new UpdateBookCommand(_context);
        command.bookId = bookId + 1123123;
        command.model = new UpdateBookModel()
        {
            Title = "UpdateBookTest2_The Hobbit",
            PageCount = 0,
            PublishDate = new DateTime(1927, 9, 21),
            GenreId = 2,
            AuthorId = 0
        };

        // act & assert
        FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Book not found");
    }

    [Fact]
    public void WhenValidInputsAreGiven_Book_ShouldBeUpdated()
    {
        // arrange
        var mockBook = new Book()
        {
            Title = "UpdateBookTest_The Hobbit",
            PageCount = 295,
            PublishDate = new DateTime(1937, 9, 21),
            GenreId = 1,
            AuthorId = 1
        };
        _context.Books.Add(mockBook);
        _context.SaveChanges();
        int bookId = _context.Books.SingleOrDefault(book => book.Title == mockBook.Title).Id;

        UpdateBookCommand command = new UpdateBookCommand(_context);
        command.bookId = bookId;
        command.model = new UpdateBookModel()
        {
            Title = "TestValidBook_The Hobbit",
            PageCount = 250,
            PublishDate = new DateTime(1937, 9, 21),
            GenreId = 1,
            AuthorId = 1
        };

        // act
        FluentActions.Invoking(() => command.Handle()).Invoke();

        // assert
        var book = _context.Books.SingleOrDefault(book => book.Title == command.model.Title);
        book.Should().NotBeNull();
        book.Title.Should().Be(command.model.Title);
        book.PageCount.Should().Be(command.model.PageCount);
        book.PublishDate.Should().Be(command.model.PublishDate);
        book.GenreId.Should().Be(command.model.GenreId);
        book.AuthorId.Should().Be(command.model.AuthorId);
    }
}