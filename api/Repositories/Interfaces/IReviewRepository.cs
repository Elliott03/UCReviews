namespace api.Repositories.Interfaces;

using api.Dto;
using api.Models;

public interface IReviewRepository
{
    public Task<IEnumerable<Review>> GetReviews(int prev, int perPage, int userId);
    public Task<List<Review>> GetReviewsByDormId(int dormId, int prev, int perPage, int userId);
    public Task<List<Review>> GetReviewsByParkingGarageId(int parkingGarageId, int prev, int perPage, int userId);
    public Task<List<Review>> GetReviewsByDiningHallId(int diningHallId, int prev, int perPage, int userId);
    public Task<ReviewWithSummary> SaveReview(Review review);
    public Task<Review> GetReviewById(int id);
    public Task<Review> SaveVote(Vote vote, int userId);
}