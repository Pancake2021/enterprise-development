using UniversityStats.Infrastructure.Entities;

namespace UniversityStats.Infrastructure.Repositories.Interfaces;

public interface IUniversityRepository
{
    Task<University> AddAsync(University university);
    Task<University> UpdateAsync(University university);
    Task<bool> DeleteAsync(int id);
    Task<University?> GetByIdAsync(int id);
    Task<IEnumerable<University>> GetAllAsync();
}
