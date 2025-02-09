namespace api.Repositories.Interfaces;

using api.Dto;
using api.Models;

public interface IReviewRepository
{
    public Task<IEnumerable<Review>> GetReviews(int prev, int perPage);
    public Task<List<Review>> GetReviewsByDormId(int dormId, int prev, int perPage);
    public Task<List<Review>> GetReviewsByParkingGarageId(int parkingGarageId, int prev, int perPage);
    public Task<List<Review>> GetReviewsByDiningHallId(int diningHallId, int prev, int perPage);
    public Task<ReviewWithSummary> SaveReview(Review review);
    public Task<Review> GetReviewById(int id);
    public Task SaveVote(Vote vote);
}