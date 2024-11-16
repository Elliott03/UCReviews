namespace api.Services.Interfaces;

using api.Models;
using api.ViewModels;

public interface IReviewService
{
    public Task<IEnumerable<Review>> GetReviews(int prev, int perPage);
    public Task<List<Review>> GetReviewsByDormId(int dormId, int prev, int perPage);
    public Task<List<Review>> GetReviewsByParkingGarageId(int dormId, int prev, int perPage);
    public Task<List<Review>> GetReviewsByDiningHallId(int dormId, int prev, int perPage);
    public Task<List<Review>> SaveReview(SaveReviewViewModel review);
}