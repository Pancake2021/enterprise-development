using AutoMapper;
using UniversityStats.API.Dto;
using UniversityStats.API.Services.Interfaces;
using UniversityStats.Domain.Entity;
using UniversityStats.Domain.Repositories;

namespace UniversityStats.API.Services;

/// <summary>
/// Class for specialty's service
/// </summary>
public class SpecialtyService : ISpecialtyService
{
    private readonly SpecialtyRepository _repository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor for SpecialtyService
    /// </summary>
    /// <param name="repository">Specialty's repository</param>
    /// <param name="mapper">Automapper's object for mapping 2 objects SpecialtyDto and Specialty</param>
    public SpecialtyService(SpecialtyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <summary>
    /// Method delete specialty by specialty's id
    /// </summary>
    /// <param name="id">Specialty's id</param>
    /// <returns>True or False</returns>
    public void Delete(string specialtyId) => _repository.Delete(specialtyId);

    /// <summary>
    /// Method get list of specialties
    /// </summary>
    /// <returns>List of specialties</returns>
    public IEnumerable<SpecialtyDto> GetAll() => _repository.GetAll().Select(_mapper.Map<SpecialtyDto>);

    /// <summary>
    /// Method get specialty by specialty's id
    /// </summary>
    /// <param name="id">Specialty's id</param>
    /// <returns>Specialty's information or null</returns>
    public SpecialtyDto GetById(string specialtyId) => _mapper.Map<SpecialtyDto>(_repository.GetById(specialtyId));

    /// <summary>
    /// Method post specialty to database
    /// </summary>
    /// <param name="dtoData">Specialty's information</param>
    public void Post(SpecialtyDto specialty) => _repository.Post(_mapper.Map<Specialty>(specialty));

    /// <summary>
    /// Method put specialty by specialty's id
    /// </summary>
    /// <param name="dtoData">Specialty's information</param>
    /// <returns>True or False</returns>
    public void Put(SpecialtyDto specialty) => _repository.Put(_mapper.Map<Specialty>(specialty)); 
}
