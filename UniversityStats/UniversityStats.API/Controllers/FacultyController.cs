using UniversityStats.API.Dto;
using UniversityStats.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UniversityStats.API.Controllers;

/// <summary>
/// Controller responsible for managing faculty-related operations in the university statistics system.
/// Provides endpoints for retrieving, creating, updating, and deleting faculty information.
/// </summary>
/// <param name="service">An instance of IFacultyService used for performing faculty-related business logic.</param>
[Route("api/[controller]")]
[ApiController]
public class FacultyController(IFacultyService service) : ControllerBase
{
    /// <summary>
    /// Retrieves a list of all faculties in the system.
    /// </summary>
    /// <returns>An HTTP 200 OK response containing a collection of faculty data transfer objects.</returns>
    /// <response code="200">Successfully retrieved the list of faculties.</response>
    [HttpGet]
    public ActionResult<IEnumerable<FacultyDto>> Get()
    {
        return Ok(service.GetAll());
    }

    /// <summary>
    /// Retrieves a specific faculty by its unique identifier.
    /// </summary>
    /// <param name="facultyId">The unique identifier of the faculty to retrieve.</param>
    /// <returns>An HTTP response containing the faculty details or a not found status.</returns>
    /// <response code="200">Successfully retrieved the faculty details.</response>
    /// <response code="204">No faculty found with the specified identifier.</response>
    [HttpGet("{facultyId}")]
    public ActionResult<FacultyDto> Get(string facultyId)
    {
        var faculty = service.GetById(facultyId);

        if (faculty == null)
            return NoContent();

        return Ok(faculty);
    }

    /// <summary>
    /// Adds a new faculty to the university statistics database.
    /// </summary>
    /// <param name="faculty">The faculty data transfer object containing faculty information.</param>
    /// <returns>An HTTP response with the created faculty details.</returns>
    /// <response code="200">Successfully added the new faculty.</response>
    [HttpPost]
    public ActionResult<FacultyDto> Post([FromBody] FacultyDto faculty)
    {
        service.Post(faculty);
        
        return Ok(faculty);
    }

    /// <summary>
    /// Corrects faculty's information in the university statistics database.
    /// </summary>
    /// <param name="faculty">The faculty data transfer object containing updated faculty information.</param>
    /// <returns>An HTTP response indicating whether the update was successful.</returns>
    /// <response code="200">Successfully updated the faculty information.</response>
    [HttpPut]
    public ActionResult<FacultyDto> Put([FromBody] FacultyDto faculty)
    {
        service.Put(faculty);

        return Ok(faculty);
    }

    /// <summary>
    /// Deletes a faculty's information from the university statistics database.
    /// </summary>
    /// <param name="facultyId">The unique identifier of the faculty to delete.</param>
    /// <returns>An HTTP response indicating whether the deletion was successful.</returns>
    /// <response code="200">Successfully deleted the faculty.</response>
    [HttpDelete("{facultyId}")]
    public ActionResult<string> Delete(string facultyId)
    {
        service.Delete(facultyId);

        return Ok(facultyId);
    }
}
