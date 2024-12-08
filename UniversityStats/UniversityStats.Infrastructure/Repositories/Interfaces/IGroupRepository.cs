using UniversityStats.Infrastructure.Entities;

namespace UniversityStats.Infrastructure.Repositories.Interfaces;

public interface IGroupRepository
{
    Task<Group> AddAsync(Group group);
    Task<Group> UpdateAsync(Group group);
    Task<bool> DeleteAsync(int id);
    Task<Group?> GetByIdAsync(int id);
    Task<IEnumerable<Group>> GetAllAsync();
}
