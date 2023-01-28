using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.AuthorOperations.Commands.CreateAuthor;
using WebApi.DBOperations;
using static WebApi.AuthorOperations.Commands.CreateAuthor.CreateAuthorCommand;

namespace Application.AuthorOperations.Commands.CreateAuthor;

public class CreateAuthorCommandValidatorTests : IClassFixture<CommonTestFixture>
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;

    public CreateAuthorCommandValidatorTests(CommonTestFixture testFixture)
    {
        _context = testFixture.Context;
        _mapper = testFixture.Mapper;
    }

    [Theory]
    [InlineData("x", "y")]
    [InlineData("x", "")]
    [InlineData("", "y")]
    [InlineData("", "")]
    public void WhenGivenAuthorInfoIsNotValid_InvalidOperationException_ShouldBeReturn(string name, string surname)
    {
        CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
        command.model = new CreateAuthorModel() { Name = name, Surname = surname };
        CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
        var result = validator.Validate(command);
        result.Errors.Count.Should().BeGreaterThan(0);
    }

    [Fact]
    public void WhenGivenAuthorInfoIsValid_Author_ShouldBeCreated()
    {
        CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
        command.model = new CreateAuthorModel() { Name = "Author Name", Surname = "Author Surname" };
        CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
        var result = validator.Validate(command);
        result.Errors.Count.Should().Be(0);
    }
}