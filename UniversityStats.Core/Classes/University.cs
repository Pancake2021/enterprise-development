using System.Collections.Generic;
using System.Linq;

namespace UniversityStats.Classes;

/// <summary>
/// Класс, представляющий университет и его основные данные.
/// </summary>
public class University
{
    /// <summary>
    /// Регистрационный номер университета.
    /// </summary>
    public required string RegistrationNumber { get; set; }

    /// <summary>
    /// Название университета.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Адрес университета.
    /// </summary>
    public required string Address { get; set; }

    /// <summary>
    /// Информация о ректоре университета.
    /// </summary>
    public required Rector RectorInfo { get; set; }

    /// <summary>
    /// Тип собственности учреждения.
    /// </summary>
    public required OwnershipType InstitutionOwnership { get; set; }

    /// <summary>
    /// Тип собственности здания.
    /// </summary>
    public required OwnershipType BuildingOwnership { get; set; }

    /// <summary>
    /// Список факультетов в университете.
    /// </summary>
    public required List<Faculty> Faculties { get; set; } = new List<Faculty>();

    // Запросы данных о факультетах, кафедрах и специальностях, которые могут быть полезны:

    /// <summary>
    /// Получить информацию о факультетах, кафедрах и специальностях вуза.
    /// </summary>
    public IEnumerable<(string Faculty, string Department, string Specialty)> GetFacultyDepartmentSpecialtyInfo()
    {
        return Faculties.SelectMany(faculty =>
            faculty.Departments.SelectMany(department =>
                faculty.Specialties.Select(specialty =>
                    (Faculty: faculty.Name, Department: department.Name, Specialty: specialty.Name))));
    }

    /// <summary>
    /// Получить топ 5 популярных специальностей по количеству групп.
    /// </summary>
    public IEnumerable<Specialty> GetTop5PopularSpecialties()
    {
        return Faculties.SelectMany(f => f.Specialties)
            .GroupBy(s => s)
            .OrderByDescending(g => g.Count())
            .Take(5)
            .Select(g => g.Key);
    }

    /// <summary>
    /// Получить университеты с максимальным количеством кафедр, упорядоченные по названию.
    /// </summary>
    public static IEnumerable<University> GetUniversitiesWithMaxDepartments(List<University> universities)
    {
        var maxDepartments = universities.Max(u => u.Faculties.Sum(f => f.Departments.Count));
        return universities.Where(u => u.Faculties.Sum(f => f.Departments.Count) == maxDepartments)
                           .OrderBy(u => u.Name);
    }

    /// <summary>
    /// Получить университеты по типу собственности учреждения и количеству групп в вузе.
    /// </summary>
    public static IEnumerable<University> GetUniversitiesByOwnershipAndGroupCount(List<University> universities, OwnershipType ownershipType)
    {
        return universities
            .Where(u => u.InstitutionOwnership == ownershipType)
            .OrderByDescending(u => u.Faculties.Sum(f => f.GroupCount));
    }

    /// <summary>
    /// Получить количество факультетов, кафедр и специальностей по каждому типу собственности.
    /// </summary>
    public static IEnumerable<(OwnershipType Ownership, int FacultyCount, int DepartmentCount, int SpecialtyCount)> GetOwnershipStatistics(List<University> universities)
    {
        return universities.GroupBy(u => u.InstitutionOwnership)
            .Select(g => (Ownership: g.Key,
                FacultyCount: g.Sum(u => u.Faculties.Count),
                DepartmentCount: g.Sum(u => u.Faculties.Sum(f => f.Departments.Count)),
                SpecialtyCount: g.Sum(u => u.Faculties.Sum(f => f.Specialties.Count))));
    }
}
