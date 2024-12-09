using Microsoft.AspNetCore.Mvc;
using UniversityStats.API.Services;
using UniversityStats.Infrastructure.Entities;

namespace UniversityStats.API.Controllers;

/// <summary>
/// Class for department's controller
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly DepartmentService _departmentService;

    /// <summary>
    /// Constructor for DepartmentController
    /// </summary>
    /// <param name="departmentService">Department's service</param>
    public DepartmentController(DepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    /// <summary>
    /// Find department by department's id
    /// </summary>
    /// <param name="id">Department's id</param>
    /// <returns>Department's information</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Department>> GetDepartment(int id)
    {
        var department = await _departmentService.GetDepartmentByIdAsync(id);
        if (department == null)
            return NoContent();
        return Ok(department);
    }

    /// <summary>
    /// Return list of departments
    /// </summary>
    /// <returns> List of departments</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Department>>> GetAllDepartments()
    {
        var departments = await _departmentService.GetAllDepartmentsAsync();
        return Ok(departments);
    }

    /// <summary>
    /// Add department to database
    /// </summary>
    /// <param name="department">Department's information</param>
    /// <returns>Success or not</returns>
    [HttpPost]
    public async Task<ActionResult<Department>> CreateDepartment([FromBody] Department department)
    {
        var createdDepartment = await _departmentService.CreateDepartmentAsync(department);
        return CreatedAtAction(nameof(GetDepartment), new { id = createdDepartment.Id }, createdDepartment);
    }

    /// <summary>
    /// Correct department's informations
    /// </summary>
    /// <param name="id">Department's id</param>
    /// <param name="department">Department's information</param>
    /// <returns>Success or not</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<Department>> UpdateDepartment(int id, [FromBody] Department department)
    {
        if (id != department.Id)
            return BadRequest();

        var updatedDepartment = await _departmentService.UpdateDepartmentAsync(department);
        return Ok(updatedDepartment);
    }

    /// <summary>
    /// Delete department's information by department's id
    /// </summary>
    /// <param name="id">Department's id</param>
    /// <returns>Success or not</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteDepartment(int id)
    {
        var result = await _departmentService.DeleteDepartmentAsync(id);
        if (!result)
            return NoContent();
        return NoContent();
    }
}
