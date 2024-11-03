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
                Console.WriteLine("2. Показать факультеты с количеством групп больше заданного");
                Console.WriteLine("3. Показать специальности факультета");
                Console.WriteLine("4. Показать ректора по типу собственности университета");
                Console.WriteLine("5. Выйти");
                Console.Write("Выберите действие: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ShowUniversityInfo(university);
                        break;
                    case "2":
                        ShowFacultiesWithGroupCountGreaterThan(university);
                        break;
                    case "3":
                        ShowSpecialtiesByFaculty(university);
                        break;
                    case "4":
                        ShowRectorByOwnershipType(university);
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод. Пожалуйста, выберите номер от 1 до 5.");
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

        static void ShowFacultiesWithGroupCountGreaterThan(University university)
        {
            Console.Write("\nВведите минимальное количество групп: ");
            if (int.TryParse(Console.ReadLine(), out int minGroupCount))
            {
                var faculties = university.GetFacultiesWithGroupCountGreaterThan(minGroupCount);
                Console.WriteLine("\nФакультеты с количеством групп больше заданного:");
                foreach (var faculty in faculties)
                {
                    Console.WriteLine($"- {faculty.Name} (Группы: {faculty.GroupCount})");
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите числовое значение.");
            }
        }

        static void ShowSpecialtiesByFaculty(University university)
        {
            Console.Write("\nВведите название факультета: ");
            var facultyName = Console.ReadLine();

            var specialties = university.GetSpecialtiesByFaculty(facultyName);
            if (specialties.Any())
            {
                Console.WriteLine($"\nСпециальности факультета {facultyName}:");
                foreach (var specialty in specialties)
                {
                    Console.WriteLine($"- {specialty.Name} (Код: {specialty.Code})");
                }
            }
            else
            {
                Console.WriteLine("Факультет не найден или специальностей нет.");
            }
        }

        static void ShowRectorByOwnershipType(University university)
        {
            Console.WriteLine("\nВыберите тип собственности университета:");
            foreach (var ownership in Enum.GetValues(typeof(OwnershipType)))
            {
                Console.WriteLine($"- {ownership}");
            }

            Console.Write("Введите тип собственности: ");
            var input = Console.ReadLine();
            if (Enum.TryParse(input, out OwnershipType ownershipType))
            {
                var rectors = university.GetRectorsByOwnershipType(ownershipType);
                Console.WriteLine("\nРекторы с указанным типом собственности:");
                foreach (var rector in rectors)
                {
                    Console.WriteLine($"- {rector.FullName}, {rector.Position} ({rector.Degree}, {rector.Rank})");
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод типа собственности.");
            }
        }
    }
}
