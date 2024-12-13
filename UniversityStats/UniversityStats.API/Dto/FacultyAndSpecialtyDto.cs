namespace UniversityStats.API.Dto;

/// <summary>
/// Class for data transfer about information of departments, faculties and specialties in university
/// </summary>
public class FacultyAndSpecialtyDto
{
    /// <summary>
    /// University's name
    /// </summary>
    public string NameUniversity { get; set; } = string.Empty;

    /// <summary>
    /// Faculty's name
    /// </summary>
    public string NameFaculty { get; set; } = string.Empty;

    /// <summary>
    /// Specialty's name
    /// </summary>
    public string NameSpecialty { get; set; } = string.Empty;
}
