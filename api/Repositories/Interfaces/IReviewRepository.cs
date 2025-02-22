namespace api.Repositories.Interfaces;

using api.Dto;
using api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IReviewRepository
{
    public Task<IEnumerable<Review>> GetReviews(int prev, int perPage);
    public Task<List<ReviewWithUser>> GetReviewsByDormId(int dormId, int prev, int perPage);
    public Task<List<ReviewWithUser>> GetReviewsByParkingGarageId(int parkingGarageId, int prev, int perPage);
    public Task<List<ReviewWithUser>> GetReviewsByDiningHallId(int diningHallId, int prev, int perPage);
    public Task<List<ReviewWithUser>> GetReviewsByCourseId(int courseId, int prev, int perPage);
    public Task<ReviewWithSummary> SaveReview(Review review);
}