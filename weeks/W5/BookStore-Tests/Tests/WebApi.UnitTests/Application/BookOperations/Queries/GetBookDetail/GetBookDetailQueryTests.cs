using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.BookOperations.GetByQuery;
using WebApi.DBOperations;
using WebApi.Entities;

namespace Application.BookOperations.Queries.GetBookDetail;

public class GetBookDetailQueryTests : IClassFixture<CommonTestFixture>
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;
    public GetBookDetailQueryTests(CommonTestFixture testFixture)
    {
        _context = testFixture.Context;
        _mapper = testFixture.Mapper;
    }

    [Fact]
    public void WhenBookNotFound_InvalidOperationException_ShouldBeReturn()
    {
        // arrange
        GetByIdQuery query = new GetByIdQuery(_context, _mapper);
        query.BookId = 999;

        // act & assert
        FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Book not found");
    }

    [Fact]
    public void WhenValidInputsAreGiven_Book_ShouldBeReturned()
    {
        // arrange
        var mockBook = new Book()
        {
            Title = "DetailQueryTest_The Hobbit",
            PageCount = 295,
            PublishDate = new DateTime(1937, 9, 21),
            GenreId = 1,
            AuthorId = 1
        };
        _context.Books.Add(mockBook);
        _context.SaveChanges();

        var testReadyBook = _context.Books.SingleOrDefault(book => book.Title == mockBook.Title);

        GetByIdQuery query = new GetByIdQuery(_context, _mapper);
        query.BookId = mockBook.Id;

        // act
        FluentActions.Invoking(() => query.Handle()).Invoke();

        // assert
        var book = _context.Books.SingleOrDefault(book => book.Id == testReadyBook.Id);
        book.Should().NotBeNull();
        book.Title.Should().Be(mockBook.Title);
        book.PageCount.Should().Be(mockBook.PageCount);
        book.PublishDate.Should().Be(mockBook.PublishDate);
        book.GenreId.Should().Be(mockBook.GenreId);
        book.AuthorId.Should().Be(mockBook.AuthorId);
    }
}