using WebApi.BookOperations.UpdateBook;
using WebApi.DBOperations;

namespace WebApi.AuthorOperations.Commands.DeleteAuthor;

public class DeleteAuthorCommand
{
    public int AuthorId { get; set; }
    private readonly IBookStoreDbContext _context;

    public DeleteAuthorCommand(IBookStoreDbContext context)
    {
        _context = context;
    }

    // Delete book with handle function
    public void Handle()
    {
        var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
        if (author is null)
        {
            throw new InvalidOperationException("Author not found");
        }
        // If a book has this author, throw
        var book = _context.Books.SingleOrDefault(x => x.AuthorId == AuthorId);
        if (book is not null)
        {
            throw new InvalidOperationException($"Author has a book, you need to delete the book first: {book.Title}");
        }

        _context.Authors.Remove(author);
        _context.SaveChanges();
    }
}