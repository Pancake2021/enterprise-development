using AutoMapper;
using UniversityStats.API.Dto;
using UniversityStats.API.Services.Interfaces;
using UniversityStats.Domain.Entity;
using UniversityStats.Domain.Repositories;

namespace UniversityStats.API.Services;

/// <summary>
/// Class for faculty's service
/// </summary>
/// <param name="repository">Faculty's repository</param>
/// <param name="mapper">Automapper's object for mapping 2 objects FacultyDto and Faculty</param>
public class FacultyService : IFacultyService
{
    private readonly FacultyRepository _repository;
    private readonly IMapper _mapper;

    public FacultyService(FacultyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <summary>
    /// Method delete faculty by faculty's id
    /// </summary>
    /// <param name="id">Faculty's id</param>
    /// <returns>True or False</returns>
    public void Delete(string facultyId) => _repository.Delete(facultyId);

    /// <summary>
    /// Method get list of faculties
    /// </summary>
    /// <returns>List of faculties</returns>
    public IEnumerable<FacultyDto> GetAll() => _repository.GetAll().Select(_mapper.Map<FacultyDto>);

    /// <summary>
    /// Method get faculty by faculty's id
    /// </summary>
    /// <param name="id">Faculty's id</param>
    /// <returns>Faculty's information or null</returns>
    public FacultyDto GetById(string facultyId) => _mapper.Map<FacultyDto>(_repository.GetById(facultyId));

    /// <summary>
    /// Method post faculty to database
    /// </summary>
    /// <param name="dtoData">Faculty's information</param>
    public void Post(FacultyDto faculty) => _repository.Post(_mapper.Map<Faculty>(faculty));

    /// <summary>
    /// Method put faculty by faculty's id
    /// </summary>
    /// <param name="dtoData">Faculty's information</param>
    /// <returns>True or False</returns>
    public void Put(FacultyDto faculty) => _repository.Put(_mapper.Map<Faculty>(faculty));
}
