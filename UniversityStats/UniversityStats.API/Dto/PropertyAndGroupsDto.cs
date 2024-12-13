namespace UniversityStats.API.Dto;

/// <summary>
/// Class for data transfer about information total groups by property type in every university
/// </summary>
public class PropertyAndGroupsDto
{
    /// <summary>
    /// University's registration number 
    /// </summary>
    public string RegistrationNumber { get; set; } = string.Empty;

    /// <summary>
    /// Property type
    /// </summary>
    public string PropertyType { get; set; } = string.Empty;

    /// <summary>
    /// Total Groups
    /// </summary>
    public int TotalGroups { get; set; }
}
