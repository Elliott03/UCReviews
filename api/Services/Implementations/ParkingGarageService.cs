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

    public async Task<ParkingGarage> GetParkingGarage(string slug)
    {
        return await _parkingGarageRepository.GetParkingGarage(slug);
    }

    public async Task<ParkingGarage> GetParkingGarage(int id)
    {
        return await _parkingGarageRepository.GetParkingGarage(id);
    }

    public async Task<IEnumerable<ParkingGarage>> GetParkingGarages(int prev, int perPage)
    {
        return await _parkingGarageRepository.GetParkingGarages(prev, perPage);
    }
}
