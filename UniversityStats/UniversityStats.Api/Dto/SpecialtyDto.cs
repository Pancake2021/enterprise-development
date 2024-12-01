namespace UniversityStats.API.Dto;

/// <summary>
/// Class for data transfer about specialty's information
/// </summary>
public class SpecialtyDto
{
    /// <summary>
    /// Specialty's id
    /// </summary>
    public required string SpecialtyId { get; set; }

    /// <summary>
    /// Specialty's name
    /// </summary>
    public required string NameSpecialty { get; set; }

    /// <summary>
    /// Total groups in specialty
    /// </summary>
    public required int NumberOfGroups { get; set; }
}
