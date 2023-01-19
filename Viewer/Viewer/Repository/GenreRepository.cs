using Microsoft.EntityFrameworkCore;
using Viewer.Data;
using Viewer.Interface;
using Viewer.Models;

namespace Viewer.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly DataContext _context;

        public GenreRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Book> GetBooksByGenre(string name)
        {
            return _context.Books.Where(b => b.Genre.Name== name).ToList(); 
        }

        public Genre GetGenre(int id)
        {
            return _context.Genres.Where(g => g.Id == id).FirstOrDefault();
        }

        public ICollection<Genre> GetGenres()
        {
            return _context.Genres.GroupBy(x => x.Name).Select(g => g.First()).ToList();
        }
        public bool HasGenre(int genreId)
        {
            return _context.Genres.Any(g => g.Id == genreId);
        }
        public bool HasGenre(string name)
        {
            return _context.Genres.Any(g => g.Name == name);
        }
    }
}
