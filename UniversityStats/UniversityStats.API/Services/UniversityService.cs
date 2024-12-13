using AutoMapper;
using UniversityStats.API.Dto;
using UniversityStats.API.Services.Interfaces;
using UniversityStats.Domain.Entity;
using UniversityStats.Domain.Repositories;

namespace UniversityStats.API.Services;

/// <summary>
/// Class for university's service
/// </summary>
public class UniversityService : IUniversityService
{
    private readonly UniversityRepository _repository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor for university's service
    /// </summary>
    /// <param name="repository">University's repository</param>
    /// <param name="mapper">Automapper's object for mapping 2 objects UniversityDto and University</param>
    public UniversityService(UniversityRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <summary>
    /// Method get list of universities
    /// </summary>
    /// <returns>List of universities</returns>
    public IEnumerable<UniversityDto> GetAll() => 
        _repository.GetAll().Select(_mapper.Map<University, UniversityDto>);

    /// <summary>
    /// Method get university by registration number
    /// </summary>
    /// <param name="registrationNumber">Registration number</param>
    /// <returns>University's information or null</returns>
    public UniversityDto? GetByRegistrationNumber(string registrationNumber) => 
        _mapper.Map<UniversityDto?>(_repository.GetAll().FirstOrDefault(u => u.RegistrationNumber == registrationNumber));

    /// <summary>
    /// Method post university to database
    /// </summary>
    /// <param name="university">University's information</param>
    public void Post(UniversityDto university) => 
        _repository.Post(_mapper.Map<University>(university));

    /// <summary>
    /// Method put university by registration number
    /// </summary>
    /// <param name="university">University's information</param>
    public void Put(UniversityDto university) => 
        _repository.Put(_mapper.Map<University>(university));

    /// <summary>
    /// Method delete university by registration number
    /// </summary>
    /// <param name="registrationNumber">Registration number</param>
    public void Delete(string registrationNumber) => 
        _repository.Delete(registrationNumber);
}
