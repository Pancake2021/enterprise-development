namespace UniversityStats.API.Dto;

/// <summary>
/// Class for data transfer about total specialties, faculties and departments by property type and building ownership
/// </summary>
public class PropertyAndBuildingDto
{
    /// <summary>
    /// Property type
    /// </summary>
    public string PropertyType { get; set; } = string.Empty;

    /// <summary>
    /// Building ownership
    /// </summary>
    public string BuildingOwner { get; set; } = string.Empty;

    /// <summary>
    /// Total faculties
    /// </summary>
    public int TotalFaculties { get; set; }

    /// <summary>
    /// Total specialties
    /// </summary>
    public int TotalSpecialties { get; set; }

    /// <summary>
    /// Total departments
    /// </summary>
    public int TotalDepartments { get; set; }
}
