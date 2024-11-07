using System.Collections.Generic;
using System.Linq;

namespace UniversityStats.Classes;

public class University
{
    public required string RegistrationNumber { get; set; }
    public required string Name { get; set; }
    public required string Address { get; set; }
    public required Rector RectorInfo { get; set; }
    public required OwnershipType InstitutionOwnership { get; set; }
    public required OwnershipType BuildingOwnership { get; set; }
    public required List<Faculty> Faculties { get; set; } = new List<Faculty>();

    /// <summary>
    /// Получить информацию о факультетах, кафедрах и специальностях вуза.
    /// </summary>
    /// <remarks>
    /// Метод возвращает коллекцию, содержащую информацию о факультетах, кафедрах и специальностях вуза.
    /// Каждый элемент коллекции включает название факультета, название кафедры и название специальности.
    /// </remarks>
    /// <returns>
    /// Коллекция кортежей, где каждый кортеж состоит из:
    /// - Название факультета (Faculty)
    /// - Название кафедры (Department)
    /// - Название специальности (Specialty)
    /// </returns>
    public IEnumerable<(string Faculty, string Department, string Specialty)> GetFacultyDepartmentSpecialtyInfo()
    {
        return Faculties.SelectMany(faculty =>
            faculty.Departments.SelectMany(department =>
                faculty.Specialties.Select(specialty =>
                    (Faculty: faculty.Name, Department: department.Name, Specialty: specialty.Name))));
    }

    /// <summary>
    /// Получить топ 5 популярных специальностей (по количеству групп).
    /// </summary>
    /// <returns>Коллекция из 5 самых популярных специальностей.</returns>
    public IEnumerable<Specialty> GetTop5PopularSpecialties()
    {
        return Faculties.SelectMany(f => f.Specialties)
            .GroupBy(s => s)
            .OrderByDescending(g => g.Count())
            .Take(5)
            .Select(g => g.Key);
    }

    /// <summary>
    /// Получить вузы с максимальным количеством кафедр, упорядоченные по названию.
    /// </summary>
    /// <param name="universities">Список вузов для анализа.</param>
    /// <returns>Коллекция вузов с максимальным количеством кафедр.</returns>
    public static IEnumerable<University> GetUniversitiesWithMaxDepartments(List<University> universities)
    {
        var maxDepartments = universities.Max(u => u.Faculties.Sum(f => f.Departments.Count));
        return universities.Where(u => u.Faculties.Sum(f => f.Departments.Count) == maxDepartments)
                           .OrderBy(u => u.Name);
    }

    /// <summary>
    /// Получить вузы с заданной собственностью учреждения и количеством групп в вузе.
    /// </summary>
    /// <param name="universities">Список вузов для анализа.</param>
    /// <param name="ownershipType">Тип собственности учреждения.</param>
    /// <returns>Коллекция вузов, соответствующих заданным условиям.</returns>
    public static IEnumerable<University> GetUniversitiesByOwnershipAndGroupCount(List<University> universities, OwnershipType ownershipType)
    {
        return universities
            .Where(u => u.InstitutionOwnership == ownershipType)
            .OrderByDescending(u => u.Faculties.Sum(f => f.GroupCount));
    }

    /// <summary>
    /// Получить количество факультетов, кафедр, специальностей по каждому типу собственности.
    /// </summary>
    /// <param name="universities">Список вузов для анализа.</param>
    /// <returns>
    /// Коллекция кортежей, содержащих:
    /// - Тип собственности (Ownership)
    /// - Количество факультетов (FacultyCount)
    /// - Количество кафедр (DepartmentCount)
    /// - Количество специальностей (SpecialtyCount)
    /// </returns>
    public static IEnumerable<(OwnershipType Ownership, int FacultyCount, int DepartmentCount, int SpecialtyCount)> GetOwnershipStatistics(List<University> universities)
    {
        return universities.GroupBy(u => u.InstitutionOwnership)
            .Select(g => (Ownership: g.Key,
                FacultyCount: g.Sum(u => u.Faculties.Count),
                DepartmentCount: g.Sum(u => u.Faculties.Sum(f => f.Departments.Count)),
                SpecialtyCount: g.Sum(u => u.Faculties.Sum(f => f.Specialties.Count))));
    }
}
