using WebApi.BookOperations.UpdateBook;
using WebApi.DBOperations;

namespace WebApi.AuthorOperations.Commands.UpdateAuthor;

public class UpdateAuthorCommand
{
    public int AuthorId { get; set; }
    public UpdateAuthorModel model { get; set; }
    private readonly IBookStoreDbContext _context;

    public UpdateAuthorCommand(IBookStoreDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
        if (author is null)
        {
            throw new InvalidOperationException("Author not found");
        }

        author.Name = model.Name != default ? model.Name : author.Name;
        author.Surname = model.Surname != default ? model.Surname : author.Surname;
        author.BirthDate = model.BirthDate != default ? model.BirthDate : author.BirthDate;

        _context.SaveChanges();
    }

    public class UpdateAuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}