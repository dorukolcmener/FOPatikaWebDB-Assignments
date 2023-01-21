using System.Collections.Generic;
using System.Linq;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBooks;

public class GetBooksQuery
{
    private readonly BookStoreDbContext _context;

    public GetBooksQuery(BookStoreDbContext context)
    {
        _context = context;
    }

    public List<BooksViewModel> Handle()
    {
        var bookList = _context.Books.OrderBy(b => b.Id).ToList<Book>();
        List<BooksViewModel> bookViewModelList = new List<BooksViewModel>();
        foreach (var book in bookList)
        {
            bookViewModelList.Add(new BooksViewModel
            {
                Title = book.Title,
                PageCount = book.PageCount,
                PublishDate = book.PublishDate.ToString("dd/MM/yyyy"),
                Genre = ((GenreEnum)book.GenreId).ToString()
            });
        }
        return bookViewModelList;
    }

    public class BooksViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}