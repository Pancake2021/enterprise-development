// UnitTest1.cs
using Xunit;
using UniversityStats.Classes;
using System.Collections.Generic;
using System.Linq;

namespace UniversityStats.Tests
{
    public class UniversityTests
    {
        [Fact]
        public void TestUniversityCreation()
        {
            var university = new University
            {
                RegistrationNumber = "UNIV001",
                Name = "City University",
                Address = "123 Main St",
                RectorInfo = new Rector
                {
                    FullName = "Dr. John Doe",
                    Degree = "PhD",
                    Rank = "Professor",
                    Position = "Rector"
                },
                InstitutionOwnership = OwnershipType.Municipal,
                BuildingOwnership = OwnershipType.Federal,
                Faculties = new List<Faculty>
                {
                    new Faculty
                    {
                        Name = "Engineering",
                        GroupCount = 15,
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
                        Specialties = new List<Specialty>
                        {
                            new Specialty { Code = "ENG201", Name = "English Literature" },
                            new Specialty { Code = "HIS202", Name = "History" }
                        }
                    }
                }
            };

            Assert.Equal("UNIV001", university.RegistrationNumber);
            Assert.Equal("City University", university.Name);
            Assert.Equal(2, university.Faculties.Count);
        }

        [Fact]
        public void TestGetFacultiesWithGroupCountGreaterThan()
        {
            var university = GetSampleUniversity();

            var result = university.GetFacultiesWithGroupCountGreaterThan(10).ToList();

            Assert.Single(result);
            Assert.Equal("Engineering", result[0].Name);
        }

        [Fact]
        public void TestGetSpecialtiesByFaculty()
        {
            var university = GetSampleUniversity();

            var specialties = university.GetSpecialtiesByFaculty("Engineering").ToList();

            Assert.Equal(2, specialties.Count);
            Assert.Contains(specialties, s => s.Name == "Computer Science");
            Assert.Contains(specialties, s => s.Name == "Mechanical Engineering");
        }

        [Fact]
        public void TestGetSpecialtiesByNonExistentFaculty()
        {
            var university = GetSampleUniversity();

            var specialties = university.GetSpecialtiesByFaculty("NonExistentFaculty").ToList();

            Assert.Empty(specialties);
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
                    Degree = "PhD",
                    Rank = "Professor",
                    Position = "Rector"
                },
                InstitutionOwnership = OwnershipType.Municipal,
                BuildingOwnership = OwnershipType.Federal,
                Faculties = new List<Faculty>
                {
                    new Faculty
                    {
                        Name = "Engineering",
                        GroupCount = 15,
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
