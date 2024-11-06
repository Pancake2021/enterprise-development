using System.Collections.Generic;
using System.Linq;

namespace UniversityStats.Classes;

/// <summary>
/// Represents a university with attributes such as registration number, name, rector information, ownership, and faculties.
/// </summary>
public class University
{
    /// <summary>
    /// Gets or sets the unique registration number of the university.
    /// </summary>
    public required string RegistrationNumber { get; set; }

    /// <summary>
    /// Gets or sets the name of the university.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the address of the university.
    /// </summary>
    public required string Address { get; set; }

    /// <summary>
    /// Gets or sets information about the rector of the university.
    /// </summary>
    public required Rector RectorInfo { get; set; }

    /// <summary>
    /// Gets or sets the ownership type of the institution (e.g., Municipal, Private, Federal).
    /// </summary>
    public required OwnershipType InstitutionOwnership { get; set; }

    /// <summary>
    /// Gets or sets the ownership type of the university's building (e.g., Municipal, Private, Federal).
    /// </summary>
    public required OwnershipType BuildingOwnership { get; set; }

    /// <summary>
    /// Gets or sets the list of faculties within the university.
    /// </summary>
    public required List<Faculty> Faculties { get; set; } = new List<Faculty>();

    /// <summary>
    /// Retrieves information about the current university instance.
    /// </summary>
    /// <returns>The current <see cref="University"/> instance.</returns>
    public University GetUniversityInfo() => this;

    /// <summary>
    /// Retrieves information about all faculties, departments, and specialties in the university.
    /// </summary>
    /// <returns>A collection of tuples containing faculty, department, and specialty names.</returns>
    public IEnumerable<(string Faculty, string Department, string Specialty)> GetFacultyDepartmentSpecialtyInfo()
    {
        return Faculties.SelectMany(faculty =>
            faculty.Departments.SelectMany(department =>
                faculty.Specialties.Select(specialty =>
                    (Faculty: faculty.Name, Department: department.Name, Specialty: specialty.Name))));
    }

    /// <summary>
    /// Retrieves the top 5 most popular specialties based on the number of groups.
    /// </summary>
    /// <returns>A collection of the top 5 <see cref="Specialty"/> objects.</returns>
    public IEnumerable<Specialty> GetTop5PopularSpecialties()
    {
        return Faculties.SelectMany(f => f.Specialties)
            .GroupBy(s => s)
            .OrderByDescending(g => g.Count())
            .Take(5)
            .Select(g => g.Key);
    }

    /// <summary>
    /// Retrieves universities with the maximum number of departments, ordered by name.
    /// </summary>
    /// <param name="universities">A list of universities.</param>
    /// <returns>A collection of universities with the maximum number of departments.</returns>
    public static IEnumerable<University> GetUniversitiesWithMaxDepartments(List<University> universities)
    {
        var maxDepartments = universities.Max(u => u.Faculties.Sum(f => f.Departments.Count));
        return universities.Where(u => u.Faculties.Sum(f => f.Departments.Count) == maxDepartments)
                           .OrderBy(u => u.Name);
    }

    /// <summary>
    /// Retrieves universities with a specified institution ownership type and sorts them by the number of groups.
    /// </summary>
    /// <param name="universities">A list of universities.</param>
    /// <param name="ownershipType">The ownership type to filter by.</param>
    /// <returns>A collection of universities that match the specified ownership type, sorted by group count.</returns>
    public static IEnumerable<University> GetUniversitiesByOwnershipAndGroupCount(List<University> universities, OwnershipType ownershipType)
    {
        return universities
            .Where(u => u.InstitutionOwnership == ownershipType)
            .OrderByDescending(u => u.Faculties.Sum(f => f.GroupCount));
    }

    /// <summary>
    /// Retrieves statistics of faculty, department, and specialty counts grouped by ownership type.
    /// </summary>
    /// <param name="universities">A list of universities.</param>
    /// <returns>A collection of tuples containing ownership type, faculty count, department count, and specialty count.</returns>
    public static IEnumerable<(OwnershipType Ownership, int FacultyCount, int DepartmentCount, int SpecialtyCount)> GetOwnershipStatistics(List<University> universities)
    {
        return universities.GroupBy(u => u.InstitutionOwnership)
            .Select(g => (Ownership: g.Key,
                FacultyCount: g.Sum(u => u.Faculties.Count),
                DepartmentCount: g.Sum(u => u.Faculties.Sum(f => f.Departments.Count)),
                SpecialtyCount: g.Sum(u => u.Faculties.Sum(f => f.Specialties.Count))));
    }
}
