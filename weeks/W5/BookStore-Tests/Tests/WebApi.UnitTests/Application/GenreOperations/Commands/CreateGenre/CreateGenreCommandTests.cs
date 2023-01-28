using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.DBOperations;
using WebApi.Entities;

namespace Application.GenreOperations.Commands.CreateGenre;

public class CreateGenreCommandTests : IClassFixture<CommonTestFixture>
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;
    public CreateGenreCommandTests(CommonTestFixture testFixture)
    {
        _context = testFixture.Context;
        _mapper = testFixture.Mapper;
    }

    [Fact]
    public void WhenExistingGenreNameIsGiven_InvalidOperationException_ShouldBeReturn()
    {
        _context.Genres.AddRange(new Genre() { Name = "CreateGenreTest_Horror" });
        _context.SaveChanges();

        CreateGenreCommand command = new CreateGenreCommand(_context);
        command.Model = new CreateGenreModel()
        {
            Name = "CreateGenreTest_Horror"
        };
        FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Book genre already exists.");
    }

    [Fact]
    public void WhenValidInputsAreGiven_Genre_ShouldBeCreated()
    {
        CreateGenreCommand command = new CreateGenreCommand(_context);
        command.Model = new CreateGenreModel()
        {
            Name = "CreateGenreTest_Test Genre"
        };

        FluentActions.Invoking(() => command.Handle()).Should().NotThrow();
    }
}