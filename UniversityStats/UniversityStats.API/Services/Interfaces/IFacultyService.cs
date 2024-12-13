using UniversityStats.API.Dto;

namespace UniversityStats.API.Services.Interfaces;

public interface IFacultyService
{
    /// <summary>
    /// Retrieves all faculties
    /// </summary>
    /// <returns>Collection of faculties</returns>
    IEnumerable<FacultyDto> GetAll();

    /// <summary>
    /// Retrieves a faculty by its ID
    /// </summary>
    /// <param name="facultyId">Unique identifier of the faculty</param>
    /// <returns>Faculty details or null</returns>
    FacultyDto GetById(string facultyId);

    /// <summary>
    /// Adds a new faculty
    /// </summary>
    /// <param name="faculty">Faculty details</param>
    void Post(FacultyDto faculty);

    /// <summary>
    /// Updates an existing faculty
    /// </summary>
    /// <param name="faculty">Updated faculty details</param>
    void Put(FacultyDto faculty);

    /// <summary>
    /// Deletes a faculty
    /// </summary>
    /// <param name="facultyId">Unique identifier of the faculty to delete</param>
    void Delete(string facultyId);
}
