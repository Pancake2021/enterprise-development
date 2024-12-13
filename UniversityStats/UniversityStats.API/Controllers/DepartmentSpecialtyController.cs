using UniversityStats.API.Dto;
using UniversityStats.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UniversityStats.API.Controllers;

/// <summary>
/// Controller responsible for managing department specialty-related operations in the university statistics system.
/// Provides endpoints for retrieving, creating, updating, and deleting department specialty information.
/// </summary>
/// <param name="service">An instance of IDepartmentSpecialtyService used for performing department specialty-related business logic.</param>
[Route("api/[controller]")]
[ApiController]
public class DepartmentSpecialtyController(IDepartmentSpecialtyService service) : ControllerBase
{
    /// <summary>
    /// Retrieves a list of all department specialties in the system.
    /// </summary>
    /// <returns>An HTTP 200 OK response containing a collection of department specialty data transfer objects.</returns>
    /// <response code="200">Successfully retrieved the list of department specialties.</response>
    [HttpGet]
    public ActionResult<IEnumerable<DepartmentSpecialtyDto>> Get()
    {
        return Ok(service.GetAll());
    }

    /// <summary>
    /// Retrieves a specific department specialty by its unique identifier.
    /// </summary>
    /// <param name="departmentSpecialtyId">The unique identifier of the department specialty to retrieve.</param>
    /// <returns>An HTTP response containing the department specialty details or a not found status.</returns>
    /// <response code="200">Successfully retrieved the department specialty details.</response>
    /// <response code="204">No department specialty found with the specified identifier.</response>
    [HttpGet("{departmentSpecialtyId}")]
    public ActionResult<DepartmentSpecialtyDto> Get(string departmentSpecialtyId)
    {
        var departmentSpecialty = service.GetById(departmentSpecialtyId);

        if (departmentSpecialty == null)
            return NoContent();

        return Ok(departmentSpecialty);
    }

    /// <summary>
    /// Adds a new department specialty to the university statistics database.
    /// </summary>
    /// <param name="departmentSpecialty">The department specialty data transfer object containing department specialty information.</param>
    /// <returns>An HTTP response with the created department specialty details.</returns>
    /// <response code="200">Successfully added the new department specialty.</response>
    [HttpPost]
    public ActionResult<DepartmentSpecialtyDto> Post([FromBody] DepartmentSpecialtyDto departmentSpecialty)
    {
        service.Post(departmentSpecialty);
        
        return Ok(departmentSpecialty);
    }

    /// <summary>
    /// Corrects department specialty's information in the university statistics database.
    /// </summary>
    /// <param name="departmentSpecialty">The department specialty data transfer object containing updated department specialty information.</param>
    /// <returns>An HTTP response indicating whether the update was successful.</returns>
    /// <response code="200">Successfully updated the department specialty information.</response>
    [HttpPut]
    public ActionResult<DepartmentSpecialtyDto> Put([FromBody] DepartmentSpecialtyDto departmentSpecialty)
    {
        service.Put(departmentSpecialty);

        return Ok(departmentSpecialty);
    }

    /// <summary>
    /// Deletes a department specialty's information from the university statistics database.
    /// </summary>
    /// <param name="departmentSpecialtyId">The unique identifier of the department specialty to delete.</param>
    /// <returns>An HTTP response indicating whether the deletion was successful.</returns>
    /// <response code="200">Successfully deleted the department specialty.</response>
    [HttpDelete("{departmentSpecialtyId}")]
    public ActionResult<string> Delete(string departmentSpecialtyId)
    {
        service.Delete(departmentSpecialtyId);

        return Ok("Department specialty was deleted");
    }
}
