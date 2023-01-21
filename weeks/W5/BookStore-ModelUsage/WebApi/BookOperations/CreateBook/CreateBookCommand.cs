using WebApi.DBOperations;

namespace WebApi.BookOperations.CreateBook;

public class CreateBookCommand
{
    public CreateBookModel model { get; set; }
    private readonly BookStoreDbContext _context;

    public CreateBookCommand(BookStoreDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var book = _context.Books.SingleOrDefault(b => b.Title == model.Title);
        if (book != null)
        {
            throw new InvalidOperationException("Book already exists");
        }

        book = new Book();
        book.Title = model.Title;
        book.PageCount = model.PageCount;
        book.PublishDate = model.PublishDate;
        book.GenreId = model.GenreId;

        _context.Books.Add(book);
        _context.SaveChanges();
    }

    public class CreateBookModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
        public int GenreId { get; set; }
    }
}