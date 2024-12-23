using UniversityStats.Client.Api;

public interface IUniversityStatsWrapper
{
	Task<UniversityDto> Post(UniversityDto value);
	Task<UniversityDto> Put(UniversityDto value);
	Task<string> DeleteUniversity(string id);
	Task<ICollection<UniversityDto>> GetAllUniversities();
	Task<UniversityDto> GetByIdUniversity(string id);
	Task<UniversityDto> InfoUniversityByRegistration(string registrationNumber);
	Task<ICollection<FacultyAndSpecialtyDto>> InfoFacultiesSpecialties(string universityName);
	Task<ICollection<SpecialtyAndGroupsDto>> TopFiveSpecialties();
	Task<ICollection<PropertyAndBuildingDto>> TotalDepartmentsFacultiesSpecialtiesByPropertyBuilding();
	Task<ICollection<UniversityAndDepartmentsDto>> TotalDepartmentsInUniversity();
	Task<ICollection<PropertyAndGroupsDto>> TotalGroupsByProperty(string propertyType);
}