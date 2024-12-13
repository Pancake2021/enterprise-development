using AutoMapper;
using UniversityStats.API.Dto;
using UniversityStats.API.Services.Interfaces;
using UniversityStats.Domain.Entity;
using UniversityStats.Domain.Repositories;

namespace UniversityStats.API.Services;

/// <summary>
/// Class for (department specialty)'s service
/// </summary>
public class DepartmentSpecialtyService : IDepartmentSpecialtyService
{
    private readonly DepartmentSpecialtyRepository _repository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor for DepartmentSpecialtyService
    /// </summary>
    /// <param name="repository">(department specialty)'s repository</param>
    /// <param name="mapper">Automapper's object for mapping 2 objects DepartmentSpecialty and DepartmentSpecialtyDto</param>
    public DepartmentSpecialtyService(DepartmentSpecialtyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <summary>
    /// Method get list of (department specialty)
    /// </summary>
    /// <returns>List of departments</returns>
    public IEnumerable<DepartmentSpecialtyDto> GetAll() => _repository.GetAll().Select(_mapper.Map<DepartmentSpecialtyDto>);

    /// <summary>
    /// Method get (department specialty) by specialty's id
    /// </summary>
    /// <param name="departmentSpecialtyId">Specialty's id</param>
    /// <returns>(department specialty)'s information or null</returns>
    public DepartmentSpecialtyDto GetById(string departmentSpecialtyId) => 
        _mapper.Map<DepartmentSpecialtyDto>(_repository.GetById(departmentSpecialtyId));

    /// <summary>
    /// Method post (department specialty) to database
    /// </summary>
    /// <param name="departmentSpecialty">Department's information</param>
    public void Post(DepartmentSpecialtyDto departmentSpecialty) => 
        _repository.Post(_mapper.Map<DepartmentSpecialty>(departmentSpecialty));

    /// <summary>
    /// Method put (department specialty) by speciatly's id
    /// </summary>
    /// <param name="departmentSpecialty">(department specialty)'s information</param>
    public void Put(DepartmentSpecialtyDto departmentSpecialty) => 
        _repository.Put(_mapper.Map<DepartmentSpecialty>(departmentSpecialty));

    /// <summary>
    /// Method delete (department specialty) by specialty's id
    /// </summary>
    /// <param name="departmentSpecialtyId">Specialty's id</param>
    public void Delete(string departmentSpecialtyId) => _repository.Delete(departmentSpecialtyId);
}
