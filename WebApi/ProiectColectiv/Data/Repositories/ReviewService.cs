using ProiectColectiv.Data;
using ProiectColectiv.AppDbContext;
using ProiectColectiv.Data.Repositories;
using ProiectColectiv.Services;

public class ReviewService : IReviewService
{
    private readonly IRepository<Review, Review> _reviewRepository;

    public ReviewService(IRepository<Review, Review> reviewRepository)
    {
        _reviewRepository = reviewRepository ?? throw new ArgumentNullException(nameof(reviewRepository));
    }

    public Review GetReviewById(int reviewId)
    {
        return _reviewRepository.GetById(reviewId);
    }

    public IEnumerable<Review> GetAllReviews(string userEmail)
    {
        return _reviewRepository.GetAll(userEmail);
    }

    public void AddReview(Review review)
    {
        _reviewRepository.Add(review);
    }

    public void UpdateReview(Review review, int reviewId)
    {
        var existingReview = _reviewRepository.GetById(reviewId);

        if (existingReview == null)
        {
            throw new ArgumentException($"Car with ID {reviewId} not found.");
        }

        var reviewBrandInfo = new Review
        {
            Grade = review.Grade,
            Description = review.Description,
            Email = review.Email,
            UserName = review.UserName
        };

        _reviewRepository.Update(existingReview);
    }

    public void DeleteReview(int reviewId)
    {
        _reviewRepository.Delete(reviewId);
    }
}