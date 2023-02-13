using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;

namespace Application.GenreOperations.Commands.UpdateGenre;

public class UpdateGenreValidatorTests : IClassFixture<CommonTestFixture>
{
    [Theory]
    [InlineData("Genre1")]
    [InlineData("Genre2")]
    [InlineData("Genre3")]
    public void WhenValidInputsAreGiven_Validator_ShouldNotReturnError(string name)
    {
        UpdateGenreCommand command = new UpdateGenreCommand(null);
        UpdateGenreModel model = new UpdateGenreModel() { Name = name };
        command.Model = model;
        command.GenreId = 1;
        UpdateGenreValidator validator = new UpdateGenreValidator();
        var result = validator.Validate(command);
        result.Errors.Count.Should().Be(0);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void WhenInvalidInputsAreGiven_Validator_ShouldReturnError(string name)
    {
        UpdateGenreCommand command = new UpdateGenreCommand(null);
        UpdateGenreModel model = new UpdateGenreModel() { Name = name };
        command.Model = model;
        UpdateGenreValidator validator = new UpdateGenreValidator();
        var result = validator.Validate(command);
        result.Errors.Count.Should().BeGreaterThan(0);
    }
}