namespace api.Repositories.Interfaces;

using api.Models;

public interface IReviewRepository
{
    public Task<IEnumerable<Review>> GetReviews(int prev, int perPage);
    public Task<List<Review>> GetReviewsByDormId(int dormId, int prev, int perPage);
    public Task<List<Review>> GetReviewsByParkingGarageId(int parkingGarageId, int prev, int perPage);
    public Task<List<Review>> GetReviewsByDiningHallId(int diningHallId, int prev, int perPage);
    public Task SaveReview(Review review);
}