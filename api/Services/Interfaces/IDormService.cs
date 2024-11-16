namespace api.Services.Interfaces;

using api.Models;

public interface IDormService
{
    public Task<IEnumerable<Dorm>> GetDorms(int prev, int perPage);
    public Task<Dorm> GetDorm(string queryParam);
}