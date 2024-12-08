using Microsoft.EntityFrameworkCore;
using UniversityStats.Infrastructure.Data;
using UniversityStats.Infrastructure.Entities;
using UniversityStats.Infrastructure.Repositories.Interfaces;

namespace UniversityStats.Infrastructure.Repositories.Implementation;

public class GroupRepository : IGroupRepository
{
    private readonly UniversityStatsContext _context;

    public GroupRepository(UniversityStatsContext context)
    {
        _context = context;
    }

    public async Task<Group> AddAsync(Group group)
    {
        await _context.Groups.AddAsync(group);
        await _context.SaveChangesAsync();
        return group;
    }

    public async Task<Group> UpdateAsync(Group group)
    {
        _context.Groups.Update(group);
        await _context.SaveChangesAsync();
        return group;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var group = await _context.Groups.FindAsync(id);
        if (group == null) return false;

        _context.Groups.Remove(group);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Group?> GetByIdAsync(int id)
    {
        return await _context.Groups
            .Include(g => g.Specialty)
            .FirstOrDefaultAsync(g => g.Id == id);
    }

    public async Task<IEnumerable<Group>> GetAllAsync()
    {
        return await _context.Groups
            .Include(g => g.Specialty)
            .ToListAsync();
    }
}
