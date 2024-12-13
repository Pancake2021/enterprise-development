using UniversityStats.Domain.Entity;

namespace UniversityStats.Domain.Repositories;

/// <summary>
/// Class for query's repository
/// </summary>
/// <param name="educationDepartmentContext">Data context</param>
public class QueryRepository(UniversityStatsContext educationDepartmentContext)
{
    /// <summary>
    /// Method get university's information by registration number
    /// </summary>
    /// <param name="registrationNumber">Registration number</param>
    /// <returns>University's information</returns>
    public University? InfoUniversityByRegistration(string registrationNumber)
    { 
        return educationDepartmentContext.University.FirstOrDefault(uni => uni.RegistrationNumber == registrationNumber);
    }

    /// <summary>
    /// Method count number of departments in every university
    /// </summary>
    /// <returns>List number of departments in every university</returns>
    public List<Tuple<string, string, int>> TotalDepartmentsInUniversity()
    {
        return educationDepartmentContext.University
            .Join(educationDepartmentContext.Faculty,
                  university => university.RegistrationNumber,
                  faculty => faculty.RegistrationNumber,
                  (university, faculty) => new
                  {
                      University = university,
                      FacultyId = faculty.FacultyId
                  })
            .Join(educationDepartmentContext.Department,
                  a => a.FacultyId,
                  department => department.FacultyId,
                  (a, department) => new
                  {
                      a.University.RegistrationNumber,
                      a.University.NameUniversity,
                      department.DepartmentId
                  })
            .GroupBy(b => new { b.RegistrationNumber, b.NameUniversity })
            .OrderByDescending(c => c.Count())
            .Select(res => Tuple.Create(
                res.Key.RegistrationNumber,
                res.Key.NameUniversity,
                res.Count())
            ).ToList();
    }

    /// <summary>
    /// Method show top five specialties with highest number of groups
    /// </summary>
    /// <returns>List of top five specialties with highest number of groups</returns>
    public List<Tuple<string, int>> TopFiveSpecialties()
    {
        return educationDepartmentContext.Specialty
            .GroupBy(specialty => specialty.NameSpecialty)
            .OrderByDescending(specialty => specialty.Sum(spe => spe.NumberOfGroups))
            .Select(res => Tuple.Create(res.Key, res.Sum(spe => spe.NumberOfGroups)))
            .Take(5)
            .ToList();
    }

    /// <summary>
    /// Method count total groups by property type
    /// </summary>
    /// <param name="propertyType">Property tpe</param>
    /// <returns>List of university, total groups by property type </returns>
    public List<Tuple<string, string, string, int>> TotalGroupsByProperty(string propertyType)
    {
        return educationDepartmentContext.Specialty
            .Join(educationDepartmentContext.DepartmentSpecialty,
                specialty => specialty.SpecialtyId,
                deSpe => deSpe.SpecialtyId,
                (specialty, deSpe) => new { NumberOfGroups = specialty.NumberOfGroups, deSpe })
            .Join(educationDepartmentContext.Department,
                a => a.deSpe.DepartmentId,
                department => department.DepartmentId,
                (a, department) => new { a.NumberOfGroups, department.FacultyId })
            .Join(educationDepartmentContext.Faculty,
                b => b.FacultyId,
                faculty => faculty.FacultyId,
                (b, faculty) => new { b.NumberOfGroups, faculty.RegistrationNumber })
            .Join(educationDepartmentContext.University,
                c => c.RegistrationNumber,
                uni => uni.RegistrationNumber,
                (c, uni) => new { uni.RegistrationNumber, uni.NameUniversity, uni.PropertyType, c.NumberOfGroups })
            .Where(d => d.PropertyType == propertyType)
            .GroupBy(e => new { e.RegistrationNumber, e.NameUniversity, e.PropertyType })
            .OrderByDescending(f => f.Sum(g => g.NumberOfGroups))
            .Select(res => Tuple.Create(res.Key.RegistrationNumber, res.Key.NameUniversity, res.Key.PropertyType, res.Sum(h => h.NumberOfGroups)))
            .ToList();
    }
    
    /// <summary>
    /// Method show information of faculties and specialties in university by university's name
    /// </summary>
    /// <param name="nameUniversity">University's name</param>
    /// <returns>List information of faculties and specialties in university by university's name </returns>
    public List<Tuple<string, string, string, string>> InfoFacultiesSpecialties(string nameUniversity)
    {
        return educationDepartmentContext.University
            .Join(educationDepartmentContext.Faculty,
                university => university.RegistrationNumber,
                faculty => faculty.RegistrationNumber,
                (university, faculty) => new { university.NameUniversity, faculty.FacultyId, faculty.NameFaculty })
            .Join(educationDepartmentContext.Department,
                a => a.FacultyId,
                department => department.FacultyId,
                (a, department) => new { a.NameUniversity, a.NameFaculty, department.DepartmentId, department.NameDepartment })
            .Join(educationDepartmentContext.DepartmentSpecialty,
                b => b.DepartmentId,
                deSpe => deSpe.DepartmentId,
                (b, deSpe) => new { b.NameUniversity, b.NameFaculty, b.NameDepartment, deSpe.SpecialtyId })
            .Join(educationDepartmentContext.Specialty,
                c => c.SpecialtyId,
                specialty => specialty.SpecialtyId,
                (c, specialty) => new { c.NameUniversity, c.NameFaculty, c.NameDepartment, specialty.NameSpecialty })
            .Where(d => d.NameUniversity == nameUniversity)
            .Select(res => Tuple.Create(res.NameUniversity, res.NameFaculty, res.NameDepartment, res.NameSpecialty))
            .ToList();
    }

    /// <summary>
    /// Method count number of faculties, departments and specialties by property type and building ownership
    /// </summary>
    /// <returns>List of data mentioned</returns>
    public List<Tuple<string, string, int, int, int>> TotalDepartmentsFacultiesSpecialtiesByPropertyBuilding()
    {
        return educationDepartmentContext.University
            .Join(educationDepartmentContext.Faculty,
                  university => university.RegistrationNumber,
                  faculty => faculty.RegistrationNumber,
                  (university, faculty) => new 
                  {
                      university.PropertyType,
                      university.BuildingOwnership,
                      FacultyId = faculty.FacultyId
                  })
            .Join(educationDepartmentContext.Department,
                  a => a.FacultyId,
                  department => department.FacultyId,
                  (a, department) => new 
                  {
                      a.PropertyType,
                      a.BuildingOwnership,
                      a.FacultyId,
                      department.DepartmentId
                  })
            .Join(educationDepartmentContext.DepartmentSpecialty,
                  b => b.DepartmentId,
                  deSpe => deSpe.DepartmentId,
                  (b, deSpe) => new
                  {
                      b.PropertyType,
                      b.BuildingOwnership,
                      b.FacultyId,
                      b.DepartmentId,
                      deSpe.SpecialtyId
                  })
            .GroupBy(x => new { x.PropertyType, x.BuildingOwnership })
            .Select(g => new {
                PropertyType = g.Key.PropertyType,
                BuildingOwnership = g.Key.BuildingOwnership,
                TotalSpecialties = g.Count(),
                TotalFaculties = g.Select(x => x.FacultyId).Distinct().Count(), 
                TotalDepartments = g.Select(x => x.DepartmentId).Distinct().Count() 
            })
            .OrderByDescending(x => x.TotalSpecialties)
            .Select(res => Tuple.Create
                (
                    res.PropertyType,
                    res.BuildingOwnership,
                    res.TotalSpecialties,
                    res.TotalFaculties,
                    res.TotalDepartments
                ))
            .ToList();
    }

    /// <summary>
    /// Method get all universities
    /// </summary>
    /// <returns>List of universities</returns>
    public IEnumerable<University> GetAllUniversities() => 
        educationDepartmentContext.University.ToList();

    /// <summary>
    /// Method get all departments
    /// </summary>
    /// <returns>List of departments</returns>
    public IEnumerable<Department> GetAllDepartments() => 
        educationDepartmentContext.Department.ToList();

    /// <summary>
    /// Method get all faculties
    /// </summary>
    /// <returns>List of faculties</returns>
    public IEnumerable<Faculty> GetAllFaculties() => 
        educationDepartmentContext.Faculty.ToList();

    /// <summary>
    /// Method get all specialties
    /// </summary>
    /// <returns>List of specialties</returns>
    public IEnumerable<Specialty> GetAllSpecialties() => 
        educationDepartmentContext.Specialty.ToList();

    /// <summary>
    /// Method get all department specialties
    /// </summary>
    /// <returns>List of department specialties</returns>
    public IEnumerable<DepartmentSpecialty> GetAllDepartmentSpecialties() => 
        educationDepartmentContext.DepartmentSpecialty.ToList();
}
