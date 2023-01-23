using Viewer.Models;

namespace Viewer.Interface
{
    public interface IAuthorRepository
    {
        ICollection<Author> GetAuthors();
        ICollection<Book> GetBooksByAuthor(int authorId);
        Author GetAuthor(int id);
        decimal GetAuthorRating(int authorId);
        bool HasAuthor(int authorId);
        bool CreateAuthor(Author author);
        bool Save();
    }
}
