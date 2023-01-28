using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;
using WebApi.DBOperations;

namespace Application.GenreOperations.Commands.UpdateGenre;

public class UpdateGenreCommandTests : IClassFixture<CommonTestFixture>
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;

    public UpdateGenreCommandTests(CommonTestFixture testFixture)
    {
        _context = testFixture.Context;
        _mapper = testFixture.Mapper;
    }

    [Fact]
    public void WhenGenreNotFound_InvalidOperationException_ShouldBeReturn()
    {
        UpdateGenreCommand command = new UpdateGenreCommand(_context);
        command.GenreId = 999;
        command.Model = new UpdateGenreModel() { Name = "Updated Genre" };

        FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Genre not found.");
    }

    [Fact]
    public void WhenGenreNameExists_InvalidOperationException_ShouldBeReturn()
    {
        // Arrange
        _context.Genres.Add(new WebApi.Entities.Genre() { Name = "UpdateGenreCommandTests_Genre" });
        _context.SaveChanges();

        UpdateGenreCommand command = new UpdateGenreCommand(_context);
        command.GenreId = _context.Genres.SingleOrDefault(genre => genre.Name == "UpdateGenreCommandTests_Genre").Id;
        command.Model = new UpdateGenreModel() { Name = "UpdateGenreCommandTests_Genre" };

        // Act & Assert
        FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Genre already exists.");
    }

    [Fact]
    public void WhenValidInputsAreGiven_Genre_ShouldBeUpdated()
    {
        // Arrange
        _context.Genres.Add(new WebApi.Entities.Genre() { Name = "UpdateGenreCommandTestsXCV_Genre" });
        _context.SaveChanges();

        UpdateGenreCommand command = new UpdateGenreCommand(_context);
        command.GenreId = _context.Genres.SingleOrDefault(genre => genre.Name == "UpdateGenreCommandTestsXCV_Genre").Id;
        command.Model = new UpdateGenreModel() { Name = "Updated Genre" };

        // Act
        FluentActions.Invoking(() => command.Handle()).Should().NotThrow();

        // Assert
        var genre = _context.Genres.SingleOrDefault(genre => genre.Id == command.GenreId);
        genre.Name.Should().Be(command.Model.Name);
    }
}