using api.Models;
using api.Repositories.Interfaces;
using api.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;

namespace api.Repositories.Implementations;

public class CourseRepository : ICourseRepository
{
    private readonly UCReviewsContext _dbContext;
    private readonly PaginationSettings _paginationSettings;

    public CourseRepository(UCReviewsContext dbContext, IOptions<PaginationSettings> paginationSettings)
    {
        _dbContext = dbContext;
        _paginationSettings = paginationSettings.Value;
    }

    public async Task SaveCourse(Course course)
    {
        await _dbContext.AddAsync(course);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Course> GetCourse(int id)
    {
        return await HandleGetCourse(c => c.Id == id);
    }

    public async Task<Course> GetCourse(string slug)
    {
        return await HandleGetCourse(c => c.NameQueryParameter == slug);
    }

    public async Task<IEnumerable<Course>> GetCourses(int prev, int perPage, string? searchTerm = null)
    {
        var query = _dbContext.Course.AsQueryable();
        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            query = query.Where(c => c.Name.Contains(searchTerm));
        }
        perPage = Math.Min(perPage, _paginationSettings.MaxPerPage);
        query = query.Where(c => c.Id > prev).Take(perPage);
        query = query.Include(c => c.ReviewSummary);
        return await query.ToListAsync();
    }

    private async Task<Course> HandleGetCourse(Expression<Func<Course, bool>> predicate)
    {
        var query = _dbContext.Course.AsQueryable();
        query = query.Include(c => c.ReviewSummary);
        return await query.Where(predicate).FirstOrDefaultAsync();
    }
}
