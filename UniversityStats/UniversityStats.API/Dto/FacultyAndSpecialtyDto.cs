namespace UniversityStats.API.Dto;

/// <summary>
/// Class for data transfer about information of departments, faculties and specialties in university
/// </summary>
public class FacultyAndSpecialtyDto
{
    /// <summary>
    /// University's name
    /// </summary>
    public required string NameUniversity { get; set; }

    /// <summary>
    /// Faculty's name
    /// </summary>
    public required string NameFaculty { get; set; }

    /// <summary>
    /// Department's name
    /// </summary>
    public required string NameDepartment { get; set; }

    /// <summary>
    /// Specialty's name
    /// </summary>
    public required string NameSpecialty { get; set; }
}
