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

        // Запрос 1: Получить информацию о выбранном вузе (возвращает все свойства текущего экземпляра)
        public University GetUniversityInfo() => this;

        // Запрос 2: Получить информацию о факультетах, кафедрах и специальностях вуза
        public IEnumerable<(string Faculty, string Department, string Specialty)> GetFacultyDepartmentSpecialtyInfo()
        {
            return Faculties.SelectMany(faculty =>
                faculty.Departments.SelectMany(department =>
                    faculty.Specialties.Select(specialty =>
                        (Faculty: faculty.Name, Department: department.Name, Specialty: specialty.Name))));
        }

        // Запрос 3: Получить топ 5 популярных специальностей (по количеству групп)
        public IEnumerable<Specialty> GetTop5PopularSpecialties()
        {
            return Faculties.SelectMany(f => f.Specialties)
                .GroupBy(s => s)
                .OrderByDescending(g => g.Count())
                .Take(5)
                .Select(g => g.Key);
        }

        // Запрос 4: Получить вузы с максимальным количеством кафедр, упорядоченные по названию
        public static IEnumerable<University> GetUniversitiesWithMaxDepartments(List<University> universities)
        {
            var maxDepartments = universities.Max(u => u.Faculties.Sum(f => f.Departments.Count));
            return universities.Where(u => u.Faculties.Sum(f => f.Departments.Count) == maxDepartments)
                               .OrderBy(u => u.Name);
        }

        // Запрос 5: Получить вузы с заданной собственностью учреждения и количеством групп в вузе
        public static IEnumerable<University> GetUniversitiesByOwnershipAndGroupCount(List<University> universities, OwnershipType ownershipType)
        {
            return universities
                .Where(u => u.InstitutionOwnership == ownershipType)
                .OrderByDescending(u => u.Faculties.Sum(f => f.GroupCount));
        }

        // Запрос 6: Получить количество факультетов, кафедр, специальностей по каждому типу собственности
        public static IEnumerable<(OwnershipType Ownership, int FacultyCount, int DepartmentCount, int SpecialtyCount)> GetOwnershipStatistics(List<University> universities)
        {
            return universities.GroupBy(u => u.InstitutionOwnership)
                .Select(g => (Ownership: g.Key,
                    FacultyCount: g.Sum(u => u.Faculties.Count),
                    DepartmentCount: g.Sum(u => u.Faculties.Sum(f => f.Departments.Count)),
                    SpecialtyCount: g.Sum(u => u.Faculties.Sum(f => f.Specialties.Count))));
        }
    }
