
using api.Models;
using api.Repositories.Interfaces;

public class DiningHallService : IDiningHallService
{

    private readonly IDiningHallRepository _repository;

    public DiningHallService(IDiningHallRepository repository)
    {
        _repository = repository;
    }
    public async Task<DiningHall> GetDiningHall(string slug)
    {
        return await _repository.GetDiningHall(slug);
    }

    public async Task<IEnumerable<DiningHall>> GetDiningHalls(int prev, int perPage, string? searchTerm = null)
    {
    return await _repository.GetDiningHalls(prev, perPage, searchTerm); 
    }
}