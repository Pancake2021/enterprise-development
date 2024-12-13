using UniversityStats.Client.Api;

public interface IUniversityStatsWrapper
{
	Task<UniversityDto> Post(UniversityDto value);
	Task<UniversityDto> Put(UniversityDto value);
	Task<string> DeleteUniversity(string id);
	Task<ICollection<UniversityDto>> GetAllUniversities();
	Task<UniversityDto> GetByIdUniversity(string id);
	Task<ICollection<SpecialtyAndGroupsDto>> TopFiveSpecialties();
	Task<ICollection<UniversityAndDepartmentsDto>> TotalDepartmentsInUniversity();
}