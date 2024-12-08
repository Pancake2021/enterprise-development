using AutoMapper;
using UniversityStats.API.Dto;
using UniversityStats.Domain.Entity;
using UniversityStats.Domain.Repositories;

namespace UniversityStats.API.Services;

/// <summary>
/// Class for university's service
/// </summary>
/// <param name="repository">University's repository</param>
/// <param name="mapper">Automapper's object for mapping 2 objects UniversityDto and University</param>
public class UniversityService(IRepository<University> repository, IMapper mapper) : IService<UniversityDto>
{
    /// <summary>
    /// Method delete university by registration number
    /// </summary>
    /// <param name="id">Registration number</param>
    /// <returns>True or False</returns>
    public bool Delete(string id) => repository.Delete(id);

    /// <summary>
    /// Method get list of universities
    /// </summary>
    /// <returns>List of universities</returns>
    public IEnumerable<UniversityDto> GetAll() => mapper.Map<IEnumerable<UniversityDto>>(repository.GetAll());

    /// <summary>
    /// Method get university by registration number
    /// </summary>
    /// <param name="id">Registration number</param>
    /// <returns>University's information or null</returns>
    public UniversityDto? GetById(string id) => mapper.Map<UniversityDto>(repository.GetById(id));

    /// <summary>
    /// Method post university to database
    /// </summary>
    /// <param name="dtoData">University's information</param>
    public void Post(UniversityDto dtoData)
    {
        repository.Post(mapper.Map<University>(dtoData)); 
    }

    /// <summary>
    /// Method put university by registration number
    /// </summary>
    /// <param name="dtoData">University's information</param>
    /// <returns>True or False</returns>
    public bool Put(UniversityDto dtoData) => repository.Put(mapper.Map<University>(dtoData));
}
