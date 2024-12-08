using Microsoft.AspNetCore.Mvc;
using UniversityStats.API.Services;
using UniversityStats.Infrastructure.Entities;

namespace UniversityStats.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FacultyController : ControllerBase
{
    private readonly FacultyService _facultyService;

    public FacultyController(FacultyService facultyService)
    {
        _facultyService = facultyService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Faculty>> GetFaculty(int id)
    {
        var faculty = await _facultyService.GetFacultyByIdAsync(id);
        if (faculty == null)
            return NotFound();
        return Ok(faculty);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Faculty>>> GetAllFaculties()
    {
        var faculties = await _facultyService.GetAllFacultiesAsync();
        return Ok(faculties);
    }

    [HttpPost]
    public async Task<ActionResult<Faculty>> CreateFaculty([FromBody] Faculty faculty)
    {
        var createdFaculty = await _facultyService.CreateFacultyAsync(faculty);
        return CreatedAtAction(nameof(GetFaculty), new { id = createdFaculty.Id }, createdFaculty);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Faculty>> UpdateFaculty(int id, [FromBody] Faculty faculty)
    {
        if (id != faculty.Id)
            return BadRequest();

        var updatedFaculty = await _facultyService.UpdateFacultyAsync(faculty);
        return Ok(updatedFaculty);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteFaculty(int id)
    {
        var result = await _facultyService.DeleteFacultyAsync(id);
        if (!result)
            return NotFound();
        return NoContent();
    }
}
