using UniversityStats.Infrastructure.Entities;

namespace UniversityStats.Infrastructure.Repositories.Interfaces;

public interface IDepartmentRepository
{
    Task<Department> AddAsync(Department department);
    Task<Department> UpdateAsync(Department department);
    Task<bool> DeleteAsync(int id);
    Task<Department?> GetByIdAsync(int id);
    Task<IEnumerable<Department>> GetAllAsync();
}
