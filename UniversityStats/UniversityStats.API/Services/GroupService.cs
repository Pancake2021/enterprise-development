using UniversityStats.Infrastructure.Entities;
using UniversityStats.Infrastructure.Repositories.Interfaces;

namespace UniversityStats.API.Services;

/// <summary>
/// Class for group's service
/// </summary>
public class GroupService
{
    private readonly IGroupRepository _groupRepository;

    public GroupService(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    /// <summary>
    /// Method get list of groups
    /// </summary>
    /// <returns>List of groups</returns>
    public async Task<IEnumerable<Group>> GetAllGroupsAsync()
    {
        return await _groupRepository.GetAllAsync();
    }

    /// <summary>
    /// Method get group by group's id
    /// </summary>
    /// <param name="id">Group's id</param>
    /// <returns>Group's information or null</returns>
    public async Task<Group?> GetGroupByIdAsync(int id)
    {
        return await _groupRepository.GetByIdAsync(id);
    }

    /// <summary>
    /// Method create group in database
    /// </summary>
    /// <param name="group">Group's information</param>
    public async Task<Group> CreateGroupAsync(Group group)
    {
        return await _groupRepository.AddAsync(group);
    }

    /// <summary>
    /// Method update group
    /// </summary>
    /// <param name="group">Group's information</param>
    public async Task<Group> UpdateGroupAsync(Group group)
    {
        return await _groupRepository.UpdateAsync(group);
    }

    /// <summary>
    /// Method delete group by group's id
    /// </summary>
    /// <param name="id">Group's id</param>
    /// <returns>True or False</returns>
    public async Task<bool> DeleteGroupAsync(int id)
    {
        return await _groupRepository.DeleteAsync(id);
    }
}
