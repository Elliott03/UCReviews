using api.Models;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.Implementations;

public class ReviewSummaryRepository : IReviewSummaryRepository
{
    private readonly UCReviewsContext _dbContext;

    public ReviewSummaryRepository(UCReviewsContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ReviewSummary> GetReviewSummaryByDiningHallId(int diningHallId)
    {
        return await _dbContext.ReviewSummary.Where(rs => rs.DiningHallId == diningHallId).FirstOrDefaultAsync();
    }

    public async Task<ReviewSummary> GetReviewSummaryByDormId(int dormId)
    {
        return await _dbContext.ReviewSummary.Where(rs => rs.DormId == dormId).FirstOrDefaultAsync();
    }

    public async Task<ReviewSummary> GetReviewSummaryByParkingGarageId(int parkingGarageId)
    {
        return await _dbContext.ReviewSummary.Where(rs => rs.ParkingGarageId == parkingGarageId).FirstOrDefaultAsync();
    }

    public async Task<ReviewSummary> SaveReviewSummary(ReviewSummary reviewSummary)
    {
        await _dbContext.AddAsync(reviewSummary);
        await _dbContext.SaveChangesAsync();
        return reviewSummary;
    }
}