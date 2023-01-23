using Viewer.Models;

namespace Viewer.Interface
{
    public interface IReviewRepository
    {
        public ICollection<Review> GetReviews();
        public Review GetReview(int id);
        public decimal GetReviewRating(int reviewId);
        public Reviewer GetReviewerByReview(int reviewId);
        public bool HasReview(int reviewId);
    }
}
