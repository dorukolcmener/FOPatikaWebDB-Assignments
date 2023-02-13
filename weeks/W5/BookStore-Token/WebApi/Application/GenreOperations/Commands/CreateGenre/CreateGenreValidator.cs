using FluentValidation;

namespace WebApi.Application.GenreOperations.Commands.CreateGenre;

public class CreateGenreValidator : AbstractValidator<CreateGenreCommand>
{
    public CreateGenreValidator()
    {
        RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4);
    }
}