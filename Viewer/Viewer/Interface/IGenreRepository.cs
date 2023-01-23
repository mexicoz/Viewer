using Viewer.Models;

namespace Viewer.Interface
{
    public interface IGenreRepository
    {
        ICollection<Genre> GetGenres();
        ICollection<Book> GetBooksByGenre(int id);
        Genre GetGenre(int id);
        bool HasGenre(int genreId);
    }
}
