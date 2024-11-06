namespace UniversityStats.Classes;

/// <summary>
/// Represents a faculty within the university, containing departments and specialties.
/// </summary>
public class Faculty
{
    /// <summary>
    /// Gets or sets the unique identifier for the faculty.
    /// </summary>
    public int Id { get; set; } // Primary Key

    /// <summary>
    /// Gets or sets the name of the faculty.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the number of groups within the faculty.
    /// </summary>
    public int GroupCount { get; set; }

    /// <summary>
    /// Gets or sets the list of departments in the faculty.
    /// </summary>
    public List<Department> Departments { get; set; } = new List<Department>();

    /// <summary>
    /// Gets or sets the list of specialties within the faculty.
    /// </summary>
    public List<Specialty> Specialties { get; set; } = new List<Specialty>();
}
