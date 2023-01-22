using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace Webapi.Application.GenreOperations.Queries.GetGenreDetail;

public class GetGenreDetailQuery
{
    public int GenreId { get; set; }
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;

    public GetGenreDetailQuery(BookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public GenreDetailViewModel Handle()
    {
        var genre = _context.Genres.Where(x => x.IsActive && x.Id == GenreId).SingleOrDefault();
        if (genre is null)
            throw new InvalidOperationException("Book genre could not be found.");
        GenreDetailViewModel vm = _mapper.Map<GenreDetailViewModel>(genre);
        return vm;
    }

    public class GenreDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}