using AutoMapper;
using UniversityStats.API.Services;
using UniversityStats.Infrastructure.Entities;
using UniversityStats.Infrastructure.Repositories.Interfaces;
using Moq;

namespace UniversityStats.Test;

public class ServiceTests
{
    private readonly Mock<IDepartmentRepository> _departmentRepoMock;
    private readonly Mock<IUniversityRepository> _universityRepoMock;
    private readonly Mock<IFacultyRepository> _facultyRepoMock;

    public ServiceTests()
    {
        _departmentRepoMock = new Mock<IDepartmentRepository>();
        _universityRepoMock = new Mock<IUniversityRepository>();
        _facultyRepoMock = new Mock<IFacultyRepository>();
    }

    [Fact]
    public async Task DepartmentService_GetAll_ReturnsAllDepartments()
    {
        // Arrange
        var department = new Department 
        { 
            Id = 1, 
            Name = "Test Department", 
            UniversityId = 1 
        };

        var departments = new List<Department> { department };

        _departmentRepoMock.Setup(x => x.GetAllAsync()).ReturnsAsync(departments);

        var service = new DepartmentService(_departmentRepoMock.Object);

        // Act
        var result = await service.GetAllDepartmentsAsync();

        // Assert
        Assert.Single(result);
        Assert.Equal("Test Department", result.First().Name);
        _departmentRepoMock.Verify(x => x.GetAllAsync(), Times.Once);
    }

    [Fact]
    public async Task UniversityService_GetAll_ReturnsAllUniversities()
    {
        // Arrange
        var university = new University 
        { 
            Id = 1,
            Name = "Test University",
            Description = "Test Description"
        };

        var universities = new List<University> { university };

        _universityRepoMock.Setup(x => x.GetAllAsync()).ReturnsAsync(universities);

        var service = new UniversityService(_universityRepoMock.Object);

        // Act
        var result = await service.GetAllUniversitiesAsync();

        // Assert
        Assert.Single(result);
        Assert.Equal("Test University", result.First().Name);
        _universityRepoMock.Verify(x => x.GetAllAsync(), Times.Once);
    }

    [Fact]
    public async Task FacultyService_GetAll_ReturnsAllFaculties()
    {
        // Arrange
        var faculty = new Faculty 
        { 
            Id = 1, 
            Name = "Test Faculty", 
            DepartmentId = 1 
        };

        var faculties = new List<Faculty> { faculty };

        _facultyRepoMock.Setup(x => x.GetAllAsync()).ReturnsAsync(faculties);

        var service = new FacultyService(_facultyRepoMock.Object);

        // Act
        var result = await service.GetAllFacultiesAsync();

        // Assert
        Assert.Single(result);
        Assert.Equal("Test Faculty", result.First().Name);
        _facultyRepoMock.Verify(x => x.GetAllAsync(), Times.Once);
    }
}
