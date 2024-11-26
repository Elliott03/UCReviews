namespace api.Services.Implementations;

using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Repositories.Interfaces;
using api.Services.Interfaces;
using AutoMapper;

public class DormService : IDormService
{
    private readonly IDormRepository _repository;

    public DormService(IDormRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Dorm>> GetDorms(int prev, int perPage)
    {
        var dorms = await _repository.GetDorms(prev, perPage);
        return dorms;
    }

    public async Task<Dorm> GetDorm(string queryParam)
    {
        var dorm = await _repository.GetDorm(queryParam);
        return dorm;
    }

    public Task<Dorm> GetDorm(int id)
    {
        return _repository.GetDorm(id);
    }
}
