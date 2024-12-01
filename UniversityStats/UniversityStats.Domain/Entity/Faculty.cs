namespace UniversityStats.Domain.Entity;

/// <summary>
/// Class for saving faculty's information
/// </summary>
public class Faculty
{
    /// <summary>
    /// Faculty's id
    /// </summary>
    public required string FacultyId { get; set; }

    /// <summary>
    /// Faculty's name
    /// </summary>
    public required string NameFaculty { get; set; }

    /// <summary>
    /// University registration number
    /// </summary>
    public required string RegistrationNumber { get; set; }
}
