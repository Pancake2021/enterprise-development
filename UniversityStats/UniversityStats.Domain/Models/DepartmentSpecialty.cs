namespace EducationDepartment.Domain.Models;

/// <summary>
/// Class for saving specialties in department
/// </summary>
public class DepartmentSpecialty
{
    /// <summary>
    /// Department's id
    /// </summary>
    public required string DepartmentId { get; set; }

    /// <summary>
    /// Faculty's id
    /// </summary>
    public required string SpecialtyId { get; set; }
}

