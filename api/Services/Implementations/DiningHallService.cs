
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

    public async Task<IEnumerable<DiningHall>> GetDiningHalls(int prev, int perPage)
    {
        return await _repository.GetDiningHalls(prev, perPage);
    }
}