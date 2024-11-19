namespace UniversityStats.Classes;

/// <summary>
/// Класс, представляющий информацию о специальности.
/// </summary>
public class Specialty
{
    /// <summary>
    /// Уникальный код специальности.
    /// </summary>
    public required string Code { get; set; }

    /// <summary>
    /// Название специальности.
    /// </summary>
    public required string Name { get; set; }
}
