using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")]
[Authorize]
public class DiningHallController : ControllerBase
{
    private readonly IDiningHallService _service;
    public DiningHallController(IDiningHallService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DiningHall>>> GetAllDiningHalls()
    {
        return Ok(await _service.GetAllDiningHalls());
    }
    [HttpGet("{queryParam}")]
    public async Task<ActionResult<DiningHall>> GetDiningHall(string queryParam)
    {
        return Ok(await _service.GetDiningHall(queryParam));
    }
}