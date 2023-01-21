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