using UniversityStats.API.Dto;
using UniversityStats.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UniversityStats.API.Controllers;

/// <summary>
/// Controller responsible for managing university-related operations in the university statistics system.
/// Provides endpoints for retrieving, creating, updating, and deleting university information.
/// </summary>
/// <param name="service">An instance of IUniversityService used for performing university-related business logic.</param>
[Route("api/[controller]")]
[ApiController]
public class UniversityController(IUniversityService service) : ControllerBase
{
    /// <summary>
    /// Retrieves a list of all universities in the system.
    /// </summary>
    /// <returns>An HTTP 200 OK response containing a collection of university data transfer objects.</returns>
    /// <response code="200">Successfully retrieved the list of universities.</response>
    [HttpGet]
    public ActionResult<IEnumerable<UniversityDto>> Get()
    {
        return Ok(service.GetAll());
    }

    /// <summary>
    /// Retrieves a specific university by its registration number.
    /// </summary>
    /// <param name="registrationNumber">The unique registration number of the university to retrieve.</param>
    /// <returns>An HTTP response containing the university details or a not found status.</returns>
    /// <response code="200">Successfully retrieved the university details.</response>
    /// <response code="204">No university found with the specified registration number.</response>
    [HttpGet("{registrationNumber}")]
    public ActionResult<UniversityDto> Get(string registrationNumber)
    {
        var university = service.GetByRegistrationNumber(registrationNumber);

        if (university == null)
            return NoContent();

        return Ok(university);
    }

    /// <summary>
    /// Adds a new university to the university statistics database.
    /// </summary>
    /// <param name="university">The university data transfer object containing university information.</param>
    /// <returns>An HTTP response with the created university details.</returns>
    /// <response code="200">Successfully added the new university.</response>
    [HttpPost]
    public ActionResult<UniversityDto> Post([FromBody] UniversityDto university)
    {
        service.Post(university);
        
        return Ok(university);
    }

    /// <summary>
    /// Corrects university's information in the university statistics database.
    /// </summary>
    /// <param name="university">The university data transfer object containing updated university information.</param>
    /// <returns>An HTTP response indicating whether the update was successful.</returns>
    /// <response code="200">Successfully updated the university information.</response>
    [HttpPut]
    public ActionResult<UniversityDto> Put([FromBody] UniversityDto university)
    {
        service.Put(university);

        return Ok(university);
    }

    /// <summary>
    /// Deletes a university's information from the university statistics database.
    /// </summary>
    /// <param name="registrationNumber">The unique registration number of the university to delete.</param>
    /// <returns>An HTTP response indicating whether the deletion was successful.</returns>
    /// <response code="200">Successfully deleted the university.</response>
    [HttpDelete("{registrationNumber}")]
    public ActionResult<string> Delete(string registrationNumber)
    {
        service.Delete(registrationNumber);

        return Ok(registrationNumber);
    }
}
