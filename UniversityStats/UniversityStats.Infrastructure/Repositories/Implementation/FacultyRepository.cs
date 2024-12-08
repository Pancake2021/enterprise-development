using Microsoft.EntityFrameworkCore;
using UniversityStats.Infrastructure.Data;
using UniversityStats.Infrastructure.Entities;
using UniversityStats.Infrastructure.Repositories.Interfaces;

namespace UniversityStats.Infrastructure.Repositories.Implementation;

public class FacultyRepository : IFacultyRepository
{
    private readonly UniversityStatsContext _context;

    public FacultyRepository(UniversityStatsContext context)
    {
        _context = context;
    }

    public async Task<Faculty> AddAsync(Faculty faculty)
    {
        await _context.Faculties.AddAsync(faculty);
        await _context.SaveChangesAsync();
        return faculty;
    }

    public async Task<Faculty> UpdateAsync(Faculty faculty)
    {
        _context.Faculties.Update(faculty);
        await _context.SaveChangesAsync();
        return faculty;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var faculty = await _context.Faculties.FindAsync(id);
        if (faculty == null) return false;

        _context.Faculties.Remove(faculty);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Faculty?> GetByIdAsync(int id)
    {
        return await _context.Faculties
            .Include(f => f.Department)
            .Include(f => f.Specialties)
            .FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<IEnumerable<Faculty>> GetAllAsync()
    {
        return await _context.Faculties
            .Include(f => f.Department)
            .Include(f => f.Specialties)
            .ToListAsync();
    }
}
