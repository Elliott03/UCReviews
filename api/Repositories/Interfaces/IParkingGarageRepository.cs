using System.Collections.Generic;
using System.Threading.Tasks;
using api.Models;

namespace api.Repositories.Interfaces;

public interface IParkingGarageRepository
{
    Task<IEnumerable<ParkingGarage>> GetParkingGarages(int prev, int perPage, string? searchTerm = null);
    Task<ParkingGarage> GetParkingGarage(int id);
    Task<ParkingGarage> GetParkingGarage(string slug);
}