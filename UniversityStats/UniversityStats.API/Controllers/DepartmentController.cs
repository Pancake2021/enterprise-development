using UniversityStats.API.Dto;
using UniversityStats.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UniversityStats.API.Controllers;

/// <summary>
/// Controller responsible for managing department-related operations in the university statistics system.
/// Provides endpoints for retrieving, creating, updating, and deleting department information.
/// </summary>
/// <param name="service">An instance of IDepartmentService used for performing department-related business logic.</param>
[Route("api/[controller]")]
[ApiController]
public class DepartmentController(IDepartmentService service) : ControllerBase
{
    /// <summary>
    /// Retrieves a list of all departments in the university system.
    /// </summary>
    /// <returns>An HTTP 200 OK response containing a collection of department data transfer objects.</returns>
    /// <response code="200">Successfully retrieved the list of departments.</response>
    [HttpGet]
    public IActionResult GetAll() => Ok(service.GetAll());

    /// <summary>
    /// Retrieves a specific department by its registration number.
    /// </summary>
    /// <param name="registrationNumber">The registration number of the department to retrieve.</param>
    /// <returns>An HTTP response containing the department details or a not found status.</returns>
    /// <response code="200">Successfully retrieved the department details.</response>
    /// <response code="404">No department found with the specified registration number.</response>
    [HttpGet("{registrationNumber}")]
    public IActionResult GetByRegistrationNumber(string registrationNumber)
    {
        var department = service.GetByRegistrationNumber(registrationNumber);
        return department != null ? Ok(department) : NotFound();
    }

    /// <summary>
    /// Adds a new department to the university statistics database.
    /// </summary>
    /// <param name="department">The department data transfer object containing department information.</param>
    /// <returns>An HTTP response with the created department details.</returns>
    /// <response code="201">Successfully added the new department.</response>
    [HttpPost]
    public IActionResult Post([FromBody] DepartmentDto department)
    {
        service.Post(department);
        return CreatedAtAction(nameof(GetByRegistrationNumber), new { registrationNumber = department.RegistrationNumber }, department);
    }

    /// <summary>
    /// Corrects department's information in the university statistics database.
    /// </summary>
    /// <param name="department">The department data transfer object containing updated department information.</param>
    /// <returns>An HTTP response indicating whether the update was successful.</returns>
    /// <response code="204">Successfully updated the department information.</response>
    [HttpPut]
    public IActionResult Put([FromBody] DepartmentDto department)
    {
        service.Put(department);
        return NoContent();
    }

    /// <summary>
    /// Deletes a department's information from the university statistics database.
    /// </summary>
    /// <param name="registrationNumber">The registration number of the department to delete.</param>
    /// <returns>An HTTP response indicating whether the deletion was successful.</returns>
    /// <response code="204">Successfully deleted the department.</response>
    [HttpDelete("{registrationNumber}")]
    public IActionResult Delete(string registrationNumber)
    {
        service.Delete(registrationNumber);
        return NoContent();
    }
}
