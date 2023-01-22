using FluentValidation;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenre;

public class UpdateGenreValidator : AbstractValidator<UpdateGenreCommand>
{
    public UpdateGenreValidator()
    {
        RuleFor(command => command.GenreId).GreaterThan(0);
        // Rule for model name min 4 chars only if name is not null or 0 chars
        RuleFor(command => command.Model.Name).MinimumLength(4).When(command => !string.IsNullOrEmpty(command.Model.Name));
    }
}