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
    public async Task<List<Review>> SaveReview(SaveReviewViewModel reviewViewModel)
    {
        var review = new Review
        {
            ReviewText = reviewViewModel.ReviewText,
            StarRating = reviewViewModel.Rating,
            TimeCreated = DateTime.Now,
            UserId = reviewViewModel.UserId,
            DormId = reviewViewModel.DormId,
            ParkingGarageId = reviewViewModel.ParkingGarageId,
            DiningHallId = reviewViewModel.DiningHallId
        };
        await _repository.SaveReview(review);
        if (review.DormId != null)
        {
            return await _repository.GetReviewsByDormId(reviewViewModel.DormId.Value);
        } 
        else if (review.ParkingGarageId != null)
        {
            return await _repository.GetReviewsByParkingGarageId(reviewViewModel.ParkingGarageId.Value);
        }
        else if (review.DiningHallId != null)
        {
            return await _repository.GetReviewsByDiningHallId(reviewViewModel.DiningHallId.Value);
        }
        return null;
        
    }


}