namespace UniversityStats.Classes;

public class Rector
{
    public int Id { get; set; } // Primary Key
    public required string FullName { get; set; }
    public required string Degree { get; set; }
    public required string Rank { get; set; }
    public required string Position { get; set; }
}
