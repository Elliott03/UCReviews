namespace api.Repositories.Interfaces;

using api.Models;

public interface IDiningHallRepository
{
    public Task<IEnumerable<DiningHall>> GetDiningHalls(int prev, int perPage);
    public Task<DiningHall> GetDiningHall(string slug);
}