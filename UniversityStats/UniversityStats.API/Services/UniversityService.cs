using UniversityStats.Infrastructure.Entities;
using UniversityStats.Infrastructure.Repositories.Interfaces;

namespace UniversityStats.API.Services;

/// <summary>
/// Class for university's service
/// </summary>
public class UniversityService
{
    private readonly IUniversityRepository _universityRepository;

    /// <summary>
    /// Constructor for UniversityService
    /// </summary>
    /// <param name="universityRepository">University's repository</param>
    public UniversityService(IUniversityRepository universityRepository)
    {
        _universityRepository = universityRepository;
    }

    /// <summary>
    /// Method get university by id
    /// </summary>
    /// <param name="id">University's id</param>
    /// <returns>University's information or null</returns>
    public async Task<University?> GetUniversityByIdAsync(int id)
    {
        return await _universityRepository.GetByIdAsync(id);
    }

    /// <summary>
    /// Method get list of universities
    /// </summary>
    /// <returns>List of universities</returns>
    public async Task<IEnumerable<University>> GetAllUniversitiesAsync()
    {
        return await _universityRepository.GetAllAsync();
    }

    /// <summary>
    /// Method post university to database
    /// </summary>
    /// <param name="university">University's information</param>
    /// <returns>University's information</returns>
    public async Task<University> CreateUniversityAsync(University university)
    {
        return await _universityRepository.AddAsync(university);
    }

    /// <summary>
    /// Method update university
    /// </summary>
    /// <param name="university">University's information</param>
    /// <returns>University's information</returns>
    public async Task<University> UpdateUniversityAsync(University university)
    {
        return await _universityRepository.UpdateAsync(university);
    }

    /// <summary>
    /// Method delete university
    /// </summary>
    /// <param name="id">University's id</param>
    /// <returns>True if deleted, false otherwise</returns>
    public async Task<bool> DeleteUniversityAsync(int id)
    {
        return await _universityRepository.DeleteAsync(id);
    }
}
