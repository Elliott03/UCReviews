namespace api.Controllers;

using api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.ViewModels;

[ApiController]
[Route("[controller]")]
[Authorize]
public class ReviewController : ControllerBase
{
    private readonly IReviewService _service;
    private readonly ILogger<ReviewController> _logger;
    public ReviewController(IReviewService service, ILogger<ReviewController> logger)
    {
        _service = service;
        _logger = logger;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Review>>> GetReviews()
    {

        var reviews = await _service.GetReviews();
        return reviews.Count() > 0 ? Ok(reviews) : NoContent();

    }

    [HttpGet("{dormId}")]
    public async Task<ActionResult<List<Review>>> GetReviewByDormId(int dormId)
    {
            return await _service.GetReviewsByDormId(dormId);

    }

    [HttpPost]
    public async Task<ActionResult<List<Review>>> SaveReview(SaveReviewViewModel review) {

        if (review.ReviewText.Length <= 1000)
            return await _service.SaveReview(review);
        return Conflict();

    }

}