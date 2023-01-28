using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;
using WebApi.AuthorOperations.Commands.UpdateAuthor;
using static WebApi.AuthorOperations.Commands.UpdateAuthor.UpdateAuthorCommand;

namespace Application.AuthorOperations.Commands.UpdateAuthor;

public class UpdateAuthorValidatorTests : IClassFixture<CommonTestFixture>
{
    [Theory]
    [InlineData("Author1")]
    [InlineData("Author2")]
    [InlineData("Author3")]
    public void WhenValidInputsAreGiven_Validator_ShouldNotReturnError(string name)
    {
        UpdateAuthorCommand command = new UpdateAuthorCommand(null);
        UpdateAuthorModel model = new UpdateAuthorModel() { Name = name };
        command.model = model;
        command.AuthorId = 1;
        UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
        var result = validator.Validate(command);
        result.Errors.Count.Should().Be(0);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void WhenInvalidInputsAreGiven_Validator_ShouldReturnError(string name)
    {
        UpdateAuthorCommand command = new UpdateAuthorCommand(null);
        UpdateAuthorModel model = new UpdateAuthorModel() { Name = name };
        command.model = model;
        UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
        var result = validator.Validate(command);
        result.Errors.Count.Should().BeGreaterThan(0);
    }
}