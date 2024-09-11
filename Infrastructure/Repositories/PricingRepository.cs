using SerwisMotoryzacyjny.Domain.Entities;
using SerwisMotoryzacyjny.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using SerwisMotoryzacyjny.Infrastructure.Data;

namespace SerwisMotoryzacyjny.Infrastructure.Repositories
{
    public class PricingRepository : IPricingRepository
    {
        private readonly AppDbContext _context;

        public PricingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pricing>> GetAllPricingsAsync()
        {
            return await _context.Pricings.ToListAsync();
        }

        public async Task<Pricing> GetPricingByIdAsync(int id)
        {
            return await _context.Pricings.FindAsync(id);
        }

        public async Task AddPricingAsync(Pricing pricing)
        {
            _context.Pricings.Add(pricing);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePricingAsync(Pricing pricing)
        {
            _context.Entry(pricing).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePricingAsync(int id)
        {
            var pricing = await _context.Pricings.FindAsync(id);
            if (pricing != null)
            {
                _context.Pricings.Remove(pricing);
                await _context.SaveChangesAsync();
            }
        }
    }
}
