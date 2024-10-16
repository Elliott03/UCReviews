namespace api.Controllers;

using api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using api.Models;
using AutoMapper;
using api.Dto;

[ApiController]
[Route("[controller]")]
[Authorize]
public class DormController : ControllerBase
{
    private readonly IDormService _service;
    private readonly ILogger<DormController> _logger;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _environment;
    public DormController(IDormService service, ILogger<DormController> logger, IMapper mapper, IWebHostEnvironment environment)
    {
        _service = service;
        _logger = logger;
        _mapper = mapper;
        _environment = environment;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SmallDormDto>>> GetSmallDorms()
    {

        var dorms = await _service.GetDorms();
        var smallDorms = AttachImages(dorms);
        return smallDorms.Count() > 0 ? Ok(smallDorms) : NoContent();

    }
    [HttpGet("{queryParam}")]
    public async Task<ActionResult<LargeDormDto>> GetLargeDorm(string queryParam)
    {
        var dorm = await _service.GetDorm(queryParam);
        var largeDorm = _mapper.Map<LargeDormDto>(dorm);
        return largeDorm != null ? Ok(largeDorm) : NoContent();

    }
    private IEnumerable<SmallDormDto> AttachImages(IEnumerable<Dorm> dorms)
    {
        var smallDorms = _mapper.Map<IEnumerable<SmallDormDto>>(dorms);
        foreach(var dorm in smallDorms)
        {
            var imagePath = Path.Combine(_environment.WebRootPath, "Images", "Small_Dorms","CalhounLarge.jpg");
            if (System.IO.File.Exists(imagePath))
            {

                var fileStream = System.IO.File.OpenRead(imagePath);
                dorm.Image = File(fileStream, "image/jpeg");
            }
            
        }

        return smallDorms;
    }
}