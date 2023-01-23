using Microsoft.AspNetCore.Mvc;
using Viewer.Interface;
using Viewer.Models;

namespace Viewer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
        public IActionResult GetReviews()
        {
            var reviews = _reviewRepository.GetReviews();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(reviews);
        }
        [HttpGet("{reviewId}")]
        [ProducesResponseType(200, Type = typeof(Author))]
        [ProducesResponseType(400)]
        public IActionResult GetReview(int reviewId)
        {
            if (!_reviewRepository.HasReview(reviewId))
            {
                return NotFound();
            }
            var review = _reviewRepository.GetReview(reviewId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(review);
        }
        [HttpGet("{reviewId}/reviwer")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Book>))]
        [ProducesResponseType(400)]
        public IActionResult GetReviwerByReview(int reviewId)
        {
            if (!_reviewRepository.HasReview(reviewId))
            {
                return NotFound();
            }
            var reviewer = _reviewRepository.GetReviewerByReview(reviewId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(reviewer);
        }
        [HttpGet("{reviewId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetReviewRating(int reviewId)
        {
            if (!_reviewRepository.HasReview(reviewId))
            {
                return NotFound();
            }
            var rating = _reviewRepository.GetReviewRating(reviewId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(rating);
        }
    }  

}

