using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        private readonly IBookStoreDbContext _context;
        public CreateGenreModel Model { get; set; }
        public CreateGenreCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Name.ToLower() == Model.Name.ToLower());
            if (genre is not null)
                throw new InvalidOperationException("Book genre already exists.");
            genre = new Genre();
            genre.Name = Model.Name.Trim();
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }
    }

    public class CreateGenreModel
    {
        public string Name { get; set; }
    }
}