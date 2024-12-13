using UniversityStats.API.Dto;

namespace UniversityStats.API.Services.Interfaces;

public interface IQueryService
{
    UniversityDto? InfoUniversityByRegistration(string registrationNumber);

    IEnumerable<UniversityAndDepartmentsDto> TotalDepartmentsInUniversity();

    IEnumerable<SpecialtyAndGroupsDto> TopFiveSpecialties();

    IEnumerable<PropertyAndGroupsDto> TotalGroupsByProperty(string propertyType);

    IEnumerable<FacultyAndSpecialtyDto> InfoFacultiesSpecialties(string nameUniversity);

    IEnumerable<PropertyAndBuildingDto> TotalDepartmentsFacultiesSpecialtiesByPropertyBuilding();

    /// <summary>
    /// Retrieves universities by search query
    /// </summary>
    /// <param name="query">Search query string</param>
    /// <returns>Collection of universities matching the query</returns>
    IEnumerable<UniversityDto> SearchUniversities(string query);

    /// <summary>
    /// Retrieves departments by search query
    /// </summary>
    /// <param name="query">Search query string</param>
    /// <returns>Collection of departments matching the query</returns>
    IEnumerable<DepartmentDto> SearchDepartments(string query);

    /// <summary>
    /// Retrieves faculties by search query
    /// </summary>
    /// <param name="query">Search query string</param>
    /// <returns>Collection of faculties matching the query</returns>
    IEnumerable<FacultyDto> SearchFaculties(string query);

    /// <summary>
    /// Retrieves specialties by search query
    /// </summary>
    /// <param name="query">Search query string</param>
    /// <returns>Collection of specialties matching the query</returns>
    IEnumerable<SpecialtyDto> SearchSpecialties(string query);
}
