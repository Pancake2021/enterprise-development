using UniversityStats.Domain.Entity;
using Xunit;
using System.Linq;

namespace UniversityStats.Test;

public class EducationDepartmentTests(EducationDepartmentFixture fixture) : IClassFixture<EducationDepartmentFixture>
{
    private readonly EducationDepartmentFixture _fixture = fixture;

    [Fact]
    public void InfoUniversity()
    {
        var infoUniversity = (from university in _fixture.UniversityList
                              where university.RegistrationNumber is "UNI006"
                              select new
                              {
                                  university.RegistrationNumber,
                                  university.NameUniversity,
                                  university.Address,
                                  university.PropertyType,
                                  university.BuildingOwnership,
                                  university.RectorFullName,
                                  university.Degree,
                                  university.Tittle
                              }).ToList();


        Assert.Equal("UNI006", infoUniversity[0].RegistrationNumber);
        Assert.Equal("University of Foreign Languages", infoUniversity[0].NameUniversity);
        Assert.Equal("741 Pology Street", infoUniversity[0].Address);
        Assert.Equal("Municipal", infoUniversity[0].PropertyType);
        Assert.Equal("Municipal", infoUniversity[0].BuildingOwnership);
        Assert.Equal("Tatiana Nikolaevna Fedorova", infoUniversity[0].RectorFullName);
        Assert.Equal("PhD", infoUniversity[0].Degree);
        Assert.Equal("Professor", infoUniversity[0].Tittle);
    }

    [Fact]
    public void InfoFacultySpecialty()
    {
        var result = (from faculty in _fixture.FacultyList
                      join university in _fixture.UniversityList on faculty.RegistrationNumber equals university.RegistrationNumber
                      join department in _fixture.DepartmentsList on faculty.FacultyId equals department.FacultyId
                      join depSpecialty in _fixture.DepartmentSpecialtyList on department.DepartmentId equals depSpecialty.DepartmentId
                      join specialty in _fixture.SpecialtyList on depSpecialty.SpecialtyId equals specialty.SpecialtyId
                      where university.NameUniversity is "University of Technology and Economics"
                      orderby faculty.NameFaculty
                      select new
                      {
                          university.NameUniversity,
                          faculty.NameFaculty,
                          department.NameDepartment,
                          specialty.NameSpecialty
                      }
            ).ToList();

        Assert.Equal(result,
            [
                new {NameUniversity = "University of Technology and Economics", NameFaculty = "Faculty of Finance and Banking", NameDepartment = "Department of Finance", NameSpecialty="Finance and Banking"},
                new {NameUniversity = "University of Technology and Economics", NameFaculty = "Faculty of Information Technology", NameDepartment = "Department of Software Engineering", NameSpecialty="Computer Software Science"},
                new {NameUniversity = "University of Technology and Economics", NameFaculty = "Faculty of Information Technology", NameDepartment = "Department of Information", NameSpecialty="Computer Science"},
                new {NameUniversity = "University of Technology and Economics", NameFaculty = "Faculty of Mechanical Engineering", NameDepartment = "Department of Robotics", NameSpecialty="Mechanical Engineering"},
                new {NameUniversity = "University of Technology and Economics", NameFaculty = "Faculty of Mechanical Engineering", NameDepartment = "Department of Robotics", NameSpecialty="Mechanical Collaboration"},
                new {NameUniversity = "University of Technology and Economics", NameFaculty = "Faculty of Translation", NameDepartment = "Department of Languages", NameSpecialty="Translation Studies"},
            ]);
    }

    [Fact]
    public void TopFiveSpecialtyWithGroup()
    {
        var result = (from specialty in _fixture.SpecialtyList
                      group specialty by specialty.NameSpecialty into table
                      select new
                      {
                          NameSpecialty = table.Key,
                          TotalGroups = table.Sum(p => p.NumberOfGroups)
                      }
                      )
                      .OrderByDescending(p => p.TotalGroups)
                      .Take(5)
                      .ToList();

        Assert.Equal(result,
            [
                new {NameSpecialty = "Translation Studies", TotalGroups = 25},
                new {NameSpecialty = "Pedagogye", TotalGroups = 22},
                new {NameSpecialty = "Computer Software Science", TotalGroups = 14},
                new {NameSpecialty = "Finance and Banking", TotalGroups = 14},
                new {NameSpecialty = "Sports Science", TotalGroups = 13}
            ]);
    }

    [Fact]
    public void InfoUniversityByOrderMaxDepartment()
    {
        var result = (from uni in _fixture.UniversityList
                      join faculty in _fixture.FacultyList on uni.RegistrationNumber equals faculty.RegistrationNumber
                      join department in _fixture.DepartmentsList on faculty.FacultyId equals department.FacultyId
                      group uni by new { uni.RegistrationNumber, uni.NameUniversity } into table
                      select new
                      {
                          NameUniversity = table.Key.NameUniversity,
                          RegistrationNumber = table.Key.RegistrationNumber,
                          TotalDepartments = table.Count()
                      })
                      .OrderByDescending(x => x.TotalDepartments)
                      .ThenByDescending(x => x.NameUniversity)
                      .ToList();

        Assert.Equal(result,
            [
                new {NameUniversity = "University of Technology and Economics", RegistrationNumber = "UNI001", TotalDepartments = 5},
                new {NameUniversity = "University of Foreign Languages", RegistrationNumber = "UNI006", TotalDepartments = 4},
                new {NameUniversity = "University of Arts", RegistrationNumber = "UNI004", TotalDepartments = 4},
                new {NameUniversity = "Medical University", RegistrationNumber = "UNI002", TotalDepartments = 2},
                new {NameUniversity = "Sports University", RegistrationNumber = "UNI007", TotalDepartments = 1},
                new {NameUniversity = "Pedagogical University", RegistrationNumber = "UNI003", TotalDepartments = 1},
                new {NameUniversity = "Law University", RegistrationNumber = "UNI005", TotalDepartments = 1},
            ]);
    }

    [Fact]
    public void InfoTotalGroupsByPropertyType()
    {
        var result = (from specialty in _fixture.SpecialtyList
                      join deSpe in _fixture.DepartmentSpecialtyList on specialty.SpecialtyId equals deSpe.SpecialtyId
                      join department in _fixture.DepartmentsList on deSpe.DepartmentId equals department.DepartmentId
                      join faculty in _fixture.FacultyList on department.FacultyId equals faculty.FacultyId
                      join uni in _fixture.UniversityList on faculty.RegistrationNumber equals uni.RegistrationNumber
                      where uni.PropertyType is "Private"
                      group specialty by new { uni.RegistrationNumber, uni.NameUniversity, uni.PropertyType } into table
                      select new
                      {
                          RegistrationNumber = table.Key.RegistrationNumber,
                          NameUniversity = table.Key.NameUniversity,
                          PropertyType = table.Key.PropertyType,
                          TotalGroups = table.Sum(p => p.NumberOfGroups)
                      })
                    .OrderByDescending(p => p.TotalGroups)
                    .ToList();

        Assert.Equal(result,
            [
                new {RegistrationNumber = "UNI004", NameUniversity = "University of Arts", PropertyType = "Private", TotalGroups = 21},
                new {RegistrationNumber = "UNI002", NameUniversity = "Medical University", PropertyType = "Private", TotalGroups = 18},
                new {RegistrationNumber = "UNI005", NameUniversity = "Law University", PropertyType = "Private", TotalGroups = 8}
            ]);
    }

    [Fact]
    public void InfoDepartmentsFacultiesSpecialtiesByBuildingAndProperty()
    {
        var tmp1 = (from specialty in _fixture.SpecialtyList
                    join deSpe in _fixture.DepartmentSpecialtyList on specialty.SpecialtyId equals deSpe.SpecialtyId
                    join department in _fixture.DepartmentsList on deSpe.DepartmentId equals department.DepartmentId
                    join faculty in _fixture.FacultyList on department.FacultyId equals faculty.FacultyId
                    join uni in _fixture.UniversityList on faculty.RegistrationNumber equals uni.RegistrationNumber
                    group specialty by new { uni.PropertyType, uni.BuildingOwnership } into table1
                    select new
                    {
                        PropertyType = table1.Key.PropertyType,
                        BuildingOwnership = table1.Key.BuildingOwnership,
                        TotalSpecialties = table1.Count()
                    }
            ).ToList();

        var tmp2 = (from faculty in _fixture.FacultyList
                    join university in _fixture.UniversityList on faculty.RegistrationNumber equals university.RegistrationNumber
                    group faculty by new { university.PropertyType, university.BuildingOwnership } into table2
                    select new
                    {
                        PropertyType = table2.Key.PropertyType,
                        BuildingOwnership = table2.Key.BuildingOwnership,
                        TotalFaculties = table2.Count()
                    }
            ).ToList();

        var tmp3 = (from department in _fixture.DepartmentsList
                    join faculty in _fixture.FacultyList on department.FacultyId equals faculty.FacultyId
                    join uni in _fixture.UniversityList on faculty.RegistrationNumber equals uni.RegistrationNumber
                    group department by new { uni.PropertyType, uni.BuildingOwnership } into table3
                    select new
                    {
                        PropertyType = table3.Key.PropertyType,
                        BuildingOwnership = table3.Key.BuildingOwnership,
                        TotalDepartments = table3.Count()
                    }
            ).ToList();

        var result = (from temp1 in tmp1
                      join temp2 in tmp2 on temp1.PropertyType equals temp2.PropertyType
                      where temp1.BuildingOwnership == temp2.BuildingOwnership
                      join temp3 in tmp3 on temp2.PropertyType equals temp3.PropertyType
                      where temp2.BuildingOwnership == temp3.BuildingOwnership
                      select new
                      {
                          PropertyType = temp1.PropertyType,
                          BuildingOwnership = temp1.BuildingOwnership,
                          TotalSpecialties = temp1.TotalSpecialties,
                          TotalFaculties = temp2.TotalFaculties,
                          TotalDepartments = temp3.TotalDepartments
                      }
            )
            .OrderByDescending(p => p.TotalSpecialties)
            .ToList();
        Assert.Equal(result,
            [
                new{ PropertyType = "Private", BuildingOwnership = "Private", TotalSpecialties = 8, TotalFaculties = 5, TotalDepartments = 6},
                new{ PropertyType = "Municipal", BuildingOwnership = "Federal",  TotalSpecialties = 7, TotalFaculties = 5, TotalDepartments = 6},
                new{ PropertyType = "Municipal", BuildingOwnership = "Municipal",  TotalSpecialties = 6, TotalFaculties = 5, TotalDepartments = 5},
                new{ PropertyType = "Private", BuildingOwnership = "Municipal",  TotalSpecialties = 2, TotalFaculties = 1, TotalDepartments = 1},
            ]);
    }
}