using FluentValidation;

namespace WebApi.BookOperations.UpdateBook;

public class UpdateBookValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookValidator()
    {
        // RuleFor(command => command.model.Id).GreaterThan(0);
        RuleFor(command => command.bookId).GreaterThan(0);
        RuleFor(command => command.model.Title).NotEmpty().MinimumLength(4);
        RuleFor(command => command.model.PageCount).GreaterThan(0);
        RuleFor(command => command.model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
        RuleFor(command => command.model.GenreId).GreaterThan(0);
    }
}