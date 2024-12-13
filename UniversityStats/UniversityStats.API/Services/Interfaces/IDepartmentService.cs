using UniversityStats.API.Dto;

namespace UniversityStats.API.Services.Interfaces;

public interface IDepartmentService
{
    /// <summary>
    /// Method get list of departments
    /// </summary>
    /// <returns>List of departments</returns>
    IEnumerable<DepartmentDto> GetAll();

    /// <summary>
    /// Method get department by registration number
    /// </summary>
    /// <param name="registrationNumber">Department's registration number</param>
    /// <returns>Department's information or null</returns>
    DepartmentDto? GetByRegistrationNumber(string registrationNumber);

    /// <summary>
    /// Method post department to database
    /// </summary>
    /// <param name="department">Department's information</param>
    void Post(DepartmentDto department);

    /// <summary>
    /// Method put department by registration number
    /// </summary>
    /// <param name="department">Department's information</param>
    void Put(DepartmentDto department);

    /// <summary>
    /// Method delete department by registration number
    /// </summary>
    /// <param name="registrationNumber">Department's registration number</param>
    void Delete(string registrationNumber);
}
