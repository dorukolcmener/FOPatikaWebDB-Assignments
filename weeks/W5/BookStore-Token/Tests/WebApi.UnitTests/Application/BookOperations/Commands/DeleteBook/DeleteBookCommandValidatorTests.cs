using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.DeleteBook;
using WebApi.DBOperations;
using WebApi.Entities;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;

namespace Application.BookOperations.Commands.DeleteBook;

public class DeleteBookCommandValidatorTests : IClassFixture<CommonTestFixture>
{
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-100)]
    public void WhenInvalidBookIdIsGiven_Validator_ShouldBeReturnErrors(int BookId)
    {
        // arrange
        DeleteBookCommand command = new DeleteBookCommand(null);
        command.BookId = BookId;

        // act
        DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
        var result = validator.Validate(command);

        // assert
        result.Errors.Count.Should().BeGreaterThan(0);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void WhenValidBookIdIsGiven_Validator_ShouldNotBeReturnErrors(int BookId)
    {
        // arrange
        DeleteBookCommand command = new DeleteBookCommand(null);
        command.BookId = BookId;

        // act
        DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
        var result = validator.Validate(command);

        // assert
        result.Errors.Count.Should().Be(0);
    }
}