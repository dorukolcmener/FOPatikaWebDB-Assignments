using AutoMapper;
using FluentAssertions;
using TestSetup;
using Webapi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.DBOperations;

namespace Application.GenreOperations.Queries;

public class GetGenreDetailQueryTests : IClassFixture<CommonTestFixture>
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;
    public GetGenreDetailQueryTests(CommonTestFixture testFixture)
    {
        _context = testFixture.Context;
        _mapper = testFixture.Mapper;
    }

    [Fact]
    public void WhenGivenGenreIdIsNotFound_InvalidOperationException_ShouldBeReturn()
    {
        GetGenreDetailQuery query = new GetGenreDetailQuery(_context, _mapper);
        query.GenreId = 999;
        FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Book genre could not be found.");
    }

    [Fact]
    public void WhenGivenGenreIdIsFound_Genre_ShouldBeReturn()
    {
        GetGenreDetailQuery query = new GetGenreDetailQuery(_context, _mapper);
        query.GenreId = 1;
        FluentActions.Invoking(() => query.Handle()).Should().NotThrow();
    }
}