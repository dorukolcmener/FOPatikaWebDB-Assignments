using FluentValidation;

namespace WebApi.AuthorOperations.Commands.UpdateAuthor;

public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
{
    public UpdateAuthorCommandValidator()
    {
        RuleFor(command => command.AuthorId).GreaterThan(0);
        RuleFor(command => command.model.Name).MinimumLength(4).When(command => !string.IsNullOrEmpty(command.model.Name));
    }
}