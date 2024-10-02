namespace api.Services.Interfaces;
using api.Models;
public interface IReviewService
{
    public Task<IEnumerable<Review>> GetReviews();
    public Task<List<Review>> GetReviewsByDormId(int dormId);
    public Task<List<Review>> SaveReview(SaveReviewViewModel review);
}