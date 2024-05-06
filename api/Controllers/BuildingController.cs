using api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using api.Models;
using AutoMapper;
namespace api.Controllers;
[ApiController]
[Route("[controller]")]
[Authorize]
public class BuildingController : ControllerBase
{
    private readonly IBuildingService _service;
    private readonly ILogger<BuildingController> _logger;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _environment;
    public BuildingController(IBuildingService service, ILogger<BuildingController> logger, IMapper mapper, IWebHostEnvironment environment)
    {
        _service = service;
        _logger = logger;
        _mapper = mapper;
        _environment = environment;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SmallBuildingDto>>> GetSmallBuildings()
    {

        var buildings = await _service.GetBuildings();
        var smallBuildings = AttachImages(buildings);
        return smallBuildings.Count() > 0 ? Ok(smallBuildings) : NoContent();

    }
    [HttpGet("{queryParam}")]
    public async Task<ActionResult<LargeBuildingDto>> GetLargeBuilding(string queryParam)
    {
        var building = await _service.GetBuilding(queryParam);
        var largeBuilding = _mapper.Map<LargeBuildingDto>(building);
        return largeBuilding != null ? Ok(largeBuilding) : NoContent();

    }
    private IEnumerable<SmallBuildingDto> AttachImages(IEnumerable<Building> buildings)
    {
        var smallBuildings = _mapper.Map<IEnumerable<SmallBuildingDto>>(buildings);
        foreach(var building in smallBuildings)
        {
            var imagePath = Path.Combine(_environment.WebRootPath, "Images", "Small_Buildings","CalhounLarge.jpg");
            if (System.IO.File.Exists(imagePath))
            {

                var fileStream = System.IO.File.OpenRead(imagePath);
                building.Image = File(fileStream, "image/jpeg");
            }
            
        }

        return smallBuildings;
    }
}