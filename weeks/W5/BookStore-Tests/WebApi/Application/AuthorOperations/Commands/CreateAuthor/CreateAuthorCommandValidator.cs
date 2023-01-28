using FluentValidation;

namespace WebApi.AuthorOperations.Commands.CreateAuthor;

public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
{
    public CreateAuthorCommandValidator()
    {
        RuleFor(command => command.model.Name).MinimumLength(4);
    }
}