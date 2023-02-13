using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.DBOperations;

namespace Application.GenreOperations.Commands.CreateGenre;

public class CreateGenreCommandValidatorTests : IClassFixture<CommonTestFixture>
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;

    public CreateGenreCommandValidatorTests(CommonTestFixture testFixture)
    {
        _context = testFixture.Context;
        _mapper = testFixture.Mapper;
    }

    [Theory]
    [InlineData("CreateGenreTest_Test Genre")]
    [InlineData("CreateGenreTest_Test Genre 2")]
    public void WhenValidInputsAreGiven_Validator_ShouldNotReturnError(string name)
    {
        CreateGenreCommand command = new CreateGenreCommand(_context);
        command.Model = new CreateGenreModel()
        {
            Name = name
        };

        CreateGenreValidator validator = new CreateGenreValidator();
        var result = validator.Validate(command);
        result.Errors.Count.Should().Be(0);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("qw")]
    public void WhenInvalidInputsAreGiven_Validator_ShouldReturnError(string name)
    {
        CreateGenreCommand command = new CreateGenreCommand(_context);
        command.Model = new CreateGenreModel()
        {
            Name = name
        };

        CreateGenreValidator validator = new CreateGenreValidator();
        var result = validator.Validate(command);
        result.Errors.Count.Should().BeGreaterThan(0);
    }
}