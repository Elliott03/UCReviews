using api.Models;

namespace api.Services.Interfaces;
public interface ICourseService
{
    public Task<IEnumerable<Course>> GetCourses(int prev, int perPage);
    public Task<Course> GetCourse(int id);
    public Task<Course> GetCourse(string slug);
    public Task SaveCourse(Course course);
}
