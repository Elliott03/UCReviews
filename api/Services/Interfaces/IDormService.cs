namespace api.Services.Interfaces;
using api.Models;

public interface IDormService
{
    public Task<IEnumerable<Dorm>> GetDorms();
    public Task<Dorm> GetDorm(string queryParam);
    public Task SetDormRating(int dormId);
}