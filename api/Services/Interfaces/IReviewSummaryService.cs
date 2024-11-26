namespace api.Services.Interfaces;

using api.Models;

public interface IReviewSummaryService
{
    public Task<ReviewSummary> UpdateReviewSummary(Review review, IReviewable reviewable = null);

    public Task<string> GenerateSummaryText(Review review, IReviewable reviewable = null);
}