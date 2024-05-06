using System.Collections;
using api.Models;
using api.Repositories.Interfaces;
using api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Services.Implementations;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _repository;
    private readonly IBuildingService _buildingService;
    public ReviewService(IReviewRepository repository, IBuildingService buildingService) 
    {
        _repository = repository;
        _buildingService = buildingService;
    }
    public async Task<IEnumerable<Review>> GetReviews()
    {
        return await _repository.GetAllReviews();
    }
    public async Task<List<Review>> GetReviewsByBuildingId(int buildingId) 
    {
        return await _repository.GetReviewsByBuildingId(buildingId);
    }
    public async Task<List<Review>> SaveReview(SaveReviewViewModel reviewViewModel) 
    {
        var review = new Review
        {
            ReviewText = reviewViewModel.ReviewText,
            StarRating = reviewViewModel.Rating,
            TimeCreated = DateTime.Now,
            UserId = reviewViewModel.UserId,
            BuildingId = reviewViewModel.BuildingId
        };
        await _repository.SaveReview(review);
        await _buildingService.SetBuildingRating(reviewViewModel.BuildingId);
        return await _repository.GetReviewsByBuildingId(reviewViewModel.BuildingId);
    }

    
}