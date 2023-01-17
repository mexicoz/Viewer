using Viewer.Models;

namespace Viewer.Interface
{
    public interface IAuthorRepository
    {
        ICollection<Author> GetAuthors();
        ICollection<Book> GetBooksByAuthor(int authorId);
        Author GetAuthor(int id);
        Author GetAuthor(string name);
        decimal GetAuthorRating(int authorId);
        bool HasAuthor(int authorId);
    }
}
