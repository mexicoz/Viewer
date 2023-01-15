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
        public ICollection<Author> GetAuthors()
        {
            return _context.Authors.OrderBy(a => a.Id).ToList();
        }
    }
}
