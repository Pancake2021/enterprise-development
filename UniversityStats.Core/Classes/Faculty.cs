using System.Collections.Generic;

namespace UniversityStats.Classes;

/// <summary>
/// Класс, представляющий факультет.
/// </summary>
public class Faculty
{
    /// <summary>
    /// Уникальный идентификатор факультета (первичный ключ).
    /// </summary>
    public int Id { get; set; } // Primary Key

    /// <summary>
    /// Название факультета.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Количество групп на факультете.
    /// </summary>
    public int GroupCount { get; set; }

    /// <summary>
    /// Список кафедр, входящих в состав факультета.
    /// </summary>
    public List<Department> Departments { get; set; } = new List<Department>();

    /// <summary>
    /// Список специальностей на факультете.
    /// </summary>
    public List<Specialty> Specialties { get; set; } = new List<Specialty>();
}
