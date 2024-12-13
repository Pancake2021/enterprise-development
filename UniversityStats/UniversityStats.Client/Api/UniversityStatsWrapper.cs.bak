using UniversityStats.Client.Api;

public class UniversityStatsWrapper(IConfiguration configuration) : IUniversityStatsWrapper
{
	private readonly UniversityStatsApi _client = new(configuration["OpenApi:ServerUrl"], new HttpClient());

	public async Task<string> DeleteUniversity(string id) => await _client.UniversityDELETEAsync(id);

	public async Task<ICollection<UniversityDto>> GetAllUniversities() => await _client.UniversityAllAsync();

	public async Task<UniversityDto> GetByIdUniversity(string id) => await _client.UniversityGETAsync(id);

	public async Task<UniversityDto> Post(UniversityDto value) => await _client.UniversityPOSTAsync(value);

	public async Task<UniversityDto> Put(UniversityDto value) => await _client.UniversityPUTAsync(value);

	public async Task<ICollection<SpecialtyAndGroupsDto>> TopFiveSpecialties() => await _client.Top5SpecialtiesAsync();

	public async Task<ICollection<UniversityAndDepartmentsDto>> TotalDepartmentsInUniversity() => await _client.DepartmentsAsync();
}
