using UniversityStats.Infrastructure.Entities;
using UniversityStats.Infrastructure.Repositories.Interfaces;

namespace UniversityStats.API.Services;

/// <summary>
/// Class for specialty's service
/// </summary>
public class SpecialtyService
{
    private readonly ISpecialtyRepository _specialtyRepository;

    public SpecialtyService(ISpecialtyRepository specialtyRepository)
    {
        _specialtyRepository = specialtyRepository;
    }

    /// <summary>
    /// Method get list of specialties
    /// </summary>
    /// <returns>List of specialties</returns>
    public async Task<IEnumerable<Specialty>> GetAllSpecialtiesAsync()
    {
        return await _specialtyRepository.GetAllAsync();
    }

    /// <summary>
    /// Method get specialty by specialty's id
    /// </summary>
    /// <param name="id">Specialty's id</param>
    /// <returns>Specialty's information or null</returns>
    public async Task<Specialty?> GetSpecialtyByIdAsync(int id)
    {
        return await _specialtyRepository.GetByIdAsync(id);
    }

    /// <summary>
    /// Method create specialty in database
    /// </summary>
    /// <param name="specialty">Specialty's information</param>
    public async Task<Specialty> CreateSpecialtyAsync(Specialty specialty)
    {
        return await _specialtyRepository.AddAsync(specialty);
    }

    /// <summary>
    /// Method update specialty
    /// </summary>
    /// <param name="specialty">Specialty's information</param>
    public async Task<Specialty> UpdateSpecialtyAsync(Specialty specialty)
    {
        return await _specialtyRepository.UpdateAsync(specialty);
    }

    /// <summary>
    /// Method delete specialty by specialty's id
    /// </summary>
    /// <param name="id">Specialty's id</param>
    /// <returns>True or False</returns>
    public async Task<bool> DeleteSpecialtyAsync(int id)
    {
        return await _specialtyRepository.DeleteAsync(id);
    }
}
