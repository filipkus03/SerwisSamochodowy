using SerwisMotoryzacyjny.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SerwisMotoryzacyjny.Domain.Interfaces
{
    public interface IPartRepository
    {
        Task<IEnumerable<Part>> GetAllPartsAsync();
        Task<Part> GetPartByIdAsync(int id);
        Task AddPartAsync(Part part);
        Task UpdatePartAsync(Part part);
        Task DeletePartAsync(int id);
    }
}
