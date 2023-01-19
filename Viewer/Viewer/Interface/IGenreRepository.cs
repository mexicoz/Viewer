using Viewer.Models;

namespace Viewer.Interface
{
    public interface IGenreRepository
    {
        ICollection<Genre> GetGenres();
        ICollection<Book> GetBooksByGenre(string name);
        Genre GetGenre(int id);
        bool HasGenre(int genreId);
        bool HasGenre(string name);
    }
}
