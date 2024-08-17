using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PartsWarehouse.Core;

namespace PartsWarehouse.Infrastructure
{
    public class PartRepository : IPartRepository
    {
        private readonly PartsWarehouseDbContext _context;

        public PartRepository(PartsWarehouseDbContext context)
        {
            _context = context;
        }

        public async Task<Part> GetByIdAsync(int id)
        {
            return await _context.Parts.FindAsync(id);
        }

        public async Task<IEnumerable<Part>> GetAllAsync()
        {
            return await _context.Parts.ToListAsync();
        }

        public async Task AddAsync(Part part)
        {
            await _context.Parts.AddAsync(part);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Part part)
        {
            _context.Parts.Update(part);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var part = await _context.Parts.FindAsync(id);
            if (part != null)
            {
                _context.Parts.Remove(part);
                await _context.SaveChangesAsync();
            }
        }
    }
}
