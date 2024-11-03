using System;
using System.Collections.Generic;
using UniversityStats.Classes;

namespace UniversityStats
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем пример университета для взаимодействия
            var university = CreateSampleUniversity();

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Меню Университета ===");
                Console.WriteLine("1. Показать информацию об университете");
                Console.WriteLine("2. Показать информацию о факультетах, кафедрах и специальностях");
                Console.WriteLine("3. Показать топ 5 популярных специальностей");
                Console.WriteLine("4. Показать университеты с максимальным количеством кафедр");
                Console.WriteLine("5. Показать университеты по типу собственности и количеству групп");
                Console.WriteLine("6. Показать статистику по типу собственности");
                Console.WriteLine("7. Выйти");
                Console.Write("Выберите действие: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ShowUniversityInfo(university);
                        break;
                    case "2":
                        ShowFacultyDepartmentSpecialtyInfo(university);
                        break;
                    case "3":
                        ShowTop5PopularSpecialties(university);
                        break;
                    case "4":
                        ShowUniversitiesWithMaxDepartments(new List<University> { university });
                        break;
                    case "5":
                        ShowUniversitiesByOwnershipAndGroupCount(new List<University> { university });
                        break;
                    case "6":
                        ShowOwnershipStatistics(new List<University> { university });
                        break;
                    case "7":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод. Пожалуйста, выберите номер от 1 до 7.");
                        break;
                }
                if (!exit)
                {
                    Console.WriteLine("Нажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                }
            }
        }

        static University CreateSampleUniversity()
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

        static void ShowUniversityInfo(University university)
        {
            Console.WriteLine("\n=== Информация об Университете ===");
            Console.WriteLine($"Регистрационный номер: {university.RegistrationNumber}");
            Console.WriteLine($"Название: {university.Name}");
            Console.WriteLine($"Адрес: {university.Address}");
            Console.WriteLine($"Ректор: {university.RectorInfo.FullName}, {university.RectorInfo.Position}");
            Console.WriteLine($"Тип собственности: {university.InstitutionOwnership}");
            Console.WriteLine($"Собственность здания: {university.BuildingOwnership}");
            Console.WriteLine($"Количество факультетов: {university.Faculties.Count}");
        }

        static void ShowFacultyDepartmentSpecialtyInfo(University university)
        {
            var info = university.GetFacultyDepartmentSpecialtyInfo();
            Console.WriteLine("\n=== Факультеты, Кафедры и Специальности ===");
            foreach (var (faculty, department, specialty) in info)
            {
                Console.WriteLine($"Факультет: {faculty}, Кафедра: {department}, Специальность: {specialty}");
            }
        }

        static void ShowTop5PopularSpecialties(University university)
        {
            var specialties = university.GetTop5PopularSpecialties();
            Console.WriteLine("\n=== Топ 5 популярных специальностей ===");
            foreach (var specialty in specialties)
            {
                Console.WriteLine($"Специальность: {specialty.Name}");
            }
        }

        static void ShowUniversitiesWithMaxDepartments(List<University> universities)
        {
            var result = University.GetUniversitiesWithMaxDepartments(universities);
            Console.WriteLine("\n=== Университеты с максимальным количеством кафедр ===");
            foreach (var uni in result)
            {
                Console.WriteLine($"Университет: {uni.Name}, Кафедры: {uni.Faculties.Sum(f => f.Departments.Count)}");
            }
        }

        static void ShowUniversitiesByOwnershipAndGroupCount(List<University> universities)
        {
            Console.WriteLine("\nВведите тип собственности (Municipal, Private, Federal): ");
            if (Enum.TryParse(Console.ReadLine(), out OwnershipType ownershipType))
            {
                var result = University.GetUniversitiesByOwnershipAndGroupCount(universities, ownershipType);
                Console.WriteLine($"\n=== Университеты с собственностью {ownershipType} ===");
                foreach (var uni in result)
                {
                    Console.WriteLine($"Университет: {uni.Name}, Группы: {uni.Faculties.Sum(f => f.GroupCount)}");
                }
            }
            else
            {
                Console.WriteLine("Некорректный тип собственности.");
            }
        }

        static void ShowOwnershipStatistics(List<University> universities)
        {
            var stats = University.GetOwnershipStatistics(universities);
            Console.WriteLine("\n=== Статистика по типу собственности ===");
            foreach (var (ownership, facultyCount, departmentCount, specialtyCount) in stats)
            {
                Console.WriteLine($"Тип собственности: {ownership}, Факультеты: {facultyCount}, Кафедры: {departmentCount}, Специальности: {specialtyCount}");
            }
        }
    }
}
