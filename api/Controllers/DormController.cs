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
    public class DormController : ControllerBase
    {
        private readonly IDormService _service;
        private readonly ILogger<DormController> _logger;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        private readonly PaginationSettings _paginationSettings;

        public DormController(IDormService service, ILogger<DormController> logger, IMapper mapper, IWebHostEnvironment environment, IOptions<PaginationSettings> paginationSettings)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
            _environment = environment;
            _paginationSettings = paginationSettings.Value;
        }

        [HttpGet]
        public async Task<ActionResult<List<Dorm>>> GetDorms([FromQuery] int prev = 0, [FromQuery] int? perPage = null)
        {
            perPage ??= _paginationSettings.DefaultPerPage;
            return Ok(await _service.GetDorms(prev, (int)perPage));
        }

        [HttpGet("{slug}")]
        public async Task<ActionResult<Dorm>> GetDorm(string slug)
        {
            var dorm = await _service.GetDorm(slug);
            return ResolveDorm(dorm);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Dorm>> GetDorm(int id)
        {
            var dorm = await _service.GetDorm(id);
            return ResolveDorm(dorm);
        }

        private ActionResult<Dorm> ResolveDorm(Dorm dorm)
        {
            if (dorm is not null)
            {
                return Ok(dorm);
            }

            return NotFound();
        }

    }
}
