using System.Collections.Generic;
using UniversityStats.Classes;

public class UniversityFixture
{
    public University CreateSampleUniversity()
    {
        return new University
        {
            RegistrationNumber = "UNIV001",
            Name = "City University",
            Address = "123 Main St",
            RectorInfo = new Rector
            {
                FullName = "Dr. John Doe",
                Degree = Degree.PhD, // Заменено на перечисление Degree вместо строки
                Rank = Rank.Professor, // Заменено на перечисление Rank вместо строки
                Position = Position.Rector // Заменено на перечисление Position вместо строки
            },
            InstitutionOwnership = OwnershipType.Municipal,
            BuildingOwnership = OwnershipType.Federal,
            Faculties = new List<Faculty>
            {
                new Faculty
                {
                    Name = "Engineering",
                    GroupCount = 15,
                    Departments = new List<Department> { new Department { Name = "Computer Science" } },
                    Specialties = new List<Specialty>
                    {
                        new Specialty { Code = "CS101", Name = "Computer Science" },
                        new Specialty { Code = "ME102", Name = "Mechanical Engineering" }
                    }
                },
                new Faculty
                {
                    Name = "Arts",
                    GroupCount = 8,
                    Departments = new List<Department> { new Department { Name = "Humanities" } },
                    Specialties = new List<Specialty>
                    {
                        new Specialty { Code = "ENG201", Name = "English Literature" },
                        new Specialty { Code = "HIS202", Name = "History" }
                    }
                }
            }
        };
    }
}
