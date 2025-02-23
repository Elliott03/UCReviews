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
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly ILogger<CourseController> _logger;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        private readonly PaginationSettings _paginationSettings;

        public CourseController(ICourseService courseService, ILogger<CourseController> logger, IMapper mapper, IWebHostEnvironment environment, IOptions<PaginationSettings> paginationSettings)
        {
            _courseService = courseService;
            _logger = logger;
            _mapper = mapper;
            _environment = environment;
            _paginationSettings = paginationSettings.Value;
        }

        [HttpGet]
        public async Task<ActionResult<List<Course>>> GetCourses(
            [FromQuery] int prev = 0, 
            [FromQuery] int? perPage = null, 
            [FromQuery] string? searchTerm = null)
        {
            perPage ??= _paginationSettings.DefaultPerPage;
            var courses = await _courseService.GetCourses(prev, (int)perPage, searchTerm);
            return Ok(courses);
        }

        [HttpGet("{slug}")]
        public async Task<ActionResult<Course>> GetCourse(string slug)
        {
            var course = await _courseService.GetCourse(slug);
            return ResolveCourse(course);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var course = await _courseService.GetCourse(id);
            return ResolveCourse(course);
        }

        [HttpPost]
        public async Task<ActionResult<Course>> SaveCourse(Course course)
        {
            await _courseService.SaveCourse(course);
            return CreatedAtAction(nameof(GetCourse), new { id = course.Id }, course);
        }

        private ActionResult<Course> ResolveCourse(Course course) 
        {
            if (course is not null) {
                return Ok(course);
            }
            return NotFound();
        }
    }
}
