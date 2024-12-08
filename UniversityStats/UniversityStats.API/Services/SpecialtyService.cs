using AutoMapper;
using UniversityStats.API.Dto;
using UniversityStats.Domain.Entity;
using UniversityStats.Domain.Repositories;

namespace UniversityStats.API.Services;

/// <summary>
/// Class for specialty's service
/// </summary>
/// <param name="repository">Specialty's repository</param>
/// <param name="mapper">Automapper's object for mapping 2 objects SpecialtyDto and Specialty</param>
public class SpecialtyService(IRepository<Specialty> repository, IMapper mapper) : IService<SpecialtyDto>
{
    /// <summary>
    /// Method delete specialty by specialty's id
    /// </summary>
    /// <param name="id">Specialty's id</param>
    /// <returns>True or False</returns>
    public bool Delete(string id) => repository.Delete(id);

    /// <summary>
    /// Method get list of specialties
    /// </summary>
    /// <returns>List of specialties</returns>
    public IEnumerable<SpecialtyDto> GetAll() => mapper.Map<IEnumerable<SpecialtyDto>>(repository.GetAll());

    /// <summary>
    /// Method get specialty by specialty's id
    /// </summary>
    /// <param name="id">Specialty's id</param>
    /// <returns>Specialty's information or null</returns>
    public SpecialtyDto? GetById(string id) => mapper.Map<SpecialtyDto>(repository.GetById(id));

    /// <summary>
    /// Method post specialty to database
    /// </summary>
    /// <param name="dtoData">Specialty's information</param>
    public void Post(SpecialtyDto dtoData)
    {
        repository.Post(mapper.Map<Specialty>(dtoData));
    }

    /// <summary>
    /// Method put specialty by specialty's id
    /// </summary>
    /// <param name="dtoData">Specialty's information</param>
    /// <returns>True or False</returns>
    public bool Put(SpecialtyDto dtoData) => repository.Put(mapper.Map<Specialty>(dtoData)); 
}
