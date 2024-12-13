using Microsoft.AspNetCore.Mvc;
using UniversityStats.API.Dto;
using UniversityStats.API.Services.Interfaces;

namespace UniversityStats.API.Controllers;

/// <summary>
/// Controller responsible for managing search-related operations in the university statistics system.
/// Provides endpoints for searching universities, departments, faculties, and specialties.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class QueryController : ControllerBase
{
    private readonly IQueryService _service;

    public QueryController(IQueryService service)
    {
        _service = service;
    }

    /// <summary>
    /// Retrieves information about a university by its registration number.
    /// </summary>
    /// <param name="registrationNumber">Registration number of the university</param>
    /// <returns>An HTTP response containing information about the university.</returns>
    /// <response code="200">Successfully retrieved university information.</response>
    /// <response code="404">University not found.</response>
    [HttpGet("university-by-registration/{registrationNumber}")]
    public IActionResult InfoUniversityByRegistration(string registrationNumber)
    {
        var university = _service.InfoUniversityByRegistration(registrationNumber);
        return university != null ? Ok(university) : NotFound();
    }

    /// <summary>
    /// Retrieves the total number of departments in a university.
    /// </summary>
    /// <returns>An HTTP response containing the total number of departments.</returns>
    /// <response code="200">Successfully retrieved total departments.</response>
    [HttpGet("total-departments-in-university")]
    public IActionResult TotalDepartmentsInUniversity() => 
        Ok(_service.TotalDepartmentsInUniversity());

    /// <summary>
    /// Retrieves the top five specialties.
    /// </summary>
    /// <returns>An HTTP response containing the top five specialties.</returns>
    /// <response code="200">Successfully retrieved top five specialties.</response>
    [HttpGet("top-five-specialties")]
    public IActionResult TopFiveSpecialties() => 
        Ok(_service.TopFiveSpecialties());

    /// <summary>
    /// Retrieves the total number of groups by a specified property.
    /// </summary>
    /// <param name="propertyType">Type of property to filter by</param>
    /// <returns>An HTTP response containing the total number of groups.</returns>
    /// <response code="200">Successfully retrieved total groups.</response>
    [HttpGet("total-groups-by-property/{propertyType}")]
    public IActionResult TotalGroupsByProperty(string propertyType) => 
        Ok(_service.TotalGroupsByProperty(propertyType));

    /// <summary>
    /// Retrieves information about faculties and specialties for a specified university.
    /// </summary>
    /// <param name="nameUniversity">Name of the university</param>
    /// <returns>An HTTP response containing information about faculties and specialties.</returns>
    /// <response code="200">Successfully retrieved faculties and specialties information.</response>
    [HttpGet("faculties-specialties/{nameUniversity}")]
    public IActionResult InfoFacultiesSpecialties(string nameUniversity) => 
        Ok(_service.InfoFacultiesSpecialties(nameUniversity));

    /// <summary>
    /// Retrieves the total number of departments, faculties, and specialties by a specified property.
    /// </summary>
    /// <returns>An HTTP response containing the total number of departments, faculties, and specialties.</returns>
    /// <response code="200">Successfully retrieved total departments, faculties, and specialties.</response>
    [HttpGet("departments-faculties-specialties-by-property")]
    public IActionResult TotalDepartmentsFacultiesSpecialtiesByPropertyBuilding() => 
        Ok(_service.TotalDepartmentsFacultiesSpecialtiesByPropertyBuilding());

    /// <summary>
    /// Searches for universities based on a query string.
    /// </summary>
    /// <param name="query">Search query string</param>
    /// <returns>An HTTP response containing a collection of universities matching the query.</returns>
    /// <response code="200">Successfully retrieved matching universities.</response>
    [HttpGet("search-universities")]
    public IActionResult SearchUniversities([FromQuery] string query) => 
        Ok(_service.SearchUniversities(query));

    /// <summary>
    /// Searches for departments based on a query string.
    /// </summary>
    /// <param name="query">Search query string</param>
    /// <returns>An HTTP response containing a collection of departments matching the query.</returns>
    /// <response code="200">Successfully retrieved matching departments.</response>
    [HttpGet("search-departments")]
    public IActionResult SearchDepartments([FromQuery] string query) => 
        Ok(_service.SearchDepartments(query));

    /// <summary>
    /// Searches for faculties based on a query string.
    /// </summary>
    /// <param name="query">Search query string</param>
    /// <returns>An HTTP response containing a collection of faculties matching the query.</returns>
    /// <response code="200">Successfully retrieved matching faculties.</response>
    [HttpGet("search-faculties")]
    public IActionResult SearchFaculties([FromQuery] string query) => 
        Ok(_service.SearchFaculties(query));

    /// <summary>
    /// Searches for specialties based on a query string.
    /// </summary>
    /// <param name="query">Search query string</param>
    /// <returns>An HTTP response containing a collection of specialties matching the query.</returns>
    /// <response code="200">Successfully retrieved matching specialties.</response>
    [HttpGet("search-specialties")]
    public IActionResult SearchSpecialties([FromQuery] string query) => 
        Ok(_service.SearchSpecialties(query));
}
