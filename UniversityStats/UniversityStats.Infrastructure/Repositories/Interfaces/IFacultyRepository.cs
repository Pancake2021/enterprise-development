using UniversityStats.Infrastructure.Entities;

namespace UniversityStats.Infrastructure.Repositories.Interfaces;

public interface IFacultyRepository
{
    Task<Faculty> AddAsync(Faculty faculty);
    Task<Faculty> UpdateAsync(Faculty faculty);
    Task<bool> DeleteAsync(int id);
    Task<Faculty?> GetByIdAsync(int id);
    Task<IEnumerable<Faculty>> GetAllAsync();
}
