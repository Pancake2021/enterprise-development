using UniversityStats.API.Dto;

namespace UniversityStats.API.Services.Interfaces;

public interface ISpecialtyService
{
    /// <summary>
    /// Retrieves all specialties
    /// </summary>
    /// <returns>Collection of specialties</returns>
    IEnumerable<SpecialtyDto> GetAll();

    /// <summary>
    /// Retrieves a specialty by its ID
    /// </summary>
    /// <param name="specialtyId">Unique identifier of the specialty</param>
    /// <returns>Specialty details or null</returns>
    SpecialtyDto GetById(string specialtyId);

    /// <summary>
    /// Adds a new specialty
    /// </summary>
    /// <param name="specialty">Specialty details</param>
    void Post(SpecialtyDto specialty);

    /// <summary>
    /// Updates an existing specialty
    /// </summary>
    /// <param name="specialty">Updated specialty details</param>
    void Put(SpecialtyDto specialty);

    /// <summary>
    /// Deletes a specialty
    /// </summary>
    /// <param name="specialtyId">Unique identifier of the specialty to delete</param>
    void Delete(string specialtyId);
}
