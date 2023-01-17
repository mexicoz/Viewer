using Viewer.Data;
using Viewer.Interface;
using Viewer.Models;

namespace Viewer.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext _context;

        public AuthorRepository(DataContext context)
        {
            _context = context;
        }

        public Author GetAuthor(int id)
        {
            return _context.Authors.Where(a => a.Id == id).FirstOrDefault();
        }

        public Author GetAuthor(string name)
        {
            return _context.Authors.Where(n => n.Name == name).FirstOrDefault();
        }

        public decimal GetAuthorRating(int authorId)
        {
            var review = _context.Reviews.Where(p => p.Id == authorId);

            if(review.Count() <= 0)
            {
                return 0;
            }
            return ((decimal)review.Sum(r => r.Rating) / review.Count());
        }

        public ICollection<Author> GetAuthors()
        {
            return _context.Authors.OrderBy(a => a.Id).ToList();
        }

        public ICollection<Book> GetBooksByAuthor(int authorId)
        {
            return _context.Books.Where(c => c.Id == authorId).ToList();
        }

        public bool HasAuthor(int authorId)
        {
            return _context.Authors.Any(p => p.Id == authorId);
        }
    }
}
