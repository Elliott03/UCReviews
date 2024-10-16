using api.Models;
using api.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public ParkingGarageController(IParkingGarageService service, ILogger<ParkingGarageController> logger, IMapper mapper, IWebHostEnvironment environment)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
            _environment = environment;
        }

        [HttpGet]
        public async Task<ActionResult<List<ParkingGarage>>> GetParkingGarages()
        {
            return Ok(await _service.GetParkingGarages());
        }

        [HttpGet("{slug}")]
        public async Task<ActionResult<ParkingGarage>> GetParkingGarageBySlug(string slug)
        {
            return Ok(await _service.GetParkingGarage(slug));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ParkingGarage>> GetParkingGarageById(int id)
        {
            return Ok(await _service.GetParkingGarageById(id));
        }

    }
}
