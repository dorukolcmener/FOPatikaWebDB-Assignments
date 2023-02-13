using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.BookOperations.CreateBook;
using WebApi.DBOperations;
using WebApi.Entities;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;

namespace Application.BookOperations.Commands.CreateBook;

public class CreateBookCommandValidatorTests : IClassFixture<CommonTestFixture>
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
        CreateBookCommand command = new CreateBookCommand(null, null);
        command.model = new CreateBookModel()
        {
            Title = title,
            PageCount = pageCount,
            PublishDate = new DateTime(1937, 9, 21),
            GenreId = genreId,
            AuthorId = authorId
        };

        // act
        CreateBookCommandValidator validator = new CreateBookCommandValidator();
        var result = validator.Validate(command);

        // assert
        result.Errors.Count.Should().BeGreaterThan(0);
    }

    [Fact]
    public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
    {
        // arrange
        CreateBookCommand command = new CreateBookCommand(null, null);
        command.model = new CreateBookModel()
        {
            Title = "Test_The Hobbit",
            PageCount = 295,
            PublishDate = DateTime.Now.Date,
            GenreId = 1,
            AuthorId = 1
        };

        // act
        CreateBookCommandValidator validator = new CreateBookCommandValidator();
        var result = validator.Validate(command);

        // assert
        result.Errors.Count.Should().BeGreaterThan(0);
    }

    [Fact]
    public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
    {
        // arrange
        CreateBookCommand command = new CreateBookCommand(null, null);
        command.model = new CreateBookModel()
        {
            Title = "Test_The Hobbit",
            PageCount = 295,
            PublishDate = DateTime.Now.Date.AddYears(-1),
            GenreId = 1,
            AuthorId = 1
        };

        // act
        CreateBookCommandValidator validator = new CreateBookCommandValidator();
        var result = validator.Validate(command);

        // assert
        result.Errors.Count.Should().Be(0);
    }
}