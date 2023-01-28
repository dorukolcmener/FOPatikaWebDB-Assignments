using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.BookOperations.CreateBook;
using WebApi.DBOperations;
using WebApi.Entities;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;

namespace Application.BookOperations.Commands.CreateBook;

public class CreateBookCommandTests : IClassFixture<CommonTestFixture>
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;
    public CreateBookCommandTests(CommonTestFixture testFixture)
    {
        _context = testFixture.Context;
        _mapper = testFixture.Mapper;
    }

    [Fact]
    public void WhenAlreadyExistsBookTitleIsGiven_InvalidOperationException_ShouldBeReturn()
    {
        // arrange
        var book = new Book()
        {
            Title = "Test_The Hobbit",
            PageCount = 295,
            PublishDate = new DateTime(1937, 9, 21),
            GenreId = 1,
            AuthorId = 1
        };
        _context.Books.Add(book);
        _context.SaveChanges();
        CreateBookCommand command = new CreateBookCommand(_context, _mapper);
        command.model = new CreateBookModel()
        {
            Title = "Test_The Hobbit",
            PageCount = 295,
            PublishDate = new DateTime(1937, 9, 21),
            GenreId = 1,
            AuthorId = 1
        };

        // act & assert
        FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Book already exists");
    }

    [Fact]
    public void WhenValidInputsAreGiven_Book_ShouldBeCreated()
    {
        // arrange
        CreateBookCommand command = new CreateBookCommand(_context, _mapper);
        command.model = new CreateBookModel()
        {
            Title = "CreateBookTestBook_The Hobbit",
            PageCount = 295,
            PublishDate = new DateTime(1937, 9, 21),
            GenreId = 1,
            AuthorId = 1
        };

        // act
        FluentActions.Invoking(() => command.Handle()).Invoke();

        // assert
        var book = _context.Books.SingleOrDefault(book => book.Title == command.model.Title);
        book.Should().NotBeNull();
        book.PageCount.Should().Be(command.model.PageCount);
        book.PublishDate.Should().Be(command.model.PublishDate.Date);
        book.GenreId.Should().Be(command.model.GenreId);
        book.AuthorId.Should().Be(command.model.AuthorId);
    }
}