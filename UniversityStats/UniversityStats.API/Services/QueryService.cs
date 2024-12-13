using UniversityStats.API.Dto;
using UniversityStats.API.Services.Interfaces;
using UniversityStats.Domain.Entity;
using UniversityStats.Domain.Repositories;
using AutoMapper;

namespace UniversityStats.API.Services;

/// <summary>
/// Class for query's service
/// </summary>
public class QueryService : IQueryService
{
    private readonly QueryRepository _repository;
    private readonly IMapper _mapper;

    public QueryService(QueryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public UniversityDto? InfoUniversityByRegistration(string registrationNumber) => 
        _mapper.Map<UniversityDto>(_repository.InfoUniversityByRegistration(registrationNumber));

    public IEnumerable<UniversityAndDepartmentsDto> TotalDepartmentsInUniversity()
    {
        return _repository.TotalDepartmentsInUniversity().Select(data => 
            new UniversityAndDepartmentsDto
            {
                RegistrationNumber = data.Item1,
                UniversityName = data.Item2,
                TotalDepartments = data.Item3
            });
    }

    public IEnumerable<SpecialtyAndGroupsDto> TopFiveSpecialties()
    {
        return _repository.TopFiveSpecialties().Select(data => 
            new SpecialtyAndGroupsDto
            {
                NameSpecialty = data.Item1,
                TotalGroups = data.Item2
            });
    }

    public IEnumerable<PropertyAndGroupsDto> TotalGroupsByProperty(string propertyType)
    {
        return _repository.TotalGroupsByProperty(propertyType).Select(data => 
            new PropertyAndGroupsDto
            {
                RegistrationNumber = data.Item1,
                PropertyType = data.Item2,
                TotalGroups = Convert.ToInt32(data.Item3)
            });
    }

    public IEnumerable<FacultyAndSpecialtyDto> InfoFacultiesSpecialties(string nameUniversity)
    {
        return _repository.InfoFacultiesSpecialties(nameUniversity).Select(data => 
            new FacultyAndSpecialtyDto
            {
                NameUniversity = nameUniversity,
                NameFaculty = data.Item1,
                NameSpecialty = data.Item2
            });
    }

    public IEnumerable<PropertyAndBuildingDto> TotalDepartmentsFacultiesSpecialtiesByPropertyBuilding()
    {
        return _repository.TotalDepartmentsFacultiesSpecialtiesByPropertyBuilding().Select(data => 
            new PropertyAndBuildingDto
            {
                PropertyType = data.Item1,
                BuildingOwner = data.Item2,
                TotalFaculties = data.Item3,
                TotalSpecialties = data.Item4,
                TotalDepartments = data.Item5
            });
    }

    public IEnumerable<UniversityDto> SearchUniversities(string query) => 
        _repository.GetAllUniversities().Where(u => u.NameUniversity.Contains(query)).Select(u => _mapper.Map<University, UniversityDto>(u));

    public IEnumerable<DepartmentDto> SearchDepartments(string query) => 
        _repository.GetAllDepartments().Where(d => d.NameDepartment.Contains(query)).Select(d => _mapper.Map<Department, DepartmentDto>(d));

    public IEnumerable<FacultyDto> SearchFaculties(string query) => 
        _repository.GetAllFaculties().Where(f => f.NameFaculty.Contains(query)).Select(f => _mapper.Map<Faculty, FacultyDto>(f));

    public IEnumerable<SpecialtyDto> SearchSpecialties(string query) => 
        _repository.GetAllSpecialties().Where(s => s.NameSpecialty.Contains(query)).Select(s => _mapper.Map<Specialty, SpecialtyDto>(s));
}
