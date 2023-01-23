﻿using Viewer.Data;
using Viewer.Interface;
using Viewer.Models;

namespace Viewer.Repository
{
    public class ReviewerRepository : IReviewerRepository
    {
        private readonly DataContext _context;

        public ReviewerRepository(DataContext context)
        {
            _context = context;
        }
        public Reviewer GetReviewer(int id)
        {
            return _context.Reviewers.Where(r => r.Id == id).FirstOrDefault();
        }

        public ICollection<Reviewer> GetReviewers()
        {
            return _context.Reviewers.OrderBy(x => x.Id).ToList();
        }

        public ICollection<Review> GetReviewsByReviwer(int reviwerId)
        {
            return _context.Reviews.Where(r => r.Reviewer.Id== reviwerId).ToList();
        }

        public bool HasReviewer(int reviwerId)
        {
            return _context.Reviewers.Any(r => r.Id== reviwerId);
        }
    }
}
