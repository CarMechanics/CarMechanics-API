using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Logging;
using ProiectColectiv.Data;
using ProiectColectiv.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace ProiectColectiv.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly ILogger<ReviewController> _logger;
        private readonly IReviewService _reviewService;

        public ReviewController(ILogger<ReviewController> logger, IReviewService reviewService)
        {
            _logger = logger;
            _reviewService = reviewService;
        }

        [HttpPost]
        public ActionResult Post(Review review)
        {
            _reviewService.AddReview(review);

            return new JsonResult(review);
        }

        [HttpGet]
        public IEnumerable<Review> Get(string userEmail)
        {
            var reviews = _reviewService.GetAllReviews(userEmail);
            return reviews;
        }

        [HttpGet("{reviewId}")]
        public Review GetReviewById(int reviewId)
        {
            return _reviewService.GetReviewById(reviewId);
        }

        [HttpPut("{carId}")]
        public ActionResult Update([FromBody] Review review, int reviewId)
        {
            _reviewService.UpdateReview(review, reviewId);

            return new JsonResult(true);
        }
    }
}