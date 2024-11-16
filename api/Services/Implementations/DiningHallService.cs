
public class DiningHallService : IDiningHallService
{

    private readonly IDiningHallRepository _repository;

    public DiningHallService(IDiningHallRepository repository)
    {
        _repository = repository;
    }
    public async Task<DiningHall> GetDiningHall(string queryParam)
    {
        return await _repository.GetDiningHall(queryParam);
    }

    public async Task<IEnumerable<DiningHall>> GetDiningHalls(int prev, int perPage)
    {
        return await _repository.GetDiningHalls(prev, perPage);
    }
}