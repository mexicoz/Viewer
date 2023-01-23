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

        public bool CreateGenre(Genre genre)
        {
            _context.Add(genre);
            return Save();
        }

        public ICollection<Book> GetBooksByGenre(int genreId)
        {
            return _context.Books.Where(b => b.Genre.Id == genreId).ToList(); 
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

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
