using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.AuthorOperations.Commands.CreateAuthor;

public class CreateAuthorCommand
{
    public CreateAuthorModel model { get; set; }
    private readonly IBookStoreDbContext _context;
    private readonly IMapper _mapper;

    public CreateAuthorCommand(IBookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Handle()
    {
        var author = _mapper.Map<Author>(model);
        // Check if exists
        if (_context.Authors.SingleOrDefault(author => author.Name == model.Name && author.Surname == model.Surname) != null)
            throw new InvalidOperationException("Author already exists.");
        _context.Authors.Add(author);
        _context.SaveChanges();
    }

    public class CreateAuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }

    }
}