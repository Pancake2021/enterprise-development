using AutoMapper;
using UniversityStats.API.Dto;
using UniversityStats.API.Services.Interfaces;
using UniversityStats.Domain.Entity;
using UniversityStats.Domain.Repositories;

namespace UniversityStats.API.Services;

/// <summary>
/// Class for department's service
/// </summary>
public class DepartmentService : IDepartmentService
{
    private readonly DepartmentRepository _repository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor for DepartmentService
    /// </summary>
    /// <param name="repository">Department's repository</param>
    /// <param name="mapper">Mapper for mapping entities</param>
    public DepartmentService(DepartmentRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <summary>
    /// Method get list of departments
    /// </summary>
    /// <returns>List of departments</returns>
    public IEnumerable<DepartmentDto> GetAll() => 
        _repository.GetAll().Select(_mapper.Map<Department, DepartmentDto>);

    /// <summary>
    /// Method get department by department's registration number
    /// </summary>
    /// <param name="registrationNumber">Department's registration number</param>
    /// <returns>Department's information or null</returns>
    public DepartmentDto? GetByRegistrationNumber(string registrationNumber) => 
        _mapper.Map<DepartmentDto>(_repository.GetByRegistrationNumber(registrationNumber));

    /// <summary>
    /// Method post department to database
    /// </summary>
    /// <param name="department">Department's information</param>
    public void Post(DepartmentDto department) => 
        _repository.Post(_mapper.Map<Department>(department));

    /// <summary>
    /// Method put department by department's registration number
    /// </summary>
    /// <param name="department">Department's information</param>
    public void Put(DepartmentDto department) => 
        _repository.Put(_mapper.Map<Department>(department));

    /// <summary>
    /// Method delete department by department's registration number
    /// </summary>
    /// <param name="registrationNumber">Department's registration number</param>
    public void Delete(string registrationNumber) => 
        _repository.Delete(registrationNumber);
}
