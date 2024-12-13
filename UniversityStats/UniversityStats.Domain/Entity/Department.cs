using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityStats.Domain.Entity;

/// <summary>
/// Class for saving department's information
/// </summary>
public class Department
{
    /// <summary>
    /// Faculty's id
    /// </summary>
    [ForeignKey("Faculty")]
    [Required(ErrorMessage = "Faculty ID is required")]
    public required string FacultyId { get; set; }

    /// <summary>
    /// Department's name
    /// </summary>
    [Required(ErrorMessage = "Department name is required")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Department name must be between 2 and 100 characters")]
    public required string NameDepartment { get; set; }

    /// <summary>
    /// Department's id
    /// </summary>
    [Key]
    [Required(ErrorMessage = "Department ID is required")]
    public required string DepartmentId { get; set; }

    /// <summary>
    /// Department's registration number
    /// </summary>
    [Required(ErrorMessage = "Registration number is required")]
    [StringLength(50, ErrorMessage = "Registration number cannot be longer than 50 characters")]
    public required string RegistrationNumber { get; set; }
}
