namespace api.Services.Interfaces;
using api.Models;

public interface IBuildingService
{
    public Task<IEnumerable<Building>> GetBuildings();
    public Task<Building> GetBuilding(string queryParam);
    public Task SetBuildingRating(int buildingId);
}