using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Commands.DeleteGenre;
using WebApi.DBOperations;

namespace Application.GenreOperations.Commands.DeleteGenre;

public class DeleteGenreCommandTests : IClassFixture<CommonTestFixture>
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;

    public DeleteGenreCommandTests(CommonTestFixture testFixture)
    {
        _context = testFixture.Context;
        _mapper = testFixture.Mapper;
    }

    [Fact]
    public void WhenGenreNotFound_InvalidOperationException_ShouldBeReturn()
    {
        DeleteGenreCommand command = new DeleteGenreCommand(_context);
        command.GenreId = 999;

        FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Genre not found.");
    }

    [Fact]
    public void WhenValidInputsAreGiven_Genre_ShouldBeDeleted()
    {
        // Arrange
        _context.Genres.Add(new WebApi.Entities.Genre() { Name = "DeleteGenreCommandTests_Genre" });
        _context.SaveChanges();

        DeleteGenreCommand command = new DeleteGenreCommand(_context);
        command.GenreId = _context.Genres.SingleOrDefault(genre => genre.Name == "DeleteGenreCommandTests_Genre").Id;

        // Act
        FluentActions.Invoking(() => command.Handle()).Should().NotThrow();

        // Assert
        var genre = _context.Genres.SingleOrDefault(genre => genre.Id == command.GenreId);
        genre.Should().BeNull();
    }
}