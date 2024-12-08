using AutoMapper;
using UniversityStats.API.Dto;
using UniversityStats.API.Services;
using UniversityStats.Domain.Entity;
using UniversityStats.Domain.Repositories;
using Moq;

namespace UniversityStats.Test;

public class ServiceTests
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IRepository<Department>> _departmentRepoMock;
    private readonly Mock<IRepository<University>> _universityRepoMock;
    private readonly Mock<IRepository<Faculty>> _facultyRepoMock;

    public ServiceTests()
    {
        _mapperMock = new Mock<IMapper>();
        _departmentRepoMock = new Mock<IRepository<Department>>();
        _universityRepoMock = new Mock<IRepository<University>>();
        _facultyRepoMock = new Mock<IRepository<Faculty>>();
    }

    [Fact]
    public void DepartmentService_GetAll_ReturnsAllDepartments()
    {
        // Arrange
        var department = new Department 
        { 
            DepartmentId = "1", 
            NameDepartment = "Test Department", 
            FacultyId = "1" 
        };
        var departmentDto = new DepartmentDto 
        { 
            DepartmentId = "1", 
            NameDepartment = "Test Department", 
            FacultyId = "1" 
        };

        var departments = new List<Department> { department };
        var departmentDtos = new List<DepartmentDto> { departmentDto };

        _departmentRepoMock.Setup(x => x.GetAll()).Returns(departments);
        _mapperMock.Setup(x => x.Map<IEnumerable<DepartmentDto>>(departments)).Returns(departmentDtos);

        var service = new DepartmentService(_departmentRepoMock.Object, _mapperMock.Object);

        // Act
        var result = service.GetAll();

        // Assert
        Assert.Equal(1, result.Count());
        Assert.Equal("Test Department", result.First().NameDepartment);
        _departmentRepoMock.Verify(x => x.GetAll(), Times.Once);
        _mapperMock.Verify(x => x.Map<IEnumerable<DepartmentDto>>(departments), Times.Once);
    }

    [Fact]
    public void UniversityService_GetAll_ReturnsAllUniversities()
    {
        // Arrange
        var university = new University 
        { 
            RegistrationNumber = "1", 
            NameUniversity = "Test University",
            Tittle = "Test University Title",
            Address = "Test Address", 
            PropertyType = "Test Type", 
            BuildingOwnership = "Test Ownership", 
            RectorFullName = "Test Rector", 
            Degree = "Test Degree" 
        };
        var universityDto = new UniversityDto 
        { 
            RegistrationNumber = "1", 
            NameUniversity = "Test University",
            Tittle = "Test University Title",
            Address = "Test Address", 
            PropertyType = "Test Type", 
            BuildingOwnership = "Test Ownership", 
            RectorFullName = "Test Rector", 
            Degree = "Test Degree" 
        };

        var universities = new List<University> { university };
        var universityDtos = new List<UniversityDto> { universityDto };

        _universityRepoMock.Setup(x => x.GetAll()).Returns(universities);
        _mapperMock.Setup(x => x.Map<IEnumerable<UniversityDto>>(universities)).Returns(universityDtos);

        var service = new UniversityService(_universityRepoMock.Object, _mapperMock.Object);

        // Act
        var result = service.GetAll();

        // Assert
        Assert.Equal(1, result.Count());
        Assert.Equal("Test University", result.First().NameUniversity);
        _universityRepoMock.Verify(x => x.GetAll(), Times.Once);
        _mapperMock.Verify(x => x.Map<IEnumerable<UniversityDto>>(universities), Times.Once);
    }

    [Fact]
    public void FacultyService_GetAll_ReturnsAllFaculties()
    {
        // Arrange
        var faculty = new Faculty 
        { 
            FacultyId = "1", 
            NameFaculty = "Test Faculty", 
            RegistrationNumber = "Test Reg Number" 
        };
        var facultyDto = new FacultyDto 
        { 
            FacultyId = "1", 
            NameFaculty = "Test Faculty", 
            RegistrationNumber = "Test Reg Number" 
        };

        var faculties = new List<Faculty> { faculty };
        var facultyDtos = new List<FacultyDto> { facultyDto };

        _facultyRepoMock.Setup(x => x.GetAll()).Returns(faculties);
        _mapperMock.Setup(x => x.Map<IEnumerable<FacultyDto>>(faculties)).Returns(facultyDtos);

        var service = new FacultyService(_facultyRepoMock.Object, _mapperMock.Object);

        // Act
        var result = service.GetAll();

        // Assert
        Assert.Equal(1, result.Count());
        Assert.Equal("Test Reg Number", result.First().RegistrationNumber);
        _facultyRepoMock.Verify(x => x.GetAll(), Times.Once);
        _mapperMock.Verify(x => x.Map<IEnumerable<FacultyDto>>(faculties), Times.Once);
    }
}
