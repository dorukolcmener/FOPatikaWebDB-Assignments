using WebApi.DBOperations;
using WebApi.Entities;

namespace TestSetup;

public static class Authors
{
    public static void AddAuthors(this BookStoreDbContext context)
    {
        context.Authors.AddRange(
            new Author { Name = "J.R.R.", Surname = "Tolkien", BirthDate = new DateTime(1892, 1, 3) },
            new Author { Name = "George R.R.", Surname = "Martin", BirthDate = new DateTime(1948, 9, 20) },
            new Author { Name = "H.G.", Surname = "Wells", BirthDate = new DateTime(1866, 9, 21) }
        );
    }
}