namespace UniversityStats.API.Dto;

/// <summary>
/// Class for data transfer about total departments in every university
/// </summary>
public class UniversityAndDepartmentsDto
{
    /// <summary>
    /// University's registration number
    /// </summary>
    public string RegistrationNumber { get; set; } = string.Empty;

    /// <summary>
    /// University's name
    /// </summary>
    public string UniversityName { get; set; } = string.Empty;

    /// <summary>
    /// Total departments
    /// </summary>
    public int TotalDepartments { get; set; }
}
