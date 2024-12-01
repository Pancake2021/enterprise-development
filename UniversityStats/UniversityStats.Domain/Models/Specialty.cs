namespace EducationDepartment.Domain.Models;

/// <summary>
/// Class for saving specialty's information
/// </summary>
public class Specialty
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
    /// Number of groups in specialty
    /// </summary>
    public required int NumberOfGroups { get; set; } 
}

