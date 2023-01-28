using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Commands.DeleteGenre;

public class DeleteGenreCommand
{
    private readonly IBookStoreDbContext _context;
    public int GenreId { get; set; }
    public DeleteGenreCommand(IBookStoreDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);
        if (genre is null)
            throw new InvalidOperationException("Genre not found.");
        _context.Genres.Remove(genre);
        _context.SaveChanges();
    }
}