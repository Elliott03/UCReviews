using api.Models;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.Implementations;

public class BuildingRepository : IBuildingRepository
{
    private readonly UCReviewsContext _dbContext;
    public BuildingRepository(UCReviewsContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Building>> GetAllBuildings()
    {
        return await _dbContext.Building.ToListAsync();
    }

    public async Task<Building> GetBuilding(string queryParam)
    {
        return await _dbContext.Building.Include(b => b.Reviews).ThenInclude(r => r.User).Where(b => b.NameQueryParameter == queryParam).FirstOrDefaultAsync();
    }

    public async Task<Building> GetBuildingById(int id) 
    {
        return await _dbContext.Building.Include(b => b.Reviews).Where(b => b.Id == id).FirstOrDefaultAsync();
    }
    public async Task SetBuildingRating(decimal average, int id) 
    {
        Building building = await _dbContext.Building.Where(b => b.Id == id).FirstOrDefaultAsync();
        building.AverageRating = average;
        await _dbContext.SaveChangesAsync();
    }
}