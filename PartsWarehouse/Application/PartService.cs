using System.Collections.Generic;
using System.Threading.Tasks;
using PartsWarehouse.Core;

namespace PartsWarehouse.Application
{
    public class PartService
    {
        private readonly IPartRepository _partRepository;

        public PartService(IPartRepository partRepository)
        {
            _partRepository = partRepository;
        }

        public async Task<Part> GetByIdAsync(int id)
        {
            return await _partRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Part>> GetAllAsync()
        {
            return await _partRepository.GetAllAsync();
        }

        public async Task AddAsync(Part part)
        {
            await _partRepository.AddAsync(part);
        }

        public async Task UpdateAsync(Part part)
        {
            await _partRepository.UpdateAsync(part);
        }

        public async Task DeleteAsync(int id)
        {
            await _partRepository.DeleteAsync(id);
        }
    }
}
