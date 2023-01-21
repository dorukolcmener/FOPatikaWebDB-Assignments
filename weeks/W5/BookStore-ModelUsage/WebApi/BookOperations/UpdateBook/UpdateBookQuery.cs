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