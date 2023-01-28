using WebApi.DBOperations;
using WebApi.Entities;

namespace TestSetup;

public static class Books
{
    public static void AddBooks(this BookStoreDbContext context)
    {
        context.Books.AddRange(
            new Book { Title = "The Hobbit", GenreId = 1, AuthorId = 1, PageCount = 295, PublishDate = new DateTime(1937, 9, 21) },
            new Book { Title = "A Game of Thrones", GenreId = 1, AuthorId = 2, PageCount = 694, PublishDate = new DateTime(1996, 8, 1) },
            new Book { Title = "War of the Worlds", GenreId = 2, AuthorId = 3, PageCount = 128, PublishDate = new DateTime(1898, 10, 2) }
        );
    }
}