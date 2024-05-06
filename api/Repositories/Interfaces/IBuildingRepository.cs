namespace api.Repositories.Interfaces;
using api.Models;
public interface IBuildingRepository
{
    public Task<IEnumerable<Building>> GetAllBuildings();
    public Task<Building> GetBuilding(string queryParam);
    public Task<Building> GetBuildingById(int id);
    public Task SetBuildingRating(decimal average, int id);
}