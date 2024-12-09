using Microsoft.AspNetCore.Mvc;
using UniversityStats.API.Services;
using UniversityStats.Infrastructure.Entities;

namespace UniversityStats.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SpecialtyController(
    SpecialtyService specialtyService) : ControllerBase
{
    private readonly SpecialtyService _specialtyService = specialtyService;

    [HttpGet("{id}")]
    public async Task<ActionResult<Specialty>> GetSpecialty(int id)
    {
        var specialty = await _specialtyService.GetSpecialtyByIdAsync(id);
        if (specialty == null)
            return NoContent();
        return Ok(specialty);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Specialty>>> GetAllSpecialties()
    {
        var specialties = await _specialtyService.GetAllSpecialtiesAsync();
        return Ok(specialties);
    }

    [HttpPost]
    public async Task<ActionResult<Specialty>> CreateSpecialty([FromBody] Specialty specialty)
    {
        var createdSpecialty = await _specialtyService.CreateSpecialtyAsync(specialty);
        return CreatedAtAction(nameof(GetSpecialty), new { id = createdSpecialty.Id }, createdSpecialty);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Specialty>> UpdateSpecialty(int id, [FromBody] Specialty specialty)
    {
        if (id != specialty.Id)
            return BadRequest();

        var updatedSpecialty = await _specialtyService.UpdateSpecialtyAsync(specialty);
        return Ok(updatedSpecialty);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteSpecialty(int id)
    {
        var result = await _specialtyService.DeleteSpecialtyAsync(id);
        if (!result)
            return NoContent();
        return NoContent();
    }
}
