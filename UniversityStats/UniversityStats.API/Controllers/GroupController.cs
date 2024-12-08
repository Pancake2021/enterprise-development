using Microsoft.AspNetCore.Mvc;
using UniversityStats.API.Services;
using UniversityStats.Infrastructure.Entities;

namespace UniversityStats.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroupController : ControllerBase
{
    private readonly GroupService _groupService;

    public GroupController(GroupService groupService)
    {
        _groupService = groupService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Group>> GetGroup(int id)
    {
        var group = await _groupService.GetGroupByIdAsync(id);
        if (group == null)
            return NotFound();
        return Ok(group);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Group>>> GetAllGroups()
    {
        var groups = await _groupService.GetAllGroupsAsync();
        return Ok(groups);
    }

    [HttpPost]
    public async Task<ActionResult<Group>> CreateGroup([FromBody] Group group)
    {
        var createdGroup = await _groupService.CreateGroupAsync(group);
        return CreatedAtAction(nameof(GetGroup), new { id = createdGroup.Id }, createdGroup);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Group>> UpdateGroup(int id, [FromBody] Group group)
    {
        if (id != group.Id)
            return BadRequest();

        var updatedGroup = await _groupService.UpdateGroupAsync(group);
        return Ok(updatedGroup);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteGroup(int id)
    {
        var result = await _groupService.DeleteGroupAsync(id);
        if (!result)
            return NotFound();
        return NoContent();
    }
}
