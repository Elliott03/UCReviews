using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Repositories.Interfaces;
using api.Services.Interfaces;
using AutoMapper;


namespace api.Services.Implementations;

public class BuildingService : IBuildingService
{
    private readonly IBuildingRepository _repository;

    public BuildingService(IBuildingRepository repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<Building>> GetBuildings()
    {
        var buildings = await _repository.GetAllBuildings();
        return buildings;
    }

    public async Task<Building> GetBuilding(string queryParam)
    {
        var building = await _repository.GetBuilding(queryParam);
        return building;
    }

    public async Task SetBuildingRating(int buildingId) 
    {
        Building building = await _repository.GetBuildingById(buildingId);
        List<Review> reviews = building.Reviews;
        decimal average = reviews.Average(r => r.StarRating);
        await _repository.SetBuildingRating(average, building.Id);
    }
}
