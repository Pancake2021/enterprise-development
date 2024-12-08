using Microsoft.EntityFrameworkCore;
using UniversityStats.Infrastructure.Data;
using UniversityStats.Infrastructure.Entities;
using UniversityStats.Infrastructure.Repositories.Interfaces;

namespace UniversityStats.Infrastructure.Repositories.Implementation;

public class UniversityRepository : IUniversityRepository
{
    private readonly UniversityStatsContext _context;

    public UniversityRepository(UniversityStatsContext context)
    {
        _context = context;
    }

    public async Task<University> AddAsync(University university)
    {
        await _context.Universities.AddAsync(university);
        await _context.SaveChangesAsync();
        return university;
    }

    public async Task<University> UpdateAsync(University university)
    {
        _context.Universities.Update(university);
        await _context.SaveChangesAsync();
        return university;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var university = await _context.Universities.FindAsync(id);
        if (university == null) return false;

        _context.Universities.Remove(university);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<University?> GetByIdAsync(int id)
    {
        return await _context.Universities
            .Include(u => u.Departments)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<IEnumerable<University>> GetAllAsync()
    {
        return await _context.Universities
            .Include(u => u.Departments)
            .ToListAsync();
    }
}
