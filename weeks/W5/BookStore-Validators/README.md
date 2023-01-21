### [⬅️ Go Back](../../README.md)

# .NET Fluent Validator Assignment

Assignment Link: [Patika.Dev .NET Fluent Validator Assignment](https://app.patika.dev/courses/net-core/2-model-validasyonu-odev)

## ❓Question :

Implement GetById, UpdateBook, Delete validators.

## ✏️Answer :

GetByIdValidator

```c#
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
```

UpdateBookValidator

```c#
using FluentValidation;

namespace WebApi.BookOperations.UpdateBook;

public class UpdateBookValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookValidator()
    {
        RuleFor(command => command.model.Id).GreaterThan(0);
        RuleFor(command => command.model.Title).NotEmpty().MinimumLength(4);
        RuleFor(command => command.model.PageCount).GreaterThan(0);
        RuleFor(command => command.model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
        RuleFor(command => command.model.GenreId).GreaterThan(0);
    }
}
```

DeleteBookCommandValidator

```c#
using FluentValidation;

namespace WebApi.BookOperations.DeleteBook;

public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
{
    public DeleteBookCommandValidator()
    {
        RuleFor(command => command.BookId).GreaterThan(0);
    }
}
```

Enjoy 🚀 - Doruk

## My patika.dev profile:

<a href="https://app.patika.dev/kaolin"><img src="../../../assets/newPatikaLogo.svg" width=200/></a>
