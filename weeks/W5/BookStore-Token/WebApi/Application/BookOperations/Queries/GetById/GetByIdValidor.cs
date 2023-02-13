using FluentValidation;
using WebApi.BookOperations.GetByQuery;

namespace WebApi.BookOperations.GetById;

public class GetByIdValidator : AbstractValidator<GetByIdQuery>
{
    public GetByIdValidator()
    {
        RuleFor(query => query.BookId).GreaterThan(0);
    }
}