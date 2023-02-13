using FluentValidation;

namespace Webapi.Application.GenreOperations.Queries.GetGenreDetail;

public class GetGenreDetailValidator : AbstractValidator<GetGenreDetailQuery>
{
    public GetGenreDetailValidator()
    {
        RuleFor(x => x.GenreId).GreaterThan(0);
    }
}