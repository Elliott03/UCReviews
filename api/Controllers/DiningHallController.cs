using api.Models;
using api.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;


[ApiController]
[Route("[controller]")]
public class DiningHallController : ControllerBase
{
    private readonly IDiningHallService _service;
    private readonly PaginationSettings _paginationSettings;

    public DiningHallController(IDiningHallService service, IOptions<PaginationSettings> paginationSettings)
    {
        _service = service;
        _paginationSettings = paginationSettings.Value;
    }

    [HttpGet]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DiningHall>>> GetDiningHalls(
    [FromQuery] int prev = 0, 
    [FromQuery] int? perPage = null, 
    [FromQuery] string? searchTerm = null) 
    {
    perPage ??= _paginationSettings.DefaultPerPage;
    var diningHalls = await _service.GetDiningHalls(prev, (int)perPage, searchTerm);
    return Ok(diningHalls);
    }
    [HttpGet("{slug}")]
    public async Task<ActionResult<DiningHall>> GetDiningHall(string slug)
    {
        return Ok(await _service.GetDiningHall(slug));
    }
}