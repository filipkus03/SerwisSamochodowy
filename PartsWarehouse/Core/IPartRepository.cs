using System.Collections.Generic;
using System.Threading.Tasks;

namespace PartsWarehouse.Core
{
    public interface IPartRepository
    {
        Task<Part> GetByIdAsync(int id);
        Task<IEnumerable<Part>> GetAllAsync();
        Task AddAsync(Part part);
        Task UpdateAsync(Part part);
        Task DeleteAsync(int id);
    }
}
