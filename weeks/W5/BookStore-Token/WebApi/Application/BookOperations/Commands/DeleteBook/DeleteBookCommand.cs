using WebApi.BookOperations.UpdateBook;
using WebApi.DBOperations;

namespace WebApi.BookOperations.DeleteBook;

public class DeleteBookCommand
{
    public int BookId { get; set; }
    private readonly IBookStoreDbContext _context;

    public DeleteBookCommand(IBookStoreDbContext context)
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