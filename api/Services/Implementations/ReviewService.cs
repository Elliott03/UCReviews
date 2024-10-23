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
    public async Task<IEnumerable<Review>> GetReviews()
    {
        return await _repository.GetAllReviews();
    }
    public async Task<List<Review>> GetReviewsByDormId(int dormId)
    {
        return await _repository.GetReviewsByDormId(dormId);
    }

    public async Task<List<Review>> GetReviewsByParkingGarageId(int garageId)
    {
        return await _repository.GetReviewsByParkingGarageId(garageId);
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
            return await _repository.GetReviewsByDormId((int)model.DormId);
        }
        else if (model.ParkingGarageId is not null)
        {
            return await _repository.GetReviewsByParkingGarageId((int)model.ParkingGarageId);
        }
        else if (model.DiningHallId is not null)
        {
            return await _repository.GetReviewsByDiningHallId((int)model.DiningHallId);
        }
        else
        {
            throw new Exception("There must be a foreign key association");
        }
    }


}