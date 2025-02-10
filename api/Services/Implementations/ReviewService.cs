namespace api.Services.Implementations;

using System.Collections;
using api.Dto;
using api.Models;
using api.Repositories.Interfaces;
using api.Services.Interfaces;
using api.ViewModels;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _repository;

    public ReviewService(IReviewRepository repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<Review>> GetReviews(int prev, int perPage)
    {
        return await _repository.GetReviews(prev, perPage);
    }
    public async Task<List<ReviewWithUser>> GetReviewsByDormId(int dormId, int prev, int perPage)
    {
        return await _repository.GetReviewsByDormId(dormId, prev, perPage);
    }

    public async Task<List<ReviewWithUser>> GetReviewsByParkingGarageId(int garageId, int prev, int perPage)
    {
        return await _repository.GetReviewsByParkingGarageId(garageId, prev, perPage);
    }


    public async Task<List<ReviewWithUser>> GetReviewsByDiningHallId(int diningHallId, int prev, int perPage)
    {
        return await _repository.GetReviewsByDiningHallId(diningHallId, prev, perPage);
    }

    public async Task<List<Review>> GetReviewsByCourseId(int dormId, int prev, int perPage)
    {
        return await _repository.GetReviewsByCourseId(dormId, prev, perPage);
    }
    public async Task<ReviewWithSummary> SaveReview(SaveReviewViewModel model)
    {
        var review = new Review
        {
            ReviewText = model.ReviewText,
            StarRating = model.Rating,
            UserId = model.UserId,
            TimeCreated = DateTime.UtcNow,
            DormId = model.DormId,
            ParkingGarageId = model.ParkingGarageId,
            DiningHallId = model.DiningHallId,
            CourseId = model.CourseId,
        };
        return await _repository.SaveReview(review);
    }
}