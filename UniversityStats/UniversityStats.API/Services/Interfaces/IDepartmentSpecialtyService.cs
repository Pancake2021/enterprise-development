using UniversityStats.API.Dto;

namespace UniversityStats.API.Services.Interfaces;

public interface IDepartmentSpecialtyService
{
    /// <summary>
    /// Retrieves all department specialties
    /// </summary>
    /// <returns>Collection of department specialties</returns>
    IEnumerable<DepartmentSpecialtyDto> GetAll();

    /// <summary>
    /// Retrieves a department specialty by its ID
    /// </summary>
    /// <param name="departmentSpecialtyId">Unique identifier of the department specialty</param>
    /// <returns>Department specialty details or null</returns>
    DepartmentSpecialtyDto GetById(string departmentSpecialtyId);

    /// <summary>
    /// Adds a new department specialty
    /// </summary>
    /// <param name="departmentSpecialty">Department specialty details</param>
    void Post(DepartmentSpecialtyDto departmentSpecialty);

    /// <summary>
    /// Updates an existing department specialty
    /// </summary>
    /// <param name="departmentSpecialty">Updated department specialty details</param>
    void Put(DepartmentSpecialtyDto departmentSpecialty);

    /// <summary>
    /// Deletes a department specialty
    /// </summary>
    /// <param name="departmentSpecialtyId">Unique identifier of the department specialty to delete</param>
    void Delete(string departmentSpecialtyId);
}
