using api.Models;

namespace api.Repositories.Interfaces;
public interface ICourseRepository
{
    public Task<IEnumerable<Course>> GetCourses(int prev, int perPage);
    public Task<Course> GetCourse(int id);
    public Task<Course> GetCourse(string slug);
    public Task SaveCourse(Course course);
}
