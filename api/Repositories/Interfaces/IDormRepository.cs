using System;
using api.Models;

namespace api.Repositories.Interfaces;

public interface IDormRepository
{
    Task<IEnumerable<Dorm>> GetDorms(int prev, int perPage, string? searchTerm = null);
    Task<Dorm> GetDorm(string slug);
    Task<Dorm> GetDorm(int id);
}
