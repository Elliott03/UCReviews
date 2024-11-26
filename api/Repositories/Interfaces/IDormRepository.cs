using System;
using api.Models;

namespace api.Repositories.Interfaces;

public interface IDormRepository
{
    public Task<IEnumerable<Dorm>> GetDorms(int prev, int perPage);
    public Task<Dorm> GetDorm(string slug);
    public Task<Dorm> GetDorm(int id);
}
