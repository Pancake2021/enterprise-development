using Microsoft.EntityFrameworkCore;
using UniversityStats.Infrastructure.Data;
using UniversityStats.Infrastructure.Entities;
using UniversityStats.Infrastructure.Repositories.Interfaces;

namespace UniversityStats.Infrastructure.Repositories.Implementation;

public class SpecialtyRepository : ISpecialtyRepository
{
    private readonly UniversityStatsContext _context;

    public SpecialtyRepository(UniversityStatsContext context)
    {
        _context = context;
    }

    public async Task<Specialty> AddAsync(Specialty specialty)
    {
        await _context.Specialties.AddAsync(specialty);
        await _context.SaveChangesAsync();
        return specialty;
    }

    public async Task<Specialty> UpdateAsync(Specialty specialty)
    {
        _context.Specialties.Update(specialty);
        await _context.SaveChangesAsync();
        return specialty;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var specialty = await _context.Specialties.FindAsync(id);
        if (specialty == null) return false;

        _context.Specialties.Remove(specialty);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Specialty?> GetByIdAsync(int id)
    {
        return await _context.Specialties
            .Include(s => s.Faculty)
            .Include(s => s.Groups)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<IEnumerable<Specialty>> GetAllAsync()
    {
        return await _context.Specialties
            .Include(s => s.Faculty)
            .Include(s => s.Groups)
            .ToListAsync();
    }
}
