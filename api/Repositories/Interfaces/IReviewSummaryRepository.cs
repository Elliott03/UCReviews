namespace api.Repositories.Interfaces;

using api.Models;

public interface IReviewSummaryRepository
{
    public Task<ReviewSummary> GetReviewSummaryByDormId(int dormId);
    public Task<ReviewSummary> GetReviewSummaryByParkingGarageId(int parkingGarageId);
    public Task<ReviewSummary> GetReviewSummaryByDiningHallId(int diningHallId);
    public Task<ReviewSummary> SaveReviewSummary(ReviewSummary reviewSummary);
}