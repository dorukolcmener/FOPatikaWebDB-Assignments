using WebApi.BookOperations.UpdateBook;
using WebApi.DBOperations;

namespace WebApi.BookOperations.UpdateBook;

public class UpdateBookCommand
{
    public int bookId { get; set; }
    public UpdateBookModel model { get; set; }
    private readonly IBookStoreDbContext _context;

    public UpdateBookCommand(IBookStoreDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var book = _context.Books.SingleOrDefault(b => b.Id == bookId);
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
        public string Title { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
        public int GenreId { get; set; }
        public int AuthorId { get; set; }
    }
}