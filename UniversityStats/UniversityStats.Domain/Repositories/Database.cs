using UniversityStats.Domain.Entity;

namespace UniversityStats.Domain.Repositories;

/// <summary>
/// Class for seeding initial data into the database
/// </summary>
public class DatabaseSeeder
{
    /// <summary>
    /// List of (department specialty)
    /// </summary>
    public List<DepartmentSpecialty> DepartmentSpecialtyList { get; set; }

    /// <summary>
    /// List of faculties
    /// </summary>
    public List<Faculty> FacultyList { get; set; }

    /// <summary>
    /// List of specialties
    /// </summary>
    public List<Specialty> SpecialtyList { get; set; }

    /// <summary>
    /// List of departments
    /// </summary>
    public List<Department> DepartmentsList { get; set; }

    /// <summary>
    /// List of university
    /// </summary>
    public List<University> UniversityList { get; set; }

    /// <summary>
    /// Constructor for class
    /// </summary>
    public DatabaseSeeder()
    {
        UniversityList =
            [
                new University
                {
                    RegistrationNumber = "REG_UNIV_001",
                    NameUniversity = "Московский государственный университет имени М.В. Ломоносова",
                    Address = "119991, Москва, Ленинские горы, д. 1",
                    PropertyType = "Государственный",
                    BuildingOwnership = "Федеральная",
                    RectorFullName = "Садовничий Виктор Антонович",
                    Degree = "Доктор физико-математических наук",
                    Title = "Профессор"
                },
                new University
                {
                    RegistrationNumber = "REG_UNIV_002",
                    NameUniversity = "Санкт-Петербургский государственный университет",
                    Address = "199034, Санкт-Петербург, Университетская набережная, д. 7/9",
                    PropertyType = "Государственный",
                    BuildingOwnership = "Федеральная",
                    RectorFullName = "Кропачев Николай Михайлович",
                    Degree = "Доктор юридических наук",
                    Title = "Профессор"
                },
                new University
                {
                    RegistrationNumber = "REG_UNIV_003",
                    NameUniversity = "Московский физико-технический институт",
                    Address = "141701, Московская область, Долгопрудный, Институтский пер., д. 9",
                    PropertyType = "Государственный",
                    BuildingOwnership = "Федеральная",
                    RectorFullName = "Кудрявцев Николай Николаевич",
                    Degree = "Доктор физико-математических наук",
                    Title = "Профессор"
                },
                new University
                {
                    RegistrationNumber = "REG_UNIV_004",
                    NameUniversity = "Национальный исследовательский университет «Высшая школа экономики»",
                    Address = "101000, Москва, ул. Мясницкая, д. 20",
                    PropertyType = "Государственный",
                    BuildingOwnership = "Федеральная",
                    RectorFullName = "Кузьминов Ярослав Иванович",
                    Degree = "Доктор экономических наук",
                    Title = "Профессор"
                },
                new University
                {
                    RegistrationNumber = "REG_UNIV_005",
                    NameUniversity = "Московский технический университет связи и информатики",
                    Address = "111024, Москва, ул. Авиамоторная, д. 8А",
                    PropertyType = "Государственный",
                    BuildingOwnership = "Федеральная",
                    RectorFullName = "Бабков Валерий Иванович",
                    Degree = "Доктор технических наук",
                    Title = "Профессор"
                },
                new University
                {
                    RegistrationNumber = "REG_UNIV_006",
                    NameUniversity = "Санкт-Петербургский политехнический университет Петра Великого",
                    Address = "195251, Санкт-Петербург, ул. Политехническая, д. 29",
                    PropertyType = "Государственный",
                    BuildingOwnership = "Федеральная",
                    RectorFullName = "Рудской Андрей Иванович",
                    Degree = "Доктор технических наук",
                    Title = "Профессор"
                },
                new University
                {
                    RegistrationNumber = "REG_UNIV_007",
                    NameUniversity = "Новосибирский государственный университет",
                    Address = "630090, Новосибирск, ул. Пирогова, д. 2",
                    PropertyType = "Государственный",
                    BuildingOwnership = "Федеральная",
                    RectorFullName = "Федорук Михаил Петрович",
                    Degree = "Доктор физико-математических наук",
                    Title = "Профессор"
                },
                new University
                {
                    RegistrationNumber = "REG_UNIV_008",
                    NameUniversity = "Казанский федеральный университет",
                    Address = "420008, Казань, ул. Кремлевская, д. 18",
                    PropertyType = "Государственный",
                    BuildingOwnership = "Федеральная",
                    RectorFullName = "Гафуров Ильшат Рафкатович",
                    Degree = "Доктор экономических наук",
                    Title = "Профессор"
                },
                new University
                {
                    RegistrationNumber = "REG_UNIV_009",
                    NameUniversity = "Уральский федеральный университет",
                    Address = "620002, Екатеринбург, ул. Мира, д. 19",
                    PropertyType = "Государственный",
                    BuildingOwnership = "Федеральная",
                    RectorFullName = "Кокшаров Виктор Анатольевич",
                    Degree = "Доктор экономических наук",
                    Title = "Профессор"
                },
                new University
                {
                    RegistrationNumber = "REG_UNIV_010",
                    NameUniversity = "Дальневосточный федеральный университет",
                    Address = "690922, Владивосток, о. Русский, кампус ДВФУ",
                    PropertyType = "Государственный",
                    BuildingOwnership = "Федеральная",
                    RectorFullName = "Кузьмин Никита Сергеевич",
                    Degree = "Доктор технических наук",
                    Title = "Профессор"
                }
            ];

        FacultyList =
            [
                new Faculty{FacultyId = "1001", NameFaculty = "Faculty of Information Technology", RegistrationNumber = "REG_UNIV_001"},
                new Faculty{FacultyId = "1002", NameFaculty = "Faculty of Mechanical Engineering", RegistrationNumber = "REG_UNIV_001"},
                new Faculty{FacultyId = "1003", NameFaculty = "Faculty of Finance and Banking", RegistrationNumber = "REG_UNIV_001"},
                new Faculty{FacultyId = "1004", NameFaculty = "Faculty of Translation", RegistrationNumber = "REG_UNIV_001"},
                new Faculty{FacultyId = "2001", NameFaculty = "Faculty of Medicine", RegistrationNumber = "REG_UNIV_002"},
                new Faculty{FacultyId = "2002", NameFaculty = "Faculty of Agronomy", RegistrationNumber = "REG_UNIV_002"},
                new Faculty{FacultyId = "3001", NameFaculty = "Faculty of Pedagogye", RegistrationNumber = "REG_UNIV_003"},
                new Faculty{FacultyId = "4001", NameFaculty = "Faculty of Fine Arts", RegistrationNumber = "REG_UNIV_004"},
                new Faculty{FacultyId = "4002", NameFaculty = "Faculty of Translation", RegistrationNumber = "REG_UNIV_004"},
                new Faculty{FacultyId = "4003", NameFaculty = "Faculty of Sports Science", RegistrationNumber = "REG_UNIV_004"},
                new Faculty{FacultyId = "5001", NameFaculty = "Faculty of International Law", RegistrationNumber = "REG_UNIV_005"},
                new Faculty{FacultyId = "6001", NameFaculty = "Faculty of Information Technology" , RegistrationNumber = "REG_UNIV_006"},
                new Faculty{FacultyId = "6002", NameFaculty = "Faculty of Pedagogye", RegistrationNumber = "REG_UNIV_006"},
                new Faculty{FacultyId = "6003", NameFaculty = "Faculty of Translation", RegistrationNumber = "REG_UNIV_006"},
                new Faculty{FacultyId = "6004", NameFaculty = "Faculty of Finance and Banking", RegistrationNumber = "REG_UNIV_006"},
                new Faculty{FacultyId = "7001", NameFaculty = "Faculty of Sports Science", RegistrationNumber = "REG_UNIV_007"}
            ];

        DepartmentsList =
            [
                new Department{FacultyId = "1001", NameDepartment = "Department of Software Engineering", DepartmentId = "1001-DSE", RegistrationNumber = "REG-1001-DSE"},
                new Department{FacultyId = "1001", NameDepartment = "Department of Information", DepartmentId = "1001-DI", RegistrationNumber = "REG-1001-DI"},
                new Department{FacultyId = "1002", NameDepartment = "Department of Robotics", DepartmentId = "1002-DR", RegistrationNumber = "REG-1002-DR"},
                new Department{FacultyId = "1003", NameDepartment = "Department of Finance", DepartmentId = "1003-DF", RegistrationNumber = "REG-1003-DF"},
                new Department{FacultyId = "1004", NameDepartment = "Department of Languages", DepartmentId = "1004-DL", RegistrationNumber = "REG-1004-DL"},
                new Department{FacultyId = "2001", NameDepartment = "Department of Surgery", DepartmentId = "2001-DS", RegistrationNumber = "REG-2001-DS"},
                new Department{FacultyId = "2002", NameDepartment = "Department of Pharmacy", DepartmentId = "2002-DP", RegistrationNumber = "REG-2002-DP"},
                new Department{FacultyId = "3001", NameDepartment = "Department of Crop Production", DepartmentId = "3001-DCP", RegistrationNumber = "REG-3001-DCP"},
                new Department{FacultyId = "4001", NameDepartment = "Department of Painting", DepartmentId = "4001-DP", RegistrationNumber = "REG-4001-DP"},
                new Department{FacultyId = "4001", NameDepartment = "Department of Drawing", DepartmentId = "4001-DD", RegistrationNumber = "REG-4001-DD"},
                new Department{FacultyId = "4002", NameDepartment = "Department of Languages", DepartmentId = "4002-DL", RegistrationNumber = "REG-4002-DL"},
                new Department{FacultyId = "4003", NameDepartment = "Department of Sports Physiologys", DepartmentId = "4003-DSP", RegistrationNumber = "REG-4003-DSP"},
                new Department{FacultyId = "5001", NameDepartment = "Department of Law", DepartmentId = "5001-DL", RegistrationNumber = "REG-5001-DL"},
                new Department{FacultyId = "6001", NameDepartment = "Department of Information", DepartmentId = "6001-DI", RegistrationNumber = "REG-6001-DI"},
                new Department{FacultyId = "6002", NameDepartment = "Department of Science Education", DepartmentId = "6002-DSE", RegistrationNumber = "REG-6002-DSE"},
                new Department{FacultyId = "6003", NameDepartment = "Department of Languages", DepartmentId = "6003-DL", RegistrationNumber = "REG-6003-DL"},
                new Department{FacultyId = "6004", NameDepartment = "Department of Finance", DepartmentId = "6004-DF", RegistrationNumber = "REG-6004-DF"},
                new Department{FacultyId = "7001", NameDepartment = "Department of Sports Physiologys", DepartmentId = "7001-DSP", RegistrationNumber = "REG-7001-DSP"},
            ];

        SpecialtyList =
            [
                new Specialty{SpecialtyId = "1001.05.03", NameSpecialty = "Computer Software Science",NumberOfGroups = 7 },
                new Specialty{SpecialtyId = "1001.04.03", NameSpecialty = "Computer Science", NumberOfGroups = 8 },
                new Specialty{SpecialtyId = "1002.05.01", NameSpecialty = "Mechanical Engineering", NumberOfGroups = 10 },
                new Specialty{SpecialtyId = "1002.04.02", NameSpecialty = "Mechanical Collaboration", NumberOfGroups = 5},
                new Specialty{SpecialtyId = "1003.04.05", NameSpecialty = "Finance and Banking", NumberOfGroups = 9},
                new Specialty{SpecialtyId = "1004.04.03", NameSpecialty = "Translation Studies", NumberOfGroups = 11},
                new Specialty{SpecialtyId = "2001.06.02", NameSpecialty = "Doctor", NumberOfGroups = 5},
                new Specialty{SpecialtyId = "2001.05.02", NameSpecialty = "Medicine", NumberOfGroups = 3},
                new Specialty{SpecialtyId = "2002.04.02", NameSpecialty = "Agronomy", NumberOfGroups = 4},
                new Specialty{SpecialtyId = "2002.04.04", NameSpecialty = "Pedagogye", NumberOfGroups = 6},
                new Specialty{SpecialtyId = "3001.04.01", NameSpecialty = "Pedagogye", NumberOfGroups = 8},
                new Specialty{SpecialtyId = "3001.04.03", NameSpecialty = "Sports Science", NumberOfGroups = 2},
                new Specialty{SpecialtyId = "4001.04.01", NameSpecialty = "Fine Arts", NumberOfGroups = 5},
                new Specialty{SpecialtyId = "4001.04.04", NameSpecialty = "Beauty Arts", NumberOfGroups = 6},
                new Specialty{SpecialtyId = "4002.04.02", NameSpecialty = "Translation Studies", NumberOfGroups = 6},
                new Specialty{SpecialtyId = "4003.04.03", NameSpecialty = "Sports Science", NumberOfGroups = 4},
                new Specialty{SpecialtyId = "5001.05.02", NameSpecialty = "International Law", NumberOfGroups = 3},
                new Specialty{SpecialtyId = "5001.04.01", NameSpecialty =  "Foreign Law", NumberOfGroups = 5},
                new Specialty{SpecialtyId = "6001.05.02", NameSpecialty = "Computer Software Science", NumberOfGroups = 7},
                new Specialty{SpecialtyId = "6002.04.02", NameSpecialty = "Pedagogye", NumberOfGroups = 8},
                new Specialty{SpecialtyId = "6003.04.02", NameSpecialty = "Translation Studies", NumberOfGroups = 8},
                new Specialty{SpecialtyId = "6004.04.02", NameSpecialty = "Finance and Banking", NumberOfGroups = 5},
                new Specialty{SpecialtyId = "7001.03.02", NameSpecialty = "Sports Science", NumberOfGroups = 7}
            ];

        DepartmentSpecialtyList =
            [
                new DepartmentSpecialty{DepartmentId = "1001-DSE", SpecialtyId = "1001.05.03"},
                new DepartmentSpecialty{DepartmentId = "1001-DI", SpecialtyId = "1001.04.03"},
                new DepartmentSpecialty{DepartmentId = "1002-DR", SpecialtyId = "1002.05.01"},
                new DepartmentSpecialty{DepartmentId = "1002-DR", SpecialtyId = "1002.04.02"},
                new DepartmentSpecialty{DepartmentId = "1003-DF", SpecialtyId = "1003.04.05"},
                new DepartmentSpecialty{DepartmentId = "1004-DL", SpecialtyId = "1004.04.03"},
                new DepartmentSpecialty{DepartmentId = "2001-DS", SpecialtyId = "2001.06.02"},
                new DepartmentSpecialty{DepartmentId = "2001-DS", SpecialtyId = "2001.05.02"},
                new DepartmentSpecialty{DepartmentId = "2002-DP", SpecialtyId = "2002.04.02"},
                new DepartmentSpecialty{DepartmentId = "2002-DP", SpecialtyId = "2002.04.04"},
                new DepartmentSpecialty{DepartmentId = "3001-DCP", SpecialtyId = "3001.04.01"},
                new DepartmentSpecialty{DepartmentId = "3001-DCP", SpecialtyId = "3001.04.03"},
                new DepartmentSpecialty{DepartmentId = "4001-DP", SpecialtyId = "4001.04.01"},
                new DepartmentSpecialty{DepartmentId = "4001-DD", SpecialtyId = "4001.04.04"},
                new DepartmentSpecialty{DepartmentId = "4002-DL", SpecialtyId = "4002.04.02"},
                new DepartmentSpecialty{DepartmentId = "4003-DSP", SpecialtyId = "4003.04.03"},
                new DepartmentSpecialty{DepartmentId = "5001-DL", SpecialtyId = "5001.05.02"},
                new DepartmentSpecialty{DepartmentId = "5001-DL", SpecialtyId = "5001.04.01"},
                new DepartmentSpecialty{DepartmentId = "6001-DI", SpecialtyId = "6001.05.02"},
                new DepartmentSpecialty{DepartmentId = "6002-DSE", SpecialtyId = "6002.04.02"},
                new DepartmentSpecialty{DepartmentId = "6003-DL", SpecialtyId = "6003.04.02"},
                new DepartmentSpecialty{DepartmentId = "6004-DF", SpecialtyId = "6004.04.02"},
                new DepartmentSpecialty{DepartmentId = "7001-DSP", SpecialtyId = "7001.03.02"},
            ];


    }
}
