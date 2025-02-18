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
    public async Task<IEnumerable<Review>> GetReviews(int prev, int perPage, int userId)
    {
        return await _repository.GetReviews(prev, perPage, userId);
    }
    public async Task<List<Review>> GetReviewsByDormId(int dormId, int prev, int perPage, int userId)
    {
        return await _repository.GetReviewsByDormId(dormId, prev, perPage, userId);
    }

    public async Task<List<Review>> GetReviewsByParkingGarageId(int garageId, int prev, int perPage, int userId)
    {
        return await _repository.GetReviewsByParkingGarageId(garageId, prev, perPage, userId);
    }


    public async Task<List<Review>> GetReviewsByDiningHallId(int diningHallId, int prev, int perPage, int userId)
    {
        return await _repository.GetReviewsByDiningHallId(diningHallId, prev, perPage, userId);
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
        };
        return await _repository.SaveReview(review);
    }

    public async Task<Review> GetReviewById(int id) 
    {
        return await _repository.GetReviewById(id);
    }
    public async Task<Review> SaveVote(Vote vote, int userId) 
    {
        return await _repository.SaveVote(vote, userId);
    }
}