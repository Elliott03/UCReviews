namespace api.Services.Implementations;

using System.Threading.Tasks;
using api.Extensions;
using api.Models;
using api.Repositories.Interfaces;
using api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

class ReviewSummaryService : IReviewSummaryService
{
    private readonly UCReviewsContext _dbContext;

    private readonly IReviewSummaryRepository _reviewSummaryRepository;

    public ReviewSummaryService(UCReviewsContext context, IReviewSummaryRepository reviewSummaryRepository)
    {
        _dbContext = context;
        _reviewSummaryRepository = reviewSummaryRepository;
    }

    public async Task<ReviewSummary> UpdateReviewSummary(Review review, IReviewable reviewable = null)
    {
        var summary = await GenerateSummaryText(review);
        reviewable ??= await review.GetReviewableAsync(_dbContext);
        bool isNewReviewSummary = false;

        if (reviewable == null)
        {
            throw new Exception("A review must be associated with a reviewable");
        }

        ReviewSummary reviewSummary;
        if (reviewable is Dorm)
        {
            reviewSummary = await _reviewSummaryRepository.GetReviewSummaryByDormId(reviewable.Id);
            isNewReviewSummary = reviewSummary == null;
            reviewSummary ??= new ReviewSummary
            {
                DormId = reviewable.Id,
                AverageRating = review.StarRating
            };
        }
        else if (reviewable is ParkingGarage)
        {
            reviewSummary = await _reviewSummaryRepository.GetReviewSummaryByParkingGarageId(reviewable.Id);
            isNewReviewSummary = reviewSummary == null;
            reviewSummary ??= new ReviewSummary { ParkingGarageId = reviewable.Id, AverageRating = review.StarRating };
        }
        else if (reviewable is DiningHall)
        {
            reviewSummary = await _reviewSummaryRepository.GetReviewSummaryByDiningHallId(reviewable.Id);
            isNewReviewSummary = reviewSummary == null;
            reviewSummary ??= new ReviewSummary { DiningHallId = reviewable.Id, AverageRating = review.StarRating };
        }
        else if (reviewable is Course)
        {
            reviewSummary = await _reviewSummaryRepository.GetReviewSummaryByCourseId(reviewable.Id);
            isNewReviewSummary = reviewSummary == null;
            reviewSummary ??= new ReviewSummary { CourseId = reviewable.Id, AverageRating = review.StarRating };
        }
        else
        {
            throw new ArgumentNullException(nameof(reviewable));
        }

        reviewSummary.SummaryText = summary;
        reviewSummary.TotalReviews++; // Increment the total number of reviews

        if (reviewSummary.AverageRating != review.StarRating)
        {
            reviewSummary.AverageRating = CalculateNewAverage(reviewSummary, review);
        }

        if (isNewReviewSummary)
        {
            await _dbContext.ReviewSummary.AddAsync(reviewSummary);
        }
        else
        {
            await _dbContext.ReviewSummary
                .Where(rs => rs.Id == reviewSummary.Id)
                .ExecuteUpdateAsync(setters =>
                setters
                    .SetProperty(rs => rs.SummaryText, summary)
                    .SetProperty(rs => rs.TotalReviews, reviewSummary.TotalReviews + 1)
                    .SetProperty(rs => rs.AverageRating, reviewSummary.AverageRating)
            );
        }

        await _dbContext.SaveChangesAsync();
        return reviewSummary;
    }

    public async Task<string> GenerateSummaryText(Review review, IReviewable reviewable = null)
    {
        await Task.Delay(1000);
        return "The at a glance section has yet to be implemented";
        throw new NotImplementedException();
    }

    /// <summary>
    /// This method computes the new average rating for a given review summary and review.
    /// <see cref="https://en.wikipedia.org/wiki/Moving_average#Cumulative_average"/>
    /// </summary>
    private decimal CalculateNewAverage(ReviewSummary reviewSummary, Review review)
    {
        return reviewSummary.AverageRating + (review.StarRating - reviewSummary.AverageRating) / reviewSummary.TotalReviews;
    }
}