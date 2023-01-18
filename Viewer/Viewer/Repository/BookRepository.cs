using Viewer.Data;
using Viewer.Interface;
using Viewer.Models;

namespace Viewer.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;

        public BookRepository(DataContext context)
        {
            _context = context;
        }
        public Book GetBook(int id)
        {
            return _context.Books.Where(b => b.Id == id).FirstOrDefault();
        }

        public Book GetBook(string name)
        {
            return _context.Books.Where(b => b.Name == name).FirstOrDefault();
        }

        public Author GetBookAuthor(int bookId)
        {
            return _context.Authors.Where(a => a.Books.Any(b => b.Id == bookId)).FirstOrDefault();
        }

        public Genre GetBookGenre(int bookId)
        {
            return _context.Genres.Where(g => g.Id == bookId).FirstOrDefault();
        }

        public ICollection<Book> GetBooks()
        {
            return _context.Books.OrderBy(b => b.Id).ToList();
        }

        public ICollection<Review> GetReviewsByBook(int bookId)
        {
            return _context.Reviews.Where(r => r.Reviewer.Id == bookId).ToList();
        }

        public bool HasBook(int bookId)
        {
            return _context.Books.Any(b => b.Id == bookId);
        }
    }
}
