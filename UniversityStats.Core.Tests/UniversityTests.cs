using Xunit;
using UniversityStats.Classes;
using UniversityStats.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace UniversityStats.Core.Tests;

public class UniversityTests
{
    [Fact]
    public void TestGetUniversitiesWithMaxDepartments()
    {
        var universities = new List<University> { GetSampleUniversity() };
        var repository = new UniversityRepository(universities);

        var result = repository.GetUniversitiesWithMaxDepartments().ToList();

        Assert.Single(result);
        Assert.Equal("City University", result[0].Name);
    }

    [Fact]
    public void TestGetUniversitiesByOwnershipAndGroupCount()
    {
        var universities = new List<University> { GetSampleUniversity() };
        var repository = new UniversityRepository(universities);

        var result = repository.GetUniversitiesByOwnershipAndGroupCount(OwnershipType.Municipal).ToList();

        Assert.NotEmpty(result);
        Assert.Equal("City University", result[0].Name);
    }

    [Fact]
    public void TestGetOwnershipStatistics()
    {
        var universities = new List<University> { GetSampleUniversity() };
        var repository = new UniversityRepository(universities);

        var result = repository.GetOwnershipStatistics().ToList();

        Assert.Single(result); // Ожидаем одну запись для типа собственности
        Assert.Equal(OwnershipType.Municipal, result[0].Ownership);
        Assert.Equal(2, result[0].FacultyCount); // 2 факультета в тестовом университете
        Assert.Equal(2, result[0].DepartmentCount); // 1 кафедра в каждом факультете, итого 2
        Assert.Equal(4, result[0].SpecialtyCount); // 2 специальности в каждом факультете, итого 4
    }

    private University GetSampleUniversity()
    {
        return new University
        {
            RegistrationNumber = "UNIV001",
            Name = "City University",
            Address = "123 Main St",
            RectorInfo = new Rector
            {
                FullName = "Dr. John Doe",
                Degree = Degree.PhD,
                Rank = Rank.Professor,
                Position = Position.Rector
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
