namespace UniversityStats.API.Dto;

/// <summary>
/// Class for data transfer about total specialties, faculties and departments by property type and building ownership
/// </summary>
public class PropertyAndBuildingDto
{
    /// <summary>
    /// Property type
    /// </summary>
    public required string PropertyType { get; set; } 

    /// <summary>
    /// Building ownership
    /// </summary>
    public required string BuildingOwnership { get; set; } 

    /// <summary>
    /// Total specialties
    /// </summary>
    public required int TotalSpecialties { get; set; }

    /// <summary>
    /// Total faculties
    /// </summary>
    public required int TotalFaculties { get; set; }

    /// <summary>
    /// Total departments
    /// </summary>
    public required int TotalDepartments { get; set; }
}
