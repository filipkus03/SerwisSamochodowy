using SerwisMotoryzacyjny.Domain.Entities;

namespace SerwisMotoryzacyjny.Domain.Interfaces
{
    public interface IPricingRepository
    {
        // Metody CRUD dla cen
        Task<IEnumerable<Pricing>> GetAllPricingsAsync();
        Task<Pricing> GetPricingByIdAsync(int id);
        Task AddPricingAsync(Pricing pricing);
        Task UpdatePricingAsync(Pricing pricing);
        Task DeletePricingAsync(int id);
    }
}
