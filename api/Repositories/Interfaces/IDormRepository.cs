namespace api.Repositories.Interfaces;

using api.Models;

public interface IDormRepository
{
    public Task<IEnumerable<Dorm>> GetDorms(int prev, int perPage);
    public Task<Dorm> GetDorm(string queryParam);
    public Task<Dorm> GetDormById(int id);
}