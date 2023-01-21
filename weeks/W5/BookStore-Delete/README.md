### [⬅️ Go Back](../../README.md)

# .NET Model Usage Assignment

Assignment Link: [Patika.Dev .NET DELETE Usage Assignment](https://app.patika.dev/courses/net-core/5-odev-cozum-model-kullanımı)

## ❓Question :

Implement GetById and UpdateBook operations.

## ✏️Answer :

DeleteBookQuery

```c#
using WebApi.BookOperations.UpdateBook;
using WebApi.DBOperations;

namespace WebApi.BookOperations.DeleteBook;

public class DeleteBookQuery
{
    public int BookId { get; set; }
    private readonly BookStoreDbContext _context;

    public DeleteBookQuery(BookStoreDbContext context)
    {
        _context = context;
    }

    // Delete book with handle function
    public void Handle()
    {
        var book = _context.Books.SingleOrDefault(b => b.Id == BookId);
        if (book is null)
        {
            throw new InvalidOperationException("Book not found");
        }

        _context.Books.Remove(book);
        _context.SaveChanges();
    }
}
```

Enjoy 🚀 - Doruk

## My patika.dev profile:

<a href="https://app.patika.dev/kaolin"><img src="../../../assets/newPatikaLogo.svg" width=200/></a>
