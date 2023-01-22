using FluentValidation;
using WebApi.BookOperations.GetByQuery;

namespace WebApi.AuthorOperations.Queries.GetAuthorDetail;

public class GetAuthorDetailQueryValidator : AbstractValidator<GetAuthorDetailQuery>
{
    public GetAuthorDetailQueryValidator()
    {
        RuleFor(command => command.AuthorId).GreaterThan(0);
    }
}