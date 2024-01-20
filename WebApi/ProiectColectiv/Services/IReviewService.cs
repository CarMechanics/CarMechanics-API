using ProiectColectiv.Data;

namespace ProiectColectiv.Services
{
    public interface IReviewService
    {
        Review GetReviewById(int reviewId);
        IEnumerable<Review> GetAllReviews(string userEmail);
        void AddReview(Review review);
        void UpdateReview(Review review, int reviewId);
        void DeleteReview(int reviewId);
    }
}