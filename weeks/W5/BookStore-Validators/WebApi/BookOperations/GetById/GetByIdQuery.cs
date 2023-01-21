using AutoMapper;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetByQuery;

public class GetByIdQuery
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;
    public int BookId { get; set; }

    public GetByIdQuery(BookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public BookViewModel Handle()
    {
        var book = _context.Books.Where(b => b.Id == BookId).SingleOrDefault();
        if (book is null)
        {
            throw new InvalidOperationException("Book not found");
        }

        BookViewModel bookViewModel = _mapper.Map<BookViewModel>(book);

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