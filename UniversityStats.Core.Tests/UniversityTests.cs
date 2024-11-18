using Xunit;
using UniversityStats.Classes;
using UniversityStats.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace UniversityStats.Core.Tests
{
    public class UniversityTests
    {
        [Fact]
        public void TestGetUniversitiesWithMaxDepartments()
        {
            var universities = new List<University> { GetSampleUniversity(), GetAnotherSampleUniversity() };
            var repository = new UniversityRepository(universities);

            var result = repository.GetUniversitiesWithMaxDepartments().ToList();

            Assert.Single(result); // Вместо Assert.Equal(1, result.Count)
            Assert.Equal("City University", result[0].Name);
        }

        [Fact]
        public void TestGetUniversitiesByOwnershipAndGroupCount()
        {
            var universities = new List<University> { GetSampleUniversity(), GetAnotherSampleUniversity() };
            var repository = new UniversityRepository(universities);

            var result = repository.GetUniversitiesByOwnershipAndGroupCount(OwnershipType.Municipal).ToList();

            Assert.NotEmpty(result);
            Assert.Equal("City University", result[0].Name);
        }

        [Fact]
        public void TestGetOwnershipStatistics()
        {
            var universities = new List<University> { GetSampleUniversity(), GetAnotherSampleUniversity() };
            var repository = new UniversityRepository(universities);

            var result = repository.GetOwnershipStatistics().ToList();

            Assert.Equal(2, result.Count); // Ожидаем две записи для типов собственности
            Assert.Contains(result, r => r.Ownership == OwnershipType.Municipal && r.FacultyCount == 2);
            Assert.Contains(result, r => r.Ownership == OwnershipType.Private && r.FacultyCount == 1);
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

        private University GetAnotherSampleUniversity()
        {
            return new University
            {
                RegistrationNumber = "UNIV002",
                Name = "Private Tech University",
                Address = "456 Tech Ave",
                RectorInfo = new Rector
                {
                    FullName = "Dr. Jane Smith",
                    Degree = Degree.Master,
                    Rank = Rank.AssociateProfessor,
                    Position = Position.Dean
                },
                InstitutionOwnership = OwnershipType.Private,
                BuildingOwnership = OwnershipType.Private,
                Faculties = new List<Faculty>
                {
                    new Faculty
                    {
                        Name = "Technology",
                        GroupCount = 10,
                        Departments = new List<Department> { new Department { Name = "Information Technology" } },
                        Specialties = new List<Specialty>
                        {
                            new Specialty { Code = "IT301", Name = "Information Technology" }
                        }
                    }
                }
            };
        }
    }
}
