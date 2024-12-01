namespace UniversityStats.Domain.Entity;

/// <summary>
/// Class for saving department's information
/// </summary>
public class Department
{
    /// <summary>
    /// Faculty's id
    /// </summary>
    public required string FacultyId { get; set; }

    /// <summary>
    /// Department's name
    /// </summary>
    public required string NameDepartment { get; set; }

    /// <summary>
    /// Department's id
    /// </summary>
    public required string DepartmentId { get; set; }
}
