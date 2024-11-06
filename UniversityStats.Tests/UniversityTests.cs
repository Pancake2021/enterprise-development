using Xunit;
using UniversityStats.Classes;
using System.Collections.Generic;
using System.Linq;

namespace UniversityStats.Tests;

public class UniversityTests : IClassFixture<UniversityFixture>
{
    private readonly University _sampleUniversity;

    public UniversityTests(UniversityFixture fixture)
    {
        _sampleUniversity = fixture.SampleUniversity;
    }

    [Fact]
    public void TestUniversityCreation()
    {
        Assert.Equal("UNIV001", _sampleUniversity.RegistrationNumber);
        Assert.Equal("City University", _sampleUniversity.Name);
        Assert.Equal(2, _sampleUniversity.Faculties.Count);
    }

    [Fact]
    public void TestGetUniversityInfo()
    {
        var result = _sampleUniversity.GetUniversityInfo();

        Assert.Equal("UNIV001", result.RegistrationNumber);
        Assert.Equal("City University", result.Name);
        Assert.Equal("123 Main St", result.Address);
    }

    [Fact]
    public void TestGetFacultyDepartmentSpecialtyInfo()
    {
        var result = _sampleUniversity.GetFacultyDepartmentSpecialtyInfo().ToList();

        Assert.NotEmpty(result);
        Assert.Contains(result, r => r.Faculty == "Engineering" && r.Specialty == "Computer Science");
    }

    [Fact]
    public void TestGetTop5PopularSpecialties()
    {
        var result = _sampleUniversity.GetTop5PopularSpecialties().ToList();

        Assert.True(result.Count <= 5);
        Assert.Contains(result, s => s.Name == "Computer Science");
    }

    [Fact]
    public void TestGetUniversitiesWithMaxDepartments()
    {
        var universities = new List<University> { _sampleUniversity };
        var result = University.GetUniversitiesWithMaxDepartments(universities).ToList();

        Assert.Single(result);
        Assert.Equal("City University", result[0].Name);
    }

    [Fact]
    public void TestGetUniversitiesByOwnershipAndGroupCount()
    {
        var universities = new List<University> { _sampleUniversity };
        var result = University.GetUniversitiesByOwnershipAndGroupCount(universities, OwnershipType.Municipal).ToList();

        Assert.NotEmpty(result);
        Assert.Equal("City University", result[0].Name);
    }

    [Fact]
    public void TestGetOwnershipStatistics()
    {
        var universities = new List<University> { _sampleUniversity };
        var result = University.GetOwnershipStatistics(universities).ToList();

        Assert.Single(result);
        Assert.Equal(OwnershipType.Municipal, result[0].Ownership);
        Assert.Equal(2, result[0].FacultyCount);
        Assert.Equal(2, result[0].DepartmentCount);
        Assert.Equal(4, result[0].SpecialtyCount);
    }
}

