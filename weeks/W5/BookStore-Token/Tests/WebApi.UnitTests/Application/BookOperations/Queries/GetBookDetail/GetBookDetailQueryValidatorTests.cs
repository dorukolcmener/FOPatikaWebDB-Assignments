using FluentAssertions;
using TestSetup;
using WebApi.BookOperations.GetById;
using WebApi.BookOperations.GetByQuery;

namespace Application.BookOperations.Queries.GetBookDetail;

public class GetBookDetailQueryValidatorTests : IClassFixture<CommonTestFixture>
{
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-100)]
    public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturn(int bookId)
    {
        // arrange
        GetByIdQuery query = new GetByIdQuery(null, null);
        query.BookId = bookId;

        // act
        GetByIdValidator validator = new GetByIdValidator();
        var result = validator.Validate(query);

        // assert
        result.Errors.Count.Should().BeGreaterThan(0);
    }

    [Fact]
    public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturn()
    {
        // arrange
        GetByIdQuery query = new GetByIdQuery(null, null);
        query.BookId = 1;

        // act
        GetByIdValidator validator = new GetByIdValidator();
        var result = validator.Validate(query);

        // assert
        result.Errors.Count.Should().Be(0);
    }
}