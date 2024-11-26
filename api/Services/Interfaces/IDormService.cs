using System;
using api.Models;

namespace api.Services.Interfaces;

public interface IDormService
{
    public Task<IEnumerable<Dorm>> GetDorms(int prev, int perPage);
    public Task<Dorm> GetDorm(int id);
    public Task<Dorm> GetDorm(string slug);
}
