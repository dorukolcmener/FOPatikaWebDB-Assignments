using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Commands.DeleteGenre;
using WebApi.DBOperations;

namespace Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public DeleteGenreCommandValidatorTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public void WhenGenreNotFound_InvalidOperationException_ShouldBeReturn(int GenreId)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.GenreId = GenreId;
            DeleteGenreValidator validator = new DeleteGenreValidator();

            validator.Validate(command).Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Genre_ShouldBeDeleted()
        {
            // Arrange
            _context.Genres.Add(new WebApi.Entities.Genre() { Name = "DeleteGenreCommandTestsValidator_Genre" });
            _context.SaveChanges();

            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.GenreId = _context.Genres.SingleOrDefault(genre => genre.Name == "DeleteGenreCommandTestsValidator_Genre").Id;
            DeleteGenreValidator validator = new DeleteGenreValidator();

            // Act & Assert
            validator.Validate(command).Errors.Count.Should().Be(0);
        }
    }
}