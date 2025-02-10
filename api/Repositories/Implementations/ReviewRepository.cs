namespace api.Repositories.Implementations;

using api.Dto;
using api.Extensions;
using api.Models;
using api.Repositories.Interfaces;
using api.Services.Interfaces;
using api.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

public class ReviewRepository : IReviewRepository
{
    private readonly UCReviewsContext _dbContext;
    private readonly PaginationSettings _paginationSettings;

    private readonly IReviewSummaryService _reviewSummaryService;

    public ReviewRepository(
        UCReviewsContext dbContext,
        IReviewSummaryService reviewSummaryService,
        IOptions<PaginationSettings> paginationSettings
    )
    {
        _dbContext = dbContext;
        _paginationSettings = paginationSettings.Value;
        _reviewSummaryService = reviewSummaryService;
    }

    public async Task<IEnumerable<Review>> GetReviews(int prev, int perPage)
    {
        var query = _dbContext.Review.AsQueryable();
        perPage = int.Min(perPage, _paginationSettings.MaxPerPage);
        query = query.Where(r => r.Id > prev).Take(perPage);
        return await query.ToListAsync();
    }

    public async Task<List<ReviewWithUser>> GetReviewsWithUsers(IQueryable<Review> query)
    {
        // Get get the user for each review, and combine the reviews with the users
        var reviewsWithUsers = await query.Include(r => r.User).ToListAsync();
        var reviewWithUsers = new List<ReviewWithUser>();
        foreach (var review in reviewsWithUsers)
        {
            var user = await _dbContext.User.FindAsync(review.UserId);
            reviewWithUsers.Add(new ReviewWithUser { review = review, user = new ReviewUser { Id = user.Id, Email = user.Email } });
        }

        return reviewWithUsers;
    }

    public async Task<List<ReviewWithUser>> GetReviewsByDormId(int dormId, int prev, int perPage)
    {
        var query = _dbContext.Review.AsQueryable();
        perPage = int.Min(perPage, _paginationSettings.MaxPerPage);
        query = query.Where(r => r.Id > prev && r.DormId == dormId).Take(perPage);
        return await GetReviewsWithUsers(query);
    }


    public async Task<List<ReviewWithUser>> GetReviewsByParkingGarageId(int parkingGarageId, int prev, int perPage)
    {
        var query = _dbContext.Review.AsQueryable();
        perPage = int.Min(perPage, _paginationSettings.MaxPerPage);
        query = query.Where(r => r.Id > prev && r.ParkingGarageId == parkingGarageId).Take(perPage);
        return await GetReviewsWithUsers(query);
    }

    public async Task<List<ReviewWithUser>> GetReviewsByDiningHallId(int diningHallId, int prev, int perPage)
    {
        var query = _dbContext.Review.AsQueryable();
        perPage = int.Min(perPage, _paginationSettings.MaxPerPage);
        query = query.Where(r => r.Id > prev && r.DiningHallId == diningHallId).Take(perPage);
        return await GetReviewsWithUsers(query);
    }

    public async Task<List<ReviewWithUser>> GetReviewsByCourseId(int courseId, int prev, int perPage)
    {
        var query = _dbContext.Review.AsQueryable();
        perPage = int.Min(perPage, _paginationSettings.MaxPerPage);
        query = query.Where(r => r.Id > prev && r.CourseId == courseId).Take(perPage);
        return await GetReviewsWithUsers(query);
    }

#nullable enable


    public async Task<ReviewWithSummary> SaveReview(Review review)
    {
        IReviewable reviewable = await review.GetReviewableAsync(_dbContext) ??
            throw new Exception("A review must be associated with a reviewable");

        var reviewSummary = await _reviewSummaryService.UpdateReviewSummary(review, reviewable);

        await _dbContext.AddAsync(review);
        await _dbContext.SaveChangesAsync();

        return new ReviewWithSummary { review = review, summary = reviewSummary };
    }
}