using api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Services.Interfaces
{
    public interface IDormService
    {
        Task<IEnumerable<Dorm>> GetDorms(int prev, int perPage, string? searchTerm = null);
        Task<Dorm> GetDorm(string slug);
        Task<Dorm> GetDorm(int id);
    }
}