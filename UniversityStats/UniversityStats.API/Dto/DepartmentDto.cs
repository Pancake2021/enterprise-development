/// <summary>
/// Class data transfer about department's information
/// </summary>
public class DepartmentDto
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

    /// <summary>
    /// Department's registration number
    /// </summary>
    public required string RegistrationNumber { get; set; }
}
