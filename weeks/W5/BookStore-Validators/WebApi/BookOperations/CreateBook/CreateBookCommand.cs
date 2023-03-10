using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.BookOperations.CreateBook;

public class CreateBookCommand
{
    public CreateBookModel model { get; set; }
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;

    public CreateBookCommand(BookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Handle()
    {
        var book = _context.Books.SingleOrDefault(b => b.Title == model.Title);
        if (book != null)
        {
            throw new InvalidOperationException("Book already exists");
        }

        book = _mapper.Map<Book>(model);

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