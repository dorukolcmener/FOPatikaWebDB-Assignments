using AutoMapper;
using FluentAssertions;
using TestSetup;
using Webapi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.AuthorOperations.Queries.GetAuthorDetail;
using WebApi.DBOperations;

namespace Application.AuthorOperations.Queries;

public class GetAuthorDetailQueryTests : IClassFixture<CommonTestFixture>
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;
    public GetAuthorDetailQueryTests(CommonTestFixture testFixture)
    {
        _context = testFixture.Context;
        _mapper = testFixture.Mapper;
    }

    [Fact]
    public void WhenGivenAuthorIdIsNotFound_InvalidOperationException_ShouldBeReturn()
    {
        GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context, _mapper);
        query.AuthorId = 999;
        FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Author not found");
    }

    [Fact]
    public void WhenGivenAuthorIdIsFound_Author_ShouldBeReturn()
    {
        GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context, _mapper);
        query.AuthorId = 1;
        FluentActions.Invoking(() => query.Handle()).Should().NotThrow();
    }
}