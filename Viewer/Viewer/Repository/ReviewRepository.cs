using Viewer.Data;
using Viewer.Interface;
using Viewer.Models;

namespace Viewer.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;

        public ReviewRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateReview(Review review)
        {
            _context.Add(review);
            return Save();
        }

        public Review GetReview(int id)
        {
            return _context.Reviews.Where(r => r.Id == id).FirstOrDefault();
        }

        public Reviewer GetReviewerByReview(int reviewId)
        {
            return _context.Reviewers.Where(r => r.Reviews.Any(b => b.Id == reviewId)).FirstOrDefault();
        }

        public decimal GetReviewRating(int reviewId)
        {
            var review = _context.Reviews.Where(p => p.Id == reviewId);

            if (review.Count() <= 0)
            {
                return 0;
            }
            return ((decimal)review.Sum(r => r.Rating) / review.Count());
        }

        public ICollection<Review> GetReviews()
        {
            return _context.Reviews.OrderBy(r => r.Id).ToList();
        }

        public bool HasReview(int reviewId)
        {
            return _context.Reviews.Any(r => r.Id == reviewId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges(); 
            return saved > 0 ? true : false;
        }
    }
}
