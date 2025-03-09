using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Review.Entities;

namespace MultiShop.Review.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ReviewController : ControllerBase
    {
        private readonly ReviewContext _context;

        public ReviewController(ReviewContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ReviewList()
        {
            var data = _context.UserReviews.ToList();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult GetReviewById(int id)
        {
            return Ok(_context.UserReviews.Find(id));
        }

        [HttpGet("ReviewListByProductId/{productId}")]
        public IActionResult ReviewListByProductId(string productId)
        {
            var data = _context.UserReviews.Where(ur => ur.ProductId == productId).ToList();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult AddReview(UserReview userReview)
        {
            _context.UserReviews.Add(userReview);
            _context.SaveChanges();
            return Ok("Review Successfully Added");
        }

        [HttpPut]
        public IActionResult EditReview(UserReview userReview)
        {
            _context.UserReviews.Update(userReview);
            _context.SaveChanges();
            return Ok("Review Successfully Added");
        }

        [HttpDelete]
        public IActionResult DeleteReview(int id)
        {
            _context.UserReviews.Remove(_context.UserReviews.Find(id));
            _context.SaveChanges();
            return Ok("Review Successfully Deleted");
        }
    }
}
