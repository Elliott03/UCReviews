using System.Collections;
using api.Models;
using api.Repositories.Interfaces;
using api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Services.Implementations;

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
            DormId = reviewViewModel.DormId
        };
        await _repository.SaveReview(review);
        await _dormService.SetDormRating(reviewViewModel.DormId);
        return await _repository.GetReviewsByDormId(reviewViewModel.DormId);
    }

    
}