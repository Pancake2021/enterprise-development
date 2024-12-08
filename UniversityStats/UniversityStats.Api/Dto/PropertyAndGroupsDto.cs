namespace UniversityStats.API.Dto;

/// <summary>
/// Class for data transfer about information total groups by property type in every university
/// </summary>
public class PropertyAndGroupsDto
{
    /// <summary>
    /// University's registration number 
    /// </summary>
    public required string RegistrationNumber { get; set; } 

    /// <summary>
    /// University's name
    /// </summary>
    public required string NameUniversity { get; set; } 

    /// <summary>
    /// Property type
    /// </summary>
    public required string PropertyType { get; set; }

    /// <summary>
    /// Total Groups
    /// </summary>
    public required int TotalGroups { get; set; } 
}
