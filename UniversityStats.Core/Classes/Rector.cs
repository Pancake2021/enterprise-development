namespace UniversityStats.Classes;

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
