namespace api.Repositories.Interfaces;

using api.Models;

public interface IDiningHallRepository
{
    Task<IEnumerable<DiningHall>> GetDiningHalls(int prev, int perPage, string? searchTerm = null);
    Task<DiningHall> GetDiningHall(string slug);
}