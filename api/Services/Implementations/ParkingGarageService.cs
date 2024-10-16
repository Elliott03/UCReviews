using System;
using api.Models;
using api.Services.Interfaces;

namespace api.Services.Implementations;

public class ParkingGarageService : IParkingGarageService
{
    private readonly IParkingGarageService _parkingGarageService;

    public async Task<ParkingGarage> GetParkingGarage(string slug)
    {
        return await _parkingGarageService.GetParkingGarage(slug);
    }

    public async Task<ParkingGarage> GetParkingGarageById(int id)
    {
        return await _parkingGarageService.GetParkingGarageById(id);
    }

    public async Task<IEnumerable<ParkingGarage>> GetParkingGarages()
    {
        return await _parkingGarageService.GetParkingGarages();
    }
}
