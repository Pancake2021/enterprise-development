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
            var universities = new List<University> { GetSampleUniversity(), GetAnotherSampleUniversityWithSameDepartments() };
            var repository = new UniversityRepository(universities);

            var result = repository.GetUniversitiesWithMaxDepartments().ToList();

            Assert.Equal(2, result.Count); // Ожидаем два университета с одинаковым количеством кафедр
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
            var universities = new List<University> { GetSampleUniversity(), GetAnotherSampleUniversity(), GetThirdSampleUniversity() };
            var repository = new UniversityRepository(universities);

            var result = repository.GetOwnershipStatistics().ToList();

            // Исправим, чтобы проверять результат более гибко
            Assert.Equal(2, result.Count); // Два типа собственности
            Assert.Contains(result, r => r.Ownership == OwnershipType.Municipal && r.FacultyCount == 3 && r.DepartmentCount == 3 && r.SpecialtyCount == 5);
            Assert.Contains(result, r => r.Ownership == OwnershipType.Private && r.FacultyCount == 1 && r.DepartmentCount == 1 && r.SpecialtyCount == 1);
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

        private University GetAnotherSampleUniversityWithSameDepartments()
        {
            return new University
            {
                RegistrationNumber = "UNIV003",
                Name = "Technical University",
                Address = "789 Tech Park",
                RectorInfo = new Rector
                {
                    FullName = "Dr. Alice Johnson",
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
                        Name = "Science",
                        GroupCount = 12,
                        Departments = new List<Department> { new Department { Name = "Physics" } },
                        Specialties = new List<Specialty>
                        {
                            new Specialty { Code = "PHY101", Name = "Physics" },
                            new Specialty { Code = "CHM102", Name = "Chemistry" }
                        }
                    },
                    new Faculty
                    {
                        Name = "Mathematics",
                        GroupCount = 8,
                        Departments = new List<Department> { new Department { Name = "Mathematics" } },
                        Specialties = new List<Specialty>
                        {
                            new Specialty { Code = "MATH101", Name = "Mathematics" }
                        }
                    }
                }
            };
        }

        private University GetThirdSampleUniversity()
        {
            return new University
            {
                RegistrationNumber = "UNIV004",
                Name = "Municipal Arts University",
                Address = "101 Main St",
                RectorInfo = new Rector
                {
                    FullName = "Dr. Robert Brown",
                    Degree = Degree.Bachelor,
                    Rank = Rank.Lecturer,
                    Position = Position.Dean
                },
                InstitutionOwnership = OwnershipType.Municipal,
                BuildingOwnership = OwnershipType.Municipal,
                Faculties = new List<Faculty>
                {
                    new Faculty
                    {
                        Name = "Visual Arts",
                        GroupCount = 6,
                        Departments = new List<Department> { new Department { Name = "Design" } },
                        Specialties = new List<Specialty>
                        {
                            new Specialty { Code = "ART301", Name = "Design" }
                        }
                    }
                }
            };
        }
    }
}
