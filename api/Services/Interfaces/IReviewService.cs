namespace api.Services.Interfaces;

using api.Models;
using api.ViewModels;

public interface IReviewService
{
    public Task<IEnumerable<Review>> GetReviews();
    public Task<List<Review>> GetReviewsByDormId(int dormId);
    public Task<List<Review>> SaveReview(SaveReviewViewModel review);
}