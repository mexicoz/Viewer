using Viewer.Models;

namespace Viewer.Interface
{
    public interface IReviewerRepository
    {
        ICollection<Reviewer> GetReviewers();
        Reviewer GetReviewer(int id);
        ICollection<Review> GetReviewsByReviwer(int reviwerId);
        bool HasReviewer(int reviwerId);
    }
}
