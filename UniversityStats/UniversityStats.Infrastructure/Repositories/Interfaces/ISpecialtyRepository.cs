using UniversityStats.Infrastructure.Entities;

namespace UniversityStats.Infrastructure.Repositories.Interfaces;

public interface ISpecialtyRepository
{
    Task<Specialty> AddAsync(Specialty specialty);
    Task<Specialty> UpdateAsync(Specialty specialty);
    Task<bool> DeleteAsync(int id);
    Task<Specialty?> GetByIdAsync(int id);
    Task<IEnumerable<Specialty>> GetAllAsync();
}
