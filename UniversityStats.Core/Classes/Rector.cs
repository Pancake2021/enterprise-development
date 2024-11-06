namespace UniversityStats.Classes;

/// <summary>
/// Перечисление для обозначения научной степени.
/// </summary>
public enum Degree
{
    PhD,
    Master,
    Bachelor
    // Добавьте другие степени, если необходимо
}

/// <summary>
/// Перечисление для обозначения академического звания.
/// </summary>
public enum Rank
{
    Professor,
    AssociateProfessor,
    Lecturer
    // Добавьте другие ранги, если необходимо
}

/// <summary>
/// Перечисление для обозначения должности ректора.
/// </summary>
public enum Position
{
    Rector,
    Dean,
    Lecturer
    // Добавьте другие позиции, если необходимо
}

/// <summary>
/// Класс, представляющий информацию о ректоре.
/// </summary>
public class Rector
{
    /// <summary>
    /// Полное имя ректора.
    /// </summary>
    public required string FullName { get; set; }

    /// <summary>
    /// Научная степень ректора.
    /// </summary>
    public required Degree Degree { get; set; }

    /// <summary>
    /// Академическое звание ректора.
    /// </summary>
    public required Rank Rank { get; set; }

    /// <summary>
    /// Должность ректора в университете.
    /// </summary>
    public required Position Position { get; set; }
}
