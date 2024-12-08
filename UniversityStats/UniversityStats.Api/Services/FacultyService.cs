using AutoMapper;
using UniversityStats.API.Dto;
using UniversityStats.Domain.Entity;
using UniversityStats.Domain.Repositories;

namespace UniversityStats.API.Services;

/// <summary>
/// Class for faculty's service
/// </summary>
/// <param name="repository">Faculty's repository</param>
/// <param name="mapper">Automapper's object for mapping 2 objects FacultyDto and Faculty</param>
public class FacultyService(IRepository<Faculty> repository, IMapper mapper): IService<FacultyDto>
{
    /// <summary>
    /// Method delete faculty by faculty's id
    /// </summary>
    /// <param name="id">Faculty's id</param>
    /// <returns>True or False</returns>
    public bool Delete(string id) => repository.Delete(id);

    /// <summary>
    /// Method get list of faculties
    /// </summary>
    /// <returns>List of faculties</returns>
    public IEnumerable<FacultyDto> GetAll() => mapper.Map<IEnumerable<FacultyDto>>(repository.GetAll());

    /// <summary>
    /// Method get faculty by faculty's id
    /// </summary>
    /// <param name="id">Faculty's id</param>
    /// <returns>Faculty's information or null</returns>
    public FacultyDto? GetById(string id) => mapper.Map<FacultyDto>(repository.GetById(id));

    /// <summary>
    /// Method post faculty to database
    /// </summary>
    /// <param name="dtoData">Faculty's information</param>
    public void Post(FacultyDto dtoData)
    {
        repository.Post(mapper.Map<Faculty>(dtoData));
    }

    /// <summary>
    /// Method put faculty by faculty's id
    /// </summary>
    /// <param name="dtoData">Faculty's information</param>
    /// <returns>True or False</returns>
    public bool Put(FacultyDto dtoData) => repository.Put(mapper.Map<Faculty>(dtoData));
}
