namespace UniversityStats.API.Dto;

/// <summary>
/// class for data transfer about information total groups in every specialty
/// </summary>
public class SpecialtyAndGroupsDto
{
    /// <summary>
    /// Specialty's name
    /// </summary>
    public required string NameSpecialty { get; set; }

    /// <summary>
    /// Total groups
    /// </summary>
    public required int TotalGroups { get; set; }
}
