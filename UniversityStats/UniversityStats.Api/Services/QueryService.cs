using AutoMapper;
using UniversityStats.API.Dto;
using UniversityStats.Domain.Entity;
using UniversityStats.Domain.Repositories;

namespace UniversityStats.API.Services;
/// <summary>
/// Class for query's service
/// </summary>
/// <param name="queryRepository">Query's repository</param>
public class QueryService(QueryRepository queryRepository)
{
    public IEnumerable<UniversityDto> InfoUniversityByRegistration(string registrationNumber)
    {
        return from data in queryRepository.InfoUniversityByRegistration(registrationNumber)
               select new UniversityDto
               {
                   RegistrationNumber = registrationNumber,
                   NameUniversity = data.Item1,
                   Address = data.Item2,
                   PropertyType = data.Item3,
                   BuildingOwnership = data.Item4,
                   RectorFullName = data.Item5,
                   Degree = data.Item6,
                   Tittle = data.Item7
               };
    }

    public IEnumerable<UniversityAndDepartmentsDto> TotalDepartmentsInUniversity()
    {
        return from data in queryRepository.TotalDepartmentsInUniversity()
               select new UniversityAndDepartmentsDto
               {
                  NameUniversity = data.Item1,
                  RegistrationNumber = data.Item2,
                  TotalDepartments = data.Item3
               };
    }

    public IEnumerable<SpecialtyAndGroupsDto> TopFiveSpecialties()
    {
        return from data in queryRepository.TopFiveSpecialties()
               select new SpecialtyAndGroupsDto
               {
                   NameSpecialty = data.Item1,
                   TotalGroups = data.Item2
               };
    }

    public IEnumerable<PropertyAndGroupsDto> TotalGroupsByProperty(string propertyType)
    {
        return from data in queryRepository.TotalGroupsByProperty(propertyType)
               select new PropertyAndGroupsDto
               {
                   RegistrationNumber = data.Item1,
                   NameUniversity = data.Item2,
                   PropertyType = propertyType,
                   TotalGroups = data.Item4
               };
    }

    public IEnumerable<FacultyAndSpecialtyDto> InfoFacultiesSpecialties(string nameUniversity)
    {
        return from data in queryRepository.InfoFacultiesSpecialties(nameUniversity)
               select new FacultyAndSpecialtyDto
               {
                   NameUniversity = nameUniversity,
                   NameFaculty = data.Item2,
                   NameDepartment = data.Item3,
                   NameSpecialty = data.Item4
               };
    }

    public IEnumerable<PropertyAndBuildingDto> TotalDepartmentsFacultiesSpecialtiesByPropertyBuilding()
    {
        return from data in queryRepository.TotalDepartmentsFacultiesSpecialtiesByPropertyBuilding()
               select new PropertyAndBuildingDto
               {
                   PropertyType = data.Item1,
                   BuildingOwnership = data.Item2,
                   TotalSpecialties = data.Item3,
                   TotalFaculties = data.Item4,
                   TotalDepartments = data.Item5
               };
    }
}
