using UniversityStats.API.Dto;
using UniversityStats.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UniversityStats.API.Controllers;

/// <summary>
/// Controller responsible for managing specialty-related operations in the university statistics system.
/// Provides endpoints for retrieving, creating, updating, and deleting specialty information.
/// </summary>
/// <param name="service">An instance of ISpecialtyService used for performing specialty-related business logic.</param>
[Route("api/[controller]")]
[ApiController]
public class SpecialtyController(ISpecialtyService service) : ControllerBase
{
    /// <summary>
    /// Retrieves a list of all specialties in the system.
    /// </summary>
    /// <returns>An HTTP 200 OK response containing a collection of specialty data transfer objects.</returns>
    /// <response code="200">Successfully retrieved the list of specialties.</response>
    [HttpGet]
    public ActionResult<IEnumerable<SpecialtyDto>> Get()
    {
        return Ok(service.GetAll());
    }

    /// <summary>
    /// Retrieves a specific specialty by its unique identifier.
    /// </summary>
    /// <param name="specialtyId">The unique identifier of the specialty to retrieve.</param>
    /// <returns>An HTTP response containing the specialty details or a not found status.</returns>
    /// <response code="200">Successfully retrieved the specialty details.</response>
    /// <response code="204">No specialty found with the specified identifier.</response>
    [HttpGet("{specialtyId}")]
    public ActionResult<SpecialtyDto> Get(string specialtyId)
    {
        var specialty = service.GetById(specialtyId);

        if (specialty == null)
            return NoContent();

        return Ok(specialty);
    }

    /// <summary>
    /// Adds a new specialty to the university statistics database.
    /// </summary>
    /// <param name="specialty">The specialty data transfer object containing specialty information.</param>
    /// <returns>An HTTP response with the created specialty details.</returns>
    /// <response code="200">Successfully added the new specialty.</response>
    [HttpPost]
    public ActionResult<SpecialtyDto> Post([FromBody] SpecialtyDto specialty)
    {
        service.Post(specialty);
        
        return Ok(specialty);
    }

    /// <summary>
    /// Corrects specialty's information in the university statistics database.
    /// </summary>
    /// <param name="specialty">The specialty data transfer object containing updated specialty information.</param>
    /// <returns>An HTTP response indicating whether the update was successful.</returns>
    /// <response code="200">Successfully updated the specialty information.</response>
    [HttpPut]
    public ActionResult<SpecialtyDto> Put([FromBody] SpecialtyDto specialty)
    {
        service.Put(specialty);

        return Ok(specialty);
    }

    /// <summary>
    /// Deletes a specialty's information from the university statistics database.
    /// </summary>
    /// <param name="specialtyId">The unique identifier of the specialty to delete.</param>
    /// <returns>An HTTP response indicating whether the deletion was successful.</returns>
    /// <response code="200">Successfully deleted the specialty.</response>
    [HttpDelete("{specialtyId}")]
    public ActionResult<string> Delete(string specialtyId)
    {
        service.Delete(specialtyId);

        return Ok(specialtyId);
    }
}
