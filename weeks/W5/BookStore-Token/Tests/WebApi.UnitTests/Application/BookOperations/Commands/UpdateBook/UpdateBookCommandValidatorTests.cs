using FluentAssertions;
using TestSetup;
using WebApi.BookOperations.UpdateBook;
using static WebApi.BookOperations.UpdateBook.UpdateBookCommand;

namespace Application.BookOperations.Commands.UpdateBook;

public class UpdateBookCommandValidatorTests : IClassFixture<CommonTestFixture>
{
    [Theory]
    [InlineData("Test_The Hobbit", 295, 1, 0)]
    [InlineData("Test_The Hobbit", 0, 1, 1)]
    [InlineData("", 0, 0, 0)]
    [InlineData("", 0, 100, 1)]
    [InlineData("", 0, 0, 1)]
    [InlineData("Lor", 100, 0, 1)]
    [InlineData("Lord", 100, 0, 0)]
    [InlineData("Lord", 0, 0, 0)]
    public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string title, int pageCount, int genreId, int authorId)
    {
        // arrange
        UpdateBookCommand command = new UpdateBookCommand(null);
        command.model = new UpdateBookModel()
        {
            Title = title,
            PageCount = pageCount,
            PublishDate = new DateTime(1937, 9, 21),
            GenreId = genreId,
            AuthorId = authorId
        };

        // act
        UpdateBookValidator validator = new UpdateBookValidator();
        var result = validator.Validate(command);

        // assert
        result.Errors.Count.Should().BeGreaterThan(0);
    }

    [Fact]
    public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
    {
        // arrange
        UpdateBookCommand command = new UpdateBookCommand(null);
        command.model = new UpdateBookModel()
        {
            Title = "Test_The Hobbit",
            PageCount = 295,
            PublishDate = DateTime.Now.Date,
            GenreId = 1,
            AuthorId = 1
        };

        // act
        UpdateBookValidator validator = new UpdateBookValidator();
        var result = validator.Validate(command);

        // assert
        result.Errors.Count.Should().BeGreaterThan(0);
    }
}