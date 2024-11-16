using System;
using api.Models;
using api.Repositories.Interfaces;
using api.Services.Interfaces;

namespace api.Services.Implementations;

public class ParkingGarageService : IParkingGarageService
{
    private readonly IParkingGarageRepository _parkingGarageRepository;

    public ParkingGarageService(IParkingGarageRepository parkingGarageRepository)
    {
        _parkingGarageRepository = parkingGarageRepository;
    }

    public async Task<ParkingGarage> GetParkingGarage(string slug, bool includeReviews)
    {
        return await _parkingGarageRepository.GetParkingGarage(slug, includeReviews);
    }

    public async Task<ParkingGarage> GetParkingGarage(int id, bool includeReviews)
    {
        return await _parkingGarageRepository.GetParkingGarage(id, includeReviews);
    }

    public async Task<IEnumerable<ParkingGarage>> GetParkingGarages(bool includeReviews, int prev, int perPage)
    {
        return await _parkingGarageRepository.GetParkingGarages(includeReviews, prev, perPage);
    }
}
