using SerwisMotoryzacyjny.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SerwisMotoryzacyjny.Domain.Interfaces
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllAsync();
        Task<Contact> GetByIdAsync(int id);
        Task AddAsync(Contact contact);
        Task UpdateAsync(Contact contact);
        Task DeleteAsync(int id);
    }
}
