using System.Collections.Generic;
using System.Threading.Tasks;
using api.Models;

namespace api.Services.Interfaces;

public interface IParkingGarageService
{
    public Task<IEnumerable<ParkingGarage>> GetParkingGarages(int prev, int perPage, string? searchTerm = null);
    public Task<ParkingGarage> GetParkingGarage(int id);
    public Task<ParkingGarage> GetParkingGarage(string slug);
}