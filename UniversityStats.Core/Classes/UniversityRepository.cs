using System.Collections.Generic;
using System.Linq;
using UniversityStats.Classes;

namespace UniversityStats.Core.Repositories
{
    /// <summary>
    /// Репозиторий для управления коллекциями вузов и выполнения различных операций с ними.
    /// </summary>
    public class UniversityRepository
    {
        /// <summary>
        /// Получить топ 5 популярных специальностей (по количеству групп).
        /// </summary>
        /// <param name="universities">Список университетов.</param>
        /// <returns>Топ 5 популярных специальностей.</returns>
        public static IEnumerable<Specialty> GetTop5PopularSpecialties(IEnumerable<University> universities)
        {
            return universities.SelectMany(u => u.Faculties)
                               .SelectMany(f => f.Specialties)
                               .GroupBy(s => s)
                               .OrderByDescending(g => g.Count())
                               .Take(5)
                               .Select(g => g.Key);
        }

        /// <summary>
        /// Получить вузы с максимальным количеством кафедр, упорядоченные по названию.
        /// </summary>
        /// <param name="universities">Список университетов.</param>
        /// <returns>Список университетов с максимальным количеством кафедр.</returns>
        public static IEnumerable<University> GetUniversitiesWithMaxDepartments(IEnumerable<University> universities)
        {
            var maxDepartments = universities.Max(u => u.Faculties.Sum(f => f.Departments.Count));
            return universities.Where(u => u.Faculties.Sum(f => f.Departments.Count) == maxDepartments)
                               .OrderBy(u => u.Name);
        }

        /// <summary>
        /// Получить вузы с заданной собственностью учреждения и количеством групп в вузе.
        /// </summary>
        /// <param name="universities">Список университетов.</param>
        /// <param name="ownershipType">Тип собственности.</param>
        /// <returns>Список университетов с заданной собственностью.</returns>
        public static IEnumerable<University> GetUniversitiesByOwnershipAndGroupCount(IEnumerable<University> universities, OwnershipType ownershipType)
        {
            return universities
                .Where(u => u.InstitutionOwnership == ownershipType)
                .OrderByDescending(u => u.Faculties.Sum(f => f.GroupCount));
        }

        /// <summary>
        /// Получить количество факультетов, кафедр, специальностей по каждому типу собственности.
        /// </summary>
        /// <param name="universities">Список университетов.</param>
        /// <returns>Количество факультетов, кафедр, специальностей по каждому типу собственности.</returns>
        public static IEnumerable<(OwnershipType Ownership, int FacultyCount, int DepartmentCount, int SpecialtyCount)> GetOwnershipStatistics(IEnumerable<University> universities)
        {
            return universities.GroupBy(u => u.InstitutionOwnership)
                .Select(g => (Ownership: g.Key,
                    FacultyCount: g.Sum(u => u.Faculties.Count),
                    DepartmentCount: g.Sum(u => u.Faculties.Sum(f => f.Departments.Count)),
                    SpecialtyCount: g.Sum(u => u.Faculties.Sum(f => f.Specialties.Count))));
        }
    }
}
