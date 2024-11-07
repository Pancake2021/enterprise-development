using Xunit;
using UniversityStats.Classes;
using UniversityStats.Core.Repositories; // Добавлено для использования UniversityRepository
using System.Collections.Generic;
using System.Linq;

namespace UniversityStats.Core.Tests
{
    public class UniversityTests
    {
        [Fact]
        public void TestUniversityCreation()
        {
            var university = GetSampleUniversity();

            Assert.Equal("UNIV001", university.RegistrationNumber);
            Assert.Equal("City University", university.Name);
            Assert.Equal(2, university.Faculties.Count);
        }

        [Fact]
        public void TestGetFacultyDepartmentSpecialtyInfo()
        {
            var university = GetSampleUniversity();
            var result = university.GetFacultyDepartmentSpecialtyInfo().ToList();

            Assert.NotEmpty(result);
            Assert.Contains(result, r => r.Faculty == "Engineering" && r.Specialty == "Computer Science");
        }

        [Fact]
        public void TestGetTop5PopularSpecialties()
        {
            var universities = new List<University> { GetSampleUniversity() };
            var result = UniversityRepository.GetTop5PopularSpecialties(universities).ToList();

            Assert.True(result.Count <= 5);
            Assert.Contains(result, s => s.Name == "Computer Science");
        }

        [Fact]
        public void TestGetUniversitiesWithMaxDepartments()
        {
            var universities = new List<University> { GetSampleUniversity() };
            var result = UniversityRepository.GetUniversitiesWithMaxDepartments(universities).ToList();

            Assert.Single(result);
            Assert.Equal("City University", result[0].Name);
        }

        [Fact]
        public void TestGetUniversitiesByOwnershipAndGroupCount()
        {
            var universities = new List<University> { GetSampleUniversity() };
            var result = UniversityRepository.GetUniversitiesByOwnershipAndGroupCount(universities, OwnershipType.Municipal).ToList();

            Assert.NotEmpty(result);
            Assert.Equal("City University", result[0].Name);
        }

        [Fact]
        public void TestGetOwnershipStatistics()
        {
            var universities = new List<University> { GetSampleUniversity() };
            var result = UniversityRepository.GetOwnershipStatistics(universities).ToList();

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
}
