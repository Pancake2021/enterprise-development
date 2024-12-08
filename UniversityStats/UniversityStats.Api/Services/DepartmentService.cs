using AutoMapper;
using UniversityStats.API.Dto;
using UniversityStats.Domain.Entity;
using UniversityStats.Domain.Repositories;

namespace UniversityStats.API.Services;

/// <summary>
/// Class for department's service
/// </summary>
/// <param name="repository">Department's repository</param>
/// <param name="mapper">Automapper's object for mapping 2 objects DepartmentDto and Department</param>
public class DepartmentService(IRepository<Department> repository, IMapper mapper) : IService<DepartmentDto>
{
    /// <summary>
    /// Method delete department by department's id
    /// </summary>
    /// <param name="id">Department's id</param>
    /// <returns>True or False</returns>
    public bool Delete(string id) => repository.Delete(id);

    /// <summary>
    /// Method get list of departments
    /// </summary>
    /// <returns>List of departments</returns>
    public IEnumerable<DepartmentDto> GetAll() => mapper.Map<IEnumerable<DepartmentDto>>(repository.GetAll());

    /// <summary>
    /// Method get department by department's id
    /// </summary>
    /// <param name="id">Department's id</param>
    /// <returns>Department's information or null</returns>
    public DepartmentDto? GetById(string id) => mapper.Map<DepartmentDto>(repository.GetById(id));

    /// <summary>
    /// Method post department to database
    /// </summary>
    /// <param name="dtoData">Department's information</param>
    public void Post(DepartmentDto dtoData) 
    {
        repository.Post(mapper.Map<Department>(dtoData));
    }
    
    /// <summary>
    /// Method put department by department's id
    /// </summary>
    /// <param name="dtoData">Department's information</param>
    /// <returns>True or False</returns>
    public bool Put(DepartmentDto dtoData) => repository.Put(mapper.Map<Department>(dtoData));
}
