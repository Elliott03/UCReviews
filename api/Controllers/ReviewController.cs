namespace api.Controllers;

using api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.ViewModels;
using Microsoft.Extensions.Options;
using api.Settings;
using api.Dto;

[ApiController]
[Route("[controller]")]
[Authorize]
public class ReviewController : ControllerBase
{
    private readonly IReviewService _service;
    private readonly ILogger<ReviewController> _logger;
    private readonly PaginationSettings _paginationSettings;

    public ReviewController(IReviewService service, ILogger<ReviewController> logger, IOptions<PaginationSettings> paginationSettings)
    {
        _service = service;
        _logger = logger;
        _paginationSettings = paginationSettings.Value;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Review>>> GetReviews([FromQuery] int prev = 0, [FromQuery] int? perPage = null)
    {
        perPage ??= _paginationSettings.DefaultPerPage;
        var reviews = await _service.GetReviews(prev, (int)perPage);
        return reviews.Count() > 0 ? Ok(reviews) : NoContent();
    }

    [HttpGet("Dorm/{dormId}")]
    public async Task<ActionResult<List<ReviewWithUser>>> GetReviewByDormId(int dormId, [FromQuery] int prev = 0, [FromQuery] int? perPage = null)
    {
        perPage ??= _paginationSettings.DefaultPerPage;
        return await _service.GetReviewsByDormId(dormId, prev, (int)perPage);
    }

    [HttpGet("ParkingGarage/{garageId}")]
    public async Task<ActionResult<List<ReviewWithUser>>> GetReviewByParkingGarageId(int garageId, [FromQuery] int prev = 0, [FromQuery] int? perPage = null)
    {
        perPage ??= _paginationSettings.DefaultPerPage;
        return await _service.GetReviewsByParkingGarageId(garageId, prev, (int)perPage);
    }

    [HttpGet("DiningHall/{diningHallId}")]
    public async Task<ActionResult<List<ReviewWithUser>>> GetReviewByDiningHallId(int diningHallId, [FromQuery] int prev = 0, [FromQuery] int? perPage = null)
    {
        perPage ??= _paginationSettings.DefaultPerPage;
        return await _service.GetReviewsByDiningHallId(diningHallId, prev, (int)perPage);
    }

    [HttpPost]
    public async Task<ActionResult<ReviewWithSummary>> SaveReview(SaveReviewViewModel review)
    {
        if (review.ReviewText.Length <= 1000)
            return await _service.SaveReview(review);
        return Conflict();
    }

}