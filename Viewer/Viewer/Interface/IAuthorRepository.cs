using Viewer.Models;

namespace Viewer.Interface
{
    public interface IAuthorRepository
    {
        ICollection<Author> GetAuthors();
    }
}
