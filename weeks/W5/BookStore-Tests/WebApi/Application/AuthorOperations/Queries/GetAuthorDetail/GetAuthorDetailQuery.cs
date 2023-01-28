using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.AuthorOperations.Queries.GetAuthorDetail;

public class GetAuthorDetailQuery
{
    private readonly IBookStoreDbContext _context;
    private readonly IMapper _mapper;
    public int AuthorId { get; set; }

    public GetAuthorDetailQuery(IBookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public AuthorViewModel Handle()
    {
        var author = _context.Authors.Where(a => a.Id == AuthorId).SingleOrDefault();
        if (author is null)
        {
            throw new InvalidOperationException("Author not found");
        }

        AuthorViewModel authorViewModel = _mapper.Map<AuthorViewModel>(author);

        return authorViewModel;
    }

    public class AuthorViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}