using UniversityStats.Infrastructure.Entities;
using UniversityStats.Infrastructure.Repositories.Interfaces;

namespace UniversityStats.API.Services;

/// <summary>
/// Class for faculty's service
/// </summary>
public class FacultyService
{
    private readonly IFacultyRepository _facultyRepository;

    public FacultyService(IFacultyRepository facultyRepository)
    {
        _facultyRepository = facultyRepository;
    }

    /// <summary>
    /// Method get list of faculties
    /// </summary>
    /// <returns>List of faculties</returns>
    public async Task<IEnumerable<Faculty>> GetAllFacultiesAsync()
    {
        return await _facultyRepository.GetAllAsync();
    }

    /// <summary>
    /// Method get faculty by faculty's id
    /// </summary>
    /// <param name="id">Faculty's id</param>
    /// <returns>Faculty's information or null</returns>
    public async Task<Faculty?> GetFacultyByIdAsync(int id)
    {
        return await _facultyRepository.GetByIdAsync(id);
    }

    /// <summary>
    /// Method create faculty in database
    /// </summary>
    /// <param name="faculty">Faculty's information</param>
    public async Task<Faculty> CreateFacultyAsync(Faculty faculty)
    {
        return await _facultyRepository.AddAsync(faculty);
    }

    /// <summary>
    /// Method update faculty
    /// </summary>
    /// <param name="faculty">Faculty's information</param>
    public async Task<Faculty> UpdateFacultyAsync(Faculty faculty)
    {
        return await _facultyRepository.UpdateAsync(faculty);
    }

    /// <summary>
    /// Method delete faculty by faculty's id
    /// </summary>
    /// <param name="id">Faculty's id</param>
    /// <returns>True or False</returns>
    public async Task<bool> DeleteFacultyAsync(int id)
    {
        return await _facultyRepository.DeleteAsync(id);
    }
}
