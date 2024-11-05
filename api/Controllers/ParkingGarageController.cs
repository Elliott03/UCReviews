using api.Models;
using api.Services.Interfaces;
using api.Settings;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingGarageController : ControllerBase
    {
        private readonly IParkingGarageService _service;
        private readonly ILogger<ParkingGarageController> _logger;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        private readonly PaginationSettings _paginationSettings;

        public ParkingGarageController(IParkingGarageService service, ILogger<ParkingGarageController> logger, IMapper mapper, IWebHostEnvironment environment, IOptions<PaginationSettings> paginationSettings)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
            _environment = environment;
            _paginationSettings = paginationSettings.Value;
        }

        [HttpGet]
        public async Task<ActionResult<List<ParkingGarage>>> GetParkingGarages([FromQuery] bool includeReviews = false, [FromQuery] int prev = 0, [FromQuery] int? perPage = null)
        {
            perPage ??= _paginationSettings.DefaultPerPage;
            return Ok(await _service.GetParkingGarages(includeReviews, prev, (int)perPage));
        }

        [HttpGet("{slug}")]
        public async Task<ActionResult<ParkingGarage>> GetParkingGarage(string slug, [FromQuery] bool includeReviews = false)
        {
            var garage = await _service.GetParkingGarage(slug, includeReviews);
            return ResolveGarage(garage);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ParkingGarage>> GetParkingGarage(int id, [FromQuery] bool includeReviews = false)
        {
            var garage = await _service.GetParkingGarage(id, includeReviews);
            return ResolveGarage(garage);
        }

        private ActionResult<ParkingGarage> ResolveGarage(ParkingGarage garage)
        {
            if (garage is not null)
            {
                return Ok(garage);
            }

            return NotFound();
        }

    }
}
