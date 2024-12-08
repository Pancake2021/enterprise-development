using Microsoft.AspNetCore.Mvc;
using UniversityStats.API.Dto;
using UniversityStats.API.Services;

namespace UniversityStats.API.Controllers;

/// <summary>
/// Class for department's controller
/// </summary>
/// <param name="service">Department's service</param>
[Route("api/[controller]")]
[ApiController]
public class DepartmentController(DepartmentService service) : ControllerBase
{
    /// <summary>
    /// Return list of departments
    /// </summary>
    /// <returns> List of departments</returns>
    [HttpGet]
    public ActionResult<IEnumerable<DepartmentDto>> Get()
    {
        return Ok(service.GetAll());
    }

    /// <summary>
    /// Find department by department's id
    /// </summary>
    /// <param name="departmentId">Department's id</param>
    /// <returns>Department's information</returns>
    [HttpGet("{departmentId}")]
    public ActionResult<DepartmentDto> Get(string departmentId)
    {
        var department = service.GetById(departmentId);

        if (department == null)
            return NotFound();

        return Ok(department);
    }

    /// <summary>
    /// Add department to database
    /// </summary>
    /// <param name="department">Department's information</param>
    /// <returns>Success or not</returns>
    [HttpPost]
    public ActionResult<DepartmentDto> Post([FromBody] DepartmentDto department)
    {
        service.Post(department);
        
        return Ok(department);
    }

    /// <summary>
    /// Correct department's informations
    /// </summary>
    /// <param name="department">Department's information</param>
    /// <returns>Success or not</returns>
    [HttpPut]
    public ActionResult<DepartmentDto> Put([FromBody] DepartmentDto department)
    {
        if (!service.Put(department))
            return NotFound();

        return Ok(department);
    }

    /// <summary>
    /// Delete department's information by department's id
    /// </summary>
    /// <param name="departmentId">Department's id</param>
    /// <returns>Success or not</returns>
    [HttpDelete("{departmentId}")]
    public ActionResult<string> Delete(string departmentId)
    {
        if (!service.Delete(departmentId))
            return NotFound();

        return Ok("Department was deleted");
    }
}
