
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

    public async Task<IEnumerable<DiningHall>> GetAllDiningHalls()
    {
        return await _repository.GetAllDiningHalls();
    }
}