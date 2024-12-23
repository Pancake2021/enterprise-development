using System.Text;
using UniversityStats.Client.Api;

public class UniversityStatsWrapper(IConfiguration configuration) : IUniversityStatsWrapper
{
	private readonly UniversityStatsApi _client = new(configuration["OpenApi:ServerUrl"], new HttpClient());

	private string DecodeString(string input)
	{
		if (string.IsNullOrEmpty(input))
			return input;

		try 
		{
			// Пытаемся декодировать из разных кодировок
			Encoding[] encodings = new[] 
			{
				Encoding.UTF8,
				Encoding.GetEncoding(1251),  // Windows-1251
				Encoding.GetEncoding(866),   // CP866
				Encoding.GetEncoding(1252)   // Western European
			};

			foreach (var encoding in encodings)
			{
				byte[] bytes = encoding.GetBytes(input);
				string decoded = Encoding.UTF8.GetString(bytes);
				
				// Проверяем, что декодирование дало осмысленный результат
				if (!string.IsNullOrEmpty(decoded) && 
					decoded != input && 
					decoded.Length > 0 && 
					decoded.Any(c => c > 127))  // Проверяем наличие не-ASCII символов
				{
					return decoded;
				}
			}

			return input;
		}
		catch 
		{
			return input;
		}
	}

	private bool IsValidUnicode(string input)
	{
		try 
		{
			input.ToCharArray();
			return true;
		}
		catch 
		{
			return false;
		}
	}

	public async Task<string> DeleteUniversity(string id) => await _client.UniversityDELETEAsync(id);

	public async Task<ICollection<UniversityDto>> GetAllUniversities() 
	{
		var universities = await _client.UniversityAllAsync();
		return universities.Select(u => new UniversityDto 
		{
			RegistrationNumber = u.RegistrationNumber,
			NameUniversity = DecodeString(u.NameUniversity),
			Address = DecodeString(u.Address),
			PropertyType = DecodeString(u.PropertyType),
			BuildingOwnership = DecodeString(u.BuildingOwnership),
			RectorFullName = DecodeString(u.RectorFullName),
			Degree = DecodeString(u.Degree),
			Title = DecodeString(u.Title)
		}).ToList();
	}

	public async Task<UniversityDto> GetByIdUniversity(string id) 
	{
		var university = await _client.UniversityGETAsync(id);
		return new UniversityDto 
		{
			RegistrationNumber = university.RegistrationNumber,
			NameUniversity = DecodeString(university.NameUniversity),
			Address = DecodeString(university.Address),
			PropertyType = DecodeString(university.PropertyType),
			BuildingOwnership = DecodeString(university.BuildingOwnership),
			RectorFullName = DecodeString(university.RectorFullName),
			Degree = DecodeString(university.Degree),
			Title = DecodeString(university.Title)
		};
	}

	public async Task<UniversityDto> Post(UniversityDto value) => await _client.UniversityPOSTAsync(value);

	public async Task<UniversityDto> Put(UniversityDto value) => await _client.UniversityPUTAsync(value);

	public async Task<ICollection<SpecialtyAndGroupsDto>> TopFiveSpecialties() => await _client.Top5SpecialtiesAsync();

	public async Task<UniversityDto> InfoUniversityByRegistration(string registrationNumber) => 
		await _client.UniversityByRegistrationAsync(registrationNumber);

	public async Task<ICollection<FacultyAndSpecialtyDto>> InfoFacultiesSpecialties(string universityName) => 
		await _client.FacultiesSpecialtiesAsync(universityName);

	public async Task<ICollection<PropertyAndBuildingDto>> TotalDepartmentsFacultiesSpecialtiesByPropertyBuilding() => 
		await _client.DepartmentsFacultiesSpecialtiesByPropertyAsync();

	public async Task<ICollection<PropertyAndGroupsDto>> TotalGroupsByProperty(string propertyType) => 
		await _client.GroupsByPropertyAsync(propertyType);

	public async Task<ICollection<UniversityAndDepartmentsDto>> TotalDepartmentsInUniversity() => 
		await _client.DepartmentsAsync();
}
