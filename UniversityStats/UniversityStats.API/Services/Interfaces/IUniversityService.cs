using UniversityStats.API.Dto;

namespace UniversityStats.API.Services.Interfaces;

public interface IUniversityService
{
    /// <summary>
    /// Method get list of universities
    /// </summary>
    /// <returns>List of universities</returns>
    IEnumerable<UniversityDto> GetAll();

    /// <summary>
    /// Method get university by registration number
    /// </summary>
    /// <param name="registrationNumber">Registration number</param>
    /// <returns>University's information or null</returns>
    UniversityDto? GetByRegistrationNumber(string registrationNumber);

    /// <summary>
    /// Method post university to database
    /// </summary>
    /// <param name="university">University's information</param>
    void Post(UniversityDto university);

    /// <summary>
    /// Method put university by registration number
    /// </summary>
    /// <param name="university">University's information</param>
    void Put(UniversityDto university);

    /// <summary>
    /// Method delete university by registration number
    /// </summary>
    /// <param name="registrationNumber">Registration number</param>
    void Delete(string registrationNumber);
}
