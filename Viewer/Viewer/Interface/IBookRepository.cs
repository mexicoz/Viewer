using Viewer.Models;

namespace Viewer.Interface
{
    public interface IBookRepository
    {
        ICollection<Book> GetBooks();
        ICollection<Review> GetReviewsByBook(int bookId);
        Book GetBook(int id);
        Book GetBook(string name);
        Author GetBookAuthor(int bookId);
        Genre GetBookGenre(int bookId);
        bool HasBook(int bookId);
    }
}
