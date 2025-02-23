namespace api.Services.Interfaces;

using api.Dto;
using api.Models;
using api.ViewModels;

public interface IReviewService
{
    public Task<IEnumerable<Review>> GetReviews(int prev, int perPage, int userId);
    public Task<List<ReviewWithUser>> GetReviewsByDormId(int dormId, int prev, int perPage, int userId);
    public Task<List<ReviewWithUser>> GetReviewsByParkingGarageId(int dormId, int prev, int perPage, int userId);
    public Task<List<ReviewWithUser>> GetReviewsByDiningHallId(int dormId, int prev, int perPage, int userId);
    public Task<List<ReviewWithUser>> GetReviewsByCourseId(int dormId, int prev, int perPage, int userId);

    public Task<ReviewWithSummary> SaveReview(SaveReviewViewModel review);
    public Task<Review> GetReviewById(int id);
    public Task<Review> SaveVote(Vote vote, int userId);
}