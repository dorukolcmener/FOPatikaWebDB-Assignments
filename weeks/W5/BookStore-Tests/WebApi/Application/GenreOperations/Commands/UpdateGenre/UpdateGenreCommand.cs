using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenre;

public class UpdateGenreCommand
{
    private readonly IBookStoreDbContext _context;
    public UpdateGenreModel Model { get; set; }
    public int GenreId { get; set; }
    public UpdateGenreCommand(IBookStoreDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);
        if (genre is null)
            throw new InvalidOperationException("Genre not found.");

        if (_context.Genres.Any(x => x.Name.ToLower() == Model.Name.ToLower()))
            throw new InvalidOperationException("Genre already exists.");
        // if (_context.Genres.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Id != GenreId))
        //     throw new InvalidOperationException("Genre already exists.");

        // genre.Name = Model.Name.Trim() != default ? Model.Name : genre.Name;
        genre.Name = string.IsNullOrEmpty(Model.Name.Trim()) ? genre.Name : Model.Name;
        genre.IsActive = Model.IsActive;
        _context.SaveChanges();
    }
}

public class UpdateGenreModel
{
    public string Name { get; set; }
    public bool IsActive { get; set; } = true;
}