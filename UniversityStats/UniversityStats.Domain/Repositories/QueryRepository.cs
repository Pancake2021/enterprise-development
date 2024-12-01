using UniversityStats.Domain.Entity;

namespace UniversityStats.Domain.Repositories
{
    /// <summary>
    /// Repository class for performing various queries on university-related data.
    /// </summary>
    public class QueryRepository
    {
        private readonly Database database;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryRepository"/> class with the specified database.
        /// </summary>
        /// <param name="database">The database object used to query data.</param>
        public QueryRepository(Database database)
        {
            this.database = database;
        }

        /// <summary>
        /// Gets university's information by its registration number.
        /// </summary>
        /// <param name="registrationNumber">The university's registration number.</param>
        /// <returns>A list of tuples containing university information.</returns>
        public List<Tuple<string, string, string, string, string, string, string>> InfoUniversityByRegistration(string registrationNumber)
        {
            return (from university in database.UniversityList
                    where university.RegistrationNumber == registrationNumber
                    select new Tuple<string, string, string, string, string, string, string>
                    (
                        university.NameUniversity,
                        university.Address,
                        university.PropertyType,
                        university.BuildingOwnership,
                        university.RectorFullName,
                        university.Degree,
                        university.Tittle
                    )).ToList();
        }

        /// <summary>
        /// Counts the number of departments in each university.
        /// </summary>
        /// <returns>A list of tuples containing university name, registration number, and the total number of departments.</returns>
        public List<Tuple<string, string, int>> TotalDepartmentsInUniversity()
        {
            var tmp = from uni in database.UniversityList
                      join faculty in database.FacultyList on uni.RegistrationNumber equals faculty.RegistrationNumber
                      join department in database.DepartmentsList on faculty.FacultyId equals department.FacultyId
                      group uni by new { uni.RegistrationNumber, uni.NameUniversity } into table
                      select new
                      {
                          NameUniversity = table.Key.NameUniversity,
                          RegistrationNumber = table.Key.RegistrationNumber,
                          TotalDepartments = table.Count()
                      };

            return (from table in tmp
                    orderby table.TotalDepartments descending, table.NameUniversity ascending
                    select new Tuple<string, string, int>
                    (
                        table.NameUniversity,
                        table.RegistrationNumber,
                        table.TotalDepartments
                    ))
                    .ToList();
        }

        /// <summary>
        /// Gets the top five specialties with the highest number of groups.
        /// </summary>
        /// <returns>A list of the top five specialties with the highest number of groups.</returns>
        public List<Tuple<string, int>> TopFiveSpecialties()
        {
            var tmp = from specialty in database.SpecialtyList
                      group specialty by specialty.NameSpecialty into table
                      select new
                      {
                          NameSpecialty = table.Key,
                          TotalGroups = table.Sum(p => p.NumberOfGroups)
                      };
            return (from table in tmp
                    orderby table.TotalGroups descending
                    select new Tuple<string, int>
                    (
                        table.NameSpecialty,
                        table.TotalGroups
                    ))
                    .Take(5)
                    .ToList();
        }

        /// <summary>
        /// Counts the total number of groups in universities by property type.
        /// </summary>
        /// <param name="propertyType">The property type of the universities.</param>
        /// <returns>A list of tuples containing university registration number, name, property type, and total groups by property type.</returns>
        public List<Tuple<string, string, string, int>> TotalGroupsByProperty(string propertyType)
        {
            var tmp = from specialty in database.SpecialtyList
                      join deSpe in database.DepartmentSpecialtyList on specialty.SpecialtyId equals deSpe.SpecialtyId
                      join department in database.DepartmentsList on deSpe.DepartmentId equals department.DepartmentId
                      join faculty in database.FacultyList on department.FacultyId equals faculty.FacultyId
                      join uni in database.UniversityList on faculty.RegistrationNumber equals uni.RegistrationNumber
                      where uni.PropertyType == propertyType
                      group specialty by new { uni.RegistrationNumber, uni.NameUniversity, uni.PropertyType } into table
                      select new
                      {
                          table.Key.RegistrationNumber,
                          table.Key.NameUniversity,
                          table.Key.PropertyType,
                          TotalGroups = table.Sum(p => p.NumberOfGroups)
                      };

            return (from table in tmp
                    orderby table.TotalGroups descending
                    select new Tuple<string, string, string, int>
                    (
                        table.RegistrationNumber,
                        table.NameUniversity,
                        table.PropertyType,
                        table.TotalGroups
                    ))
                    .ToList();
        }

        /// <summary>
        /// Gets information about faculties and specialties in a specific university.
        /// </summary>
        /// <param name="nameUniversity">The name of the university.</param>
        /// <returns>A list of tuples containing university name, faculty name, department name, and specialty name.</returns>
        public List<Tuple<string, string, string, string>> InfoFacultiesSpecialties(string nameUniversity)
        {
            return (from faculty in database.FacultyList
                    join university in database.UniversityList on faculty.RegistrationNumber equals university.RegistrationNumber
                    join department in database.DepartmentsList on faculty.FacultyId equals department.FacultyId
                    join depSpecialty in database.DepartmentSpecialtyList on department.DepartmentId equals depSpecialty.DepartmentId
                    join specialty in database.SpecialtyList on depSpecialty.SpecialtyId equals specialty.SpecialtyId
                    where university.NameUniversity == nameUniversity
                    orderby faculty.NameFaculty descending
                    select new Tuple<string, string, string, string>
                    (
                        university.NameUniversity,
                        faculty.NameFaculty,
                        department.NameDepartment,
                        specialty.NameSpecialty
                    )
                ).ToList();
        }

        /// <summary>
        /// Counts the number of faculties, departments, and specialties by property type and building ownership.
        /// </summary>
        /// <returns>A list of tuples containing property type, building ownership, and counts of specialties, faculties, and departments.</returns>
        public List<Tuple<string, string, int, int, int>> TotalDepartmentsFacultiesSpecialtiesByPropertyBuilding()
        {
            var tmp1 = (from specialty in database.SpecialtyList
                        join deSpe in database.DepartmentSpecialtyList on specialty.SpecialtyId equals deSpe.SpecialtyId
                        join department in database.DepartmentsList on deSpe.DepartmentId equals department.DepartmentId
                        join faculty in database.FacultyList on department.FacultyId equals faculty.FacultyId
                        join uni in database.UniversityList on faculty.RegistrationNumber equals uni.RegistrationNumber
                        group specialty by new { uni.PropertyType, uni.BuildingOwnership } into table1
                        select new
                        {
                            table1.Key.PropertyType,
                            table1.Key.BuildingOwnership,
                            TotalSpecialties = table1.Count()
                        }
            ).ToList();

            var tmp2 = (from faculty in database.FacultyList
                        join university in database.UniversityList on faculty.RegistrationNumber equals university.RegistrationNumber
                        group faculty by new { university.PropertyType, university.BuildingOwnership } into table2
                        select new
                        {
                            table2.Key.PropertyType,
                            table2.Key.BuildingOwnership,
                            TotalFaculties = table2.Count()
                        }
            ).ToList();

            var tmp3 = (from department in database.DepartmentsList
                        join faculty in database.FacultyList on department.FacultyId equals faculty.FacultyId
                        join uni in database.UniversityList on faculty.RegistrationNumber equals uni.RegistrationNumber
                        group department by new { uni.PropertyType, uni.BuildingOwnership } into table3
                        select new
                        {
                            table3.Key.PropertyType,
                            table3.Key.BuildingOwnership,
                            TotalDepartments = table3.Count()
                        }
            ).ToList();

            return (from temp1 in tmp1
                    join temp2 in tmp2 on temp1.PropertyType equals temp2.PropertyType
                    where temp1.BuildingOwnership == temp2.BuildingOwnership
                    join temp3 in tmp3 on temp2.PropertyType equals temp3.PropertyType
                    where temp2.BuildingOwnership == temp3.BuildingOwnership
                    orderby temp1.TotalSpecialties descending
                    select new Tuple<string, string, int, int, int>
                    (
                        temp1.PropertyType,
                        temp1.BuildingOwnership,
                        temp1.TotalSpecialties,
                        temp2.TotalFaculties,
                        temp3.TotalDepartments
                    ))
                    .ToList();
        }
    }
}
