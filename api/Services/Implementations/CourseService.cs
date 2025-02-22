using api.Models;
using api.Repositories.Interfaces;
using api.Services.Interfaces;

namespace api.Services.Implementations;
public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;

    public CourseService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<Course> GetCourse(int id)
    {
        return await _courseRepository.GetCourse(id);
    }

    public async Task<Course> GetCourse(string slug)
    {
        return await _courseRepository.GetCourse(slug);
    }

    public async Task<IEnumerable<Course>> GetCourses(int prev, int perPage, string? searchTerm)
    {
        return await _courseRepository.GetCourses(prev, perPage, searchTerm);
    }

    public async Task SaveCourse(Course course)
    {
        await _courseRepository.SaveCourse(course);
    }
}
