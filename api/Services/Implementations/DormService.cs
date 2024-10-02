using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Repositories.Interfaces;
using api.Services.Interfaces;
using AutoMapper;


namespace api.Services.Implementations;

public class DormService : IDormService
{
    private readonly IDormRepository _repository;

    public DormService(IDormRepository repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<Dorm>> GetDorms()
    {
        var dorms = await _repository.GetAllDorms();
        return dorms;
    }

    public async Task<Dorm> GetDorm(string queryParam)
    {
        var dorm = await _repository.GetDorm(queryParam);
        return dorm;
    }

    public async Task SetDormRating(int dormId) 
    {
        Dorm dorm = await _repository.GetDormById(dormId);
        List<Review> reviews = dorm.Reviews;
        decimal average = reviews.Average(r => r.StarRating);
        await _repository.SetDormRating(average, dorm.Id);
    }
}
