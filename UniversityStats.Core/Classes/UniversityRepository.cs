using System.Collections.Generic;
using System.Linq;
using UniversityStats.Classes;

namespace UniversityStats.Repositories
{
    /// <summary>
    /// Репозиторий для работы с объектами класса University.
    /// </summary>
    public class UniversityRepository
    {
        private readonly List<University> _universities;

        public UniversityRepository(List<University> universities)
        {
            _universities = universities;
        }

        /// <summary>
        /// Получить вузы с максимальным количеством кафедр, упорядоченные по названию.
        /// </summary>
        public IEnumerable<University> GetUniversitiesWithMaxDepartments()
        {
            var maxDepartments = _universities.Max(u => u.Faculties.Sum(f => f.Departments.Count));
            return _universities
                .Where(u => u.Faculties.Sum(f => f.Departments.Count) == maxDepartments)
                .OrderBy(u => u.Name);
        }

        /// <summary>
        /// Получить вузы с заданной собственностью учреждения и количеством групп в вузе.
        /// </summary>
        public IEnumerable<University> GetUniversitiesByOwnershipAndGroupCount(OwnershipType ownershipType)
        {
            return _universities
                .Where(u => u.InstitutionOwnership == ownershipType)
                .OrderByDescending(u => u.Faculties.Sum(f => f.GroupCount));
        }

        /// <summary>
        /// Получить количество факультетов, кафедр, специальностей по каждому типу собственности.
        /// </summary>
        public IEnumerable<(OwnershipType Ownership, int FacultyCount, int DepartmentCount, int SpecialtyCount)> GetOwnershipStatistics()
        {
            return _universities.GroupBy(u => u.InstitutionOwnership)
                .Select(g => (Ownership: g.Key,
                    FacultyCount: g.Sum(u => u.Faculties.Count),
                    DepartmentCount: g.Sum(u => u.Faculties.Sum(f => f.Departments.Count)),
                    SpecialtyCount: g.Sum(u => u.Faculties.Sum(f => f.Specialties.Count))));
        }
    }
}
