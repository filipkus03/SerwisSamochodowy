using SerwisMotoryzacyjny.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SerwisMotoryzacyjny.Domain.Interfaces
{
    public interface IPartRepository
    {
        Task<IEnumerable<Part>> GetAllPartsAsync();     // Pobranie wszystkich części
        Task<Part> GetPartByIdAsync(int id);            // Pobranie części po ID
        Task AddPartAsync(Part part);                   // Dodanie nowej części
        Task UpdatePartAsync(Part part);                // Aktualizacja istniejącej części
        Task DeletePartAsync(int id);                   // Usunięcie części po ID
    }
}
