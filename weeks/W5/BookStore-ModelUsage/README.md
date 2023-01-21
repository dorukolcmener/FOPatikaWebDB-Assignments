### [⬅️ Go Back](../../README.md)

# .NET Model Usage Assignment

Assignment Link: [Patika.Dev .NET Model Usage Assignment](https://app.patika.dev/courses/net-core/4-odev-model-kullanimi)

## ❓Question :

Implement GetById and UpdateBook operations.

## ✏️Answer :

GetByIdQuery

```c#
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetByQuery;

public class GetByIdQuery
{
    private readonly BookStoreDbContext _context;

    public GetByIdQuery(BookStoreDbContext context)
    {
        _context = context;
    }

    public BookViewModel Handle(int id)
    {
        var book = _context.Books.Where(b => b.Id == id).SingleOrDefault();
        if (book is null)
        {
            throw new InvalidOperationException("Book not found");
        }

        BookViewModel bookViewModel = new BookViewModel();
        bookViewModel.Title = book.Title;
        bookViewModel.PageCount = book.PageCount;
        bookViewModel.PublishDate = book.PublishDate.ToString("dd/MM/yyyy");
        bookViewModel.Genre = ((GenreEnum)book.GenreId).ToString();

        return bookViewModel;
    }

    public class BookViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}
```

UpdateBookQuery

```c#
using WebApi.BookOperations.UpdateBook;
using WebApi.DBOperations;

namespace WebApi.BookOperations.UpdateBook;

public class UpdateBookQuery
{
    public UpdateBookModel model { get; set; }
    private readonly BookStoreDbContext _context;

    public UpdateBookQuery(BookStoreDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var book = _context.Books.SingleOrDefault(b => b.Id == model.Id);
        if (book is null)
        {
            throw new InvalidOperationException("Book not found");
        }

        book.Title = model.Title != default ? model.Title : book.Title;
        book.PageCount = model.PageCount != default ? model.PageCount : book.PageCount;
        book.PublishDate = model.PublishDate != default ? model.PublishDate : book.PublishDate;
        book.GenreId = model.GenreId != default ? model.GenreId : book.GenreId;

        _context.SaveChanges();
    }

    public class UpdateBookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
        public int GenreId { get; set; }
    }
}
```

Enjoy 🚀 - Doruk

## My patika.dev profile:

<a href="https://app.patika.dev/kaolin"><img src="./../../../assets/newPatikaLogo.svg" width=200/></a>
