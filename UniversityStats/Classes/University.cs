// University.cs
using System.Collections.Generic;
using System.Linq;

namespace UniversityStats.Classes
{
    public class University
    {
        public required string RegistrationNumber { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required Rector RectorInfo { get; set; }
        public required OwnershipType InstitutionOwnership { get; set; }
        public required OwnershipType BuildingOwnership { get; set; }
        public required List<Faculty> Faculties { get; set; } = new List<Faculty>();

        // Метод: Получить все факультеты с количеством групп больше заданного числа
        public IEnumerable<Faculty> GetFacultiesWithGroupCountGreaterThan(int minGroupCount)
        {
            return Faculties.Where(f => f.GroupCount > minGroupCount);
        }

        // Метод: Получить все специальности определённого факультета
        public IEnumerable<Specialty> GetSpecialtiesByFaculty(string facultyName)
        {
            var faculty = Faculties.FirstOrDefault(f => f.Name == facultyName);
            return faculty != null ? faculty.Specialties : Enumerable.Empty<Specialty>();
        }

        // Метод: Получить всех ректоратов университетов с определённым статусом собственности
        public IEnumerable<Rector> GetRectorsByOwnershipType(OwnershipType ownershipType)
        {
            if (InstitutionOwnership == ownershipType)
            {
                yield return RectorInfo;
            }

            foreach (var faculty in Faculties)
            {
                // Допустим, факультеты могут иметь своих ректоратов (если это применимо)
                // Здесь можно добавить дополнительную логику, если в модели есть ректорат факультетов
            }
        }

        // Добавьте другие методы по заданию
    }
}
