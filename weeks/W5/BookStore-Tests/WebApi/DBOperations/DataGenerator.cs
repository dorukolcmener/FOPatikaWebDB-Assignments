using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations;

public class DataGenerator
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
        {
            if (context.Books.Any())
            {
                return;
            }

            context.Genres.AddRange(
                new Genre { Name = "Fantasy" },
                new Genre { Name = "Science Fiction" },
                new Genre { Name = "Horror" }
            );

            context.Books.AddRange(
                new Book
                {
                    Title = "The Hobbit",
                    GenreId = 1,
                    AuthorId = 1,
                    PageCount = 295,
                    PublishDate = new DateTime(1937, 9, 21)
                },
                new Book
                {
                    Title = "A Game of Thrones",
                    GenreId = 1,
                    AuthorId = 2,
                    PageCount = 694,
                    PublishDate = new DateTime(1996, 8, 1)
                },
                new Book
                {
                    Title = "War of the Worlds",
                    GenreId = 2,
                    AuthorId = 3,
                    PageCount = 128,
                    PublishDate = new DateTime(1898, 10, 2)
                }
            );

            context.Authors.AddRange(
                new Author
                {
                    Name = "J.R.R.",
                    Surname = "Tolkien",
                    BirthDate = new DateTime(1892, 1, 3)
                },
                new Author
                {
                    Name = "George R.R.",
                    Surname = "Martin",
                    BirthDate = new DateTime(1948, 9, 20)
                },
                new Author
                {
                    Name = "H.G.",
                    Surname = "Wells",
                    BirthDate = new DateTime(1866, 9, 21)
                }
            );

            context.SaveChanges();
        }
    }
}