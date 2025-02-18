namespace api.Repositories.Implementations;

using api.Dto;
using api.Enums;
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

    public async Task<IEnumerable<Review>> GetReviews(int prev, int perPage, int userId)
    {
        var query = _dbContext.Review.AsQueryable();
        perPage = int.Min(perPage, _paginationSettings.MaxPerPage);
        query = query.Where(r => r.Id > prev).Take(perPage);
        var reviews = await query.ToListAsync();
        foreach(var review in reviews)
        {
            var votes = await _dbContext.Vote.Where(v => v.ReviewId == review.Id).ToListAsync();
            review.Votes = votes;
            foreach(var vote in review.Votes)
            {
                if (vote.UserId == userId)
                {
                    review.UserVoteType = (VoteType)vote.SelectedVote;
                }
            }
        }
        return reviews;
    }

    public async Task<List<Review>> GetReviewsByDormId(int dormId, int prev, int perPage, int userId)
    {
        var query = _dbContext.Review.AsQueryable();
        perPage = int.Min(perPage, _paginationSettings.MaxPerPage);
        query = query.Where(r => r.Id > prev && r.DormId == dormId).Take(perPage);
        List<Review> reviews =  await query.ToListAsync();
        foreach(var review in reviews) 
        {
            var votes = await _dbContext.Vote.Where(v => v.ReviewId == review.Id).ToListAsync();
            review.Votes = votes;
            int averageVote = 0;
            foreach(var vote in votes) 
            {
                if (vote.SelectedVote == VoteType.Upvote)
                {
                    averageVote++;
                    if (vote.UserId == userId)
                    {
                        review.UserVoteType = VoteType.Upvote;
                    }

                } 
                else if (vote.SelectedVote == VoteType.Downvote)
                {
                    averageVote--;
                    if (vote.UserId == userId)
                    {
                        review.UserVoteType = VoteType.Downvote;
                    }

                }
            }
            if (review.UserVoteType != VoteType.Upvote && review.UserVoteType != VoteType.Downvote) 
            {
                review.UserVoteType = VoteType.NoVote;
            }
            review.AverageVote = averageVote;
        }
        
        return reviews;
    }


    public async Task<List<Review>> GetReviewsByParkingGarageId(int parkingGarageId, int prev, int perPage, int userId)
    {
        var query = _dbContext.Review.AsQueryable();
        perPage = int.Min(perPage, _paginationSettings.MaxPerPage);
        query = query.Where(r => r.Id > prev && r.ParkingGarageId == parkingGarageId).Take(perPage);
        var reviews = await query.ToListAsync();
        
        foreach(var review in reviews) 
        {
            var votes = await _dbContext.Vote.Where(v => v.ReviewId == review.Id).ToListAsync();
            review.Votes = votes;
            int averageVote = 0;
            foreach(var vote in votes) 
            {
                if (vote.SelectedVote == VoteType.Upvote)
                {
                    averageVote++;
                    if (vote.UserId == userId)
                    {
                        review.UserVoteType = VoteType.Upvote;
                    }

                } 
                else if (vote.SelectedVote == VoteType.Downvote)
                {
                    averageVote--;
                    if (vote.UserId == userId)
                    {
                        review.UserVoteType = VoteType.Downvote;
                    }

                }
            }
            if (review.UserVoteType != VoteType.Upvote && review.UserVoteType != VoteType.Downvote) 
            {
                review.UserVoteType = VoteType.NoVote;
            }
            review.AverageVote = averageVote;
        }
        return reviews;
    }

    public async Task<List<Review>> GetReviewsByDiningHallId(int diningHallId, int prev, int perPage, int userId)
    {
        var query = _dbContext.Review.AsQueryable();
        perPage = int.Min(perPage, _paginationSettings.MaxPerPage);
        query = query.Where(r => r.Id > prev && r.DiningHallId == diningHallId).Take(perPage);
        var reviews = await query.ToListAsync();
        foreach(var review in reviews) 
        {
            var votes = await _dbContext.Vote.Where(v => v.ReviewId == review.Id).ToListAsync();
            review.Votes = votes;
            int averageVote = 0;
            foreach(var vote in votes) 
            {
                if (vote.SelectedVote == VoteType.Upvote)
                {
                    averageVote++;
                    if (vote.UserId == userId)
                    {
                        review.UserVoteType = VoteType.Upvote;
                    }

                } 
                else if (vote.SelectedVote == VoteType.Downvote)
                {
                    averageVote--;
                    if (vote.UserId == userId)
                    {
                        review.UserVoteType = VoteType.Downvote;
                    }
                }
            }
            if (review.UserVoteType != VoteType.Upvote && review.UserVoteType != VoteType.Downvote) 
            {
                review.UserVoteType = VoteType.NoVote;
            }
            review.AverageVote = averageVote;
        }
        return reviews;
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
    public async Task<Review> GetReviewById(int id) 
    {
        var review = await _dbContext.Review.FirstOrDefaultAsync(r => r.Id == id);
        return review;
    }
public async Task<Review> SaveVote(Vote vote, int userId) 
{
    var existingVote = await _dbContext.Vote
        .FirstOrDefaultAsync(v => v.ReviewId == vote.ReviewId && v.UserId == userId);

    // Retrieve review and check for null
    var review = await _dbContext.Review.FirstOrDefaultAsync(r => r.Id == vote.ReviewId);
    if (review == null)
    {
        throw new Exception($"Review with ID {vote.ReviewId} not found.");
    }

    if (existingVote != null)
    {
        // Undo previous vote effect
        if (existingVote.SelectedVote == VoteType.Upvote)
        {
            review.AverageVote--;  // Remove previous upvote
        }
        else if (existingVote.SelectedVote == VoteType.Downvote)
        {
            review.AverageVote++;  // Remove previous downvote
        }

        // Update existing vote
        existingVote.SelectedVote = vote.SelectedVote;
        _dbContext.Vote.Update(existingVote);  // Ensures an update, not a new insert
    }
    else
    {
        // New vote, so add it
        await _dbContext.Vote.AddAsync(vote);
    }

    await _dbContext.SaveChangesAsync();

    // Recalculate total votes
    review.AverageVote = await _dbContext.Vote
        .Where(v => v.ReviewId == review.Id)
        .SumAsync(v => v.SelectedVote == VoteType.Upvote ? 1 : (v.SelectedVote == VoteType.Downvote ? -1 : 0));

    // Update the user's vote type
    var userVote = await _dbContext.Vote
        .FirstOrDefaultAsync(v => v.ReviewId == review.Id && v.UserId == userId);

    review.UserVoteType = userVote != null ? (VoteType)userVote.SelectedVote : VoteType.NoVote;

    return review;
}

}