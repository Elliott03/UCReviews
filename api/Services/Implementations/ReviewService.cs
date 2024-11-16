namespace api.Services.Implementations;

using System.Collections;
using api.Models;
using api.Repositories.Interfaces;
using api.Services.Interfaces;
using api.ViewModels;
using Microsoft.EntityFrameworkCore;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _repository;
    private readonly IDormService _dormService;
    public ReviewService(IReviewRepository repository, IDormService dormService)
    {
        _repository = repository;
        _dormService = dormService;
    }
    public async Task<IEnumerable<Review>> GetReviews(int prev, int perPage)
    {
        return await _repository.GetReviews(prev, perPage);
    }
    public async Task<List<Review>> GetReviewsByDormId(int dormId, int prev, int perPage)
    {
        return await _repository.GetReviewsByDormId(dormId, prev, perPage);
    }

    public async Task<List<Review>> GetReviewsByParkingGarageId(int garageId, int prev, int perPage)
    {
        return await _repository.GetReviewsByParkingGarageId(garageId, prev, perPage);
    }


    public async Task<List<Review>> GetReviewsByDiningHallId(int diningHallId, int prev, int perPage)
    {
        return await _repository.GetReviewsByDiningHallId(diningHallId, prev, perPage);
    }

    public async Task<List<Review>> SaveReview(SaveReviewViewModel model)
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
        await _repository.SaveReview(review);
        if (model.DormId is not null)
        {
            return await _repository.GetReviewsByDormId((int)model.DormId, review.Id - 1, 1);
        }
        else if (model.ParkingGarageId is not null)
        {
            return await _repository.GetReviewsByParkingGarageId((int)model.ParkingGarageId, review.Id - 1, 1);
        }
        else if (model.DiningHallId is not null)
        {
            return await _repository.GetReviewsByDiningHallId((int)model.DiningHallId, review.Id - 1, 1);
        }
        else
        {
            throw new Exception("There must be a foreign key association");
        }
    }


}